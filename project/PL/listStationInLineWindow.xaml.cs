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
    /// this window display list of station in line
    /// </summary>
    public partial class listStationInLineWindow : Window
    {
        IBL bl;
        ObservableCollection<LineStationPO> collection;
        BO.Line line;
        public listStationInLineWindow(BO.Line line, IBL bl)
        {
            this.bl = bl;
            InitializeComponent();
            this.line = line;
            updateDataContext();//call fonction to update the data context
            ok.Text = bl.getTime(line).ToString();
        }
        void updateDataContext()
        {
            collection = new ObservableCollection<LineStationPO>(from item in bl.GetLineStationsFromLine(line)//get all station of list of station
                                                         select new LineStationPO(item));
            StationList.DataContext = null;
            StationList.DataContext = collection;//and reset the data context
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
