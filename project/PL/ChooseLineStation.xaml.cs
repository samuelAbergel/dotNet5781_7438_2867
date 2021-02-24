using BLAPI;
using PL.PO;
using PO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PL
{
    /// <summary>
    /// Logique d'interaction pour ChooseLineStation.xaml
    /// </summary>
    public partial class ChooseLineStation : Window
    {
        IBL bl;
        ObservableCollection<StationPO> collection;
        ObservableCollection<LineStationPO> collection1;
        BO.Line line;
        public ChooseLineStation(BO.Line line,IBL bl)
        {
            InitializeComponent();
            this.bl = bl;
            this.line = line;
            updateDataContext();
            Init(line);
        }

        private void Init(BO.Line line)
        {

            collection1 = new ObservableCollection<LineStationPO>(from item in bl.GetLineStationsFromLine(line)//get all station of list of sttaion
                                                                  select new LineStationPO(item));
            LineStationList.DataContext = null;
            LineStationList.DataContext = collection1;//and restet the data context
        }

        void updateDataContext()
        {
            collection = new ObservableCollection<StationPO>(from item in bl.getAllStation()//get all station of list of sttaion
                                                             select new StationPO(item));
            StationList.DataContext = null;
            StationList.DataContext = collection;//and restet the data context
        }
        void updateDataContext(StationPO station)
        {
            int index = collection1.Count();
            BO.LineStation linestation = new BO.LineStation { LineId = line.Code, Station = station.Code, LineStationIndex = index };
            try
            {
              bl.AddLineStation(linestation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            Init(line);
        }
        private void StationList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            StationPO station = ((FrameworkElement)e.OriginalSource).DataContext as StationPO;//set the bus
            if (station != null)
            {
                updateDataContext(station);
            }
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            //when you add a line add all adj station that corespond 
            try
            {
                for (int i = 0; i < collection1.Count()-1 ; i++)
                {
                    LineStationPO stationPO1 = LineStationList.Items[i] as LineStationPO;
                    LineStationPO stationPO2 = LineStationList.Items[i+1] as LineStationPO;
                    bl.addAdjacentStation(stationPO1.Station, stationPO2.Station);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            this.Close();
        }

        private void ButtonInformation_Click(object sender, RoutedEventArgs e)
        {
            //remove this line station et replace other
            LineStationPO linestation = ((FrameworkElement)e.OriginalSource).DataContext as LineStationPO;//set the bus
            bl.removeLineStation(linestation.ID);
            List<BO.LineStation> lst = bl.GetLineStationsFromLine(line).ToList();
            for (int i = linestation.LineStationIndex; i < lst.Count(); i++)
            {
                lst[i].LineStationIndex--;
                bl.updateLineStation(lst[i]);
            }
            Init(line);
        }
    }
}
