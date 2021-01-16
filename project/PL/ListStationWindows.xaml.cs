using BLAPI;
using PL.PO;
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
    /// window to display list of station
    /// </summary>
    public partial class ListStationWindows : Window
    {
        IBL bl;
        ObservableCollection<StationPO> collection;
        StationPO stationsPO;
        BO.Line line;
        int index = 0;
        public ListStationWindows()
        {
            InitializeComponent();
            bl = BLFactory.GetBL();
            updateDataContext();//call fonction to update the data context
        }
        public ListStationWindows(BO.Line line ,int index)
        {
            InitializeComponent();
            bl = BLFactory.GetBL();
            this.index = index;
            this.line = line;
            line.listOfStationInLine = new BO.Station[] { new BO.Station() };
            updateDataContext();//call fonction to update the data context
        }
        void updateDataContext()
        {
            collection = new ObservableCollection<StationPO>(from item in bl.getAllStation()//get all station of list of sttaion
                                                                      select new StationPO(item));
            StationList.DataContext = null;
            StationList.DataContext = collection;//and restet the data context
        }
        /// <summary>
        /// to go one page before
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (index == 0)
            {
                MainStation wnd = new MainStation();//open one page before
                wnd.Show();
                this.Close();//and close this page
            }
            if(index == 2)
            {
                this.Close();
            }
        }
        /// <summary>
        /// to go to home page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            Opwindow wnd = new Opwindow();//open th ehome page
            wnd.Show();
            this.Close();//and close this page
        }
        /// <summary>
        /// when you double click you display the information of the station
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StationList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            StationPO station = ((FrameworkElement)e.OriginalSource).DataContext as StationPO;//set the bus
            if(index == 0)
            {
                InformationStationWindow wnd = new InformationStationWindow(station.Code);
                this.Hide();
                wnd.ShowDialog();
                this.Show();
            }
            if (index == 2 && station != null)
            {
                IEnumerable<BO.Station> list = from item in bl.getAllStation()
                                               where item.Code == station.Code
                                               select item;
                if (line.listOfStationInLine.FirstOrDefault(p => p.Code == list.First().Code) == null)
                {
                    line.listOfStationInLine = line.listOfStationInLine.Concat(list);
                    MessageBox.Show(string.Format($"this station :{station.Code} was add"), "bus add", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        /// <summary>
        /// button click to remove a line from listview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            if (index == 0)
            {
                Button btn = sender as Button;//set the button
                StationPO StationPO = btn.DataContext as StationPO;//Set the line of listview to station
                bl.removeStation(StationPO.Code);//and use remove from blimp
                updateDataContext();//and update the datacontext
            }
        }
        /// <summary>
        /// button for update one line of the listview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (index == 0)
            {
                Button btn = sender as Button;//set the button
                StationPO stationsPO = btn.DataContext as StationPO;//set the line of listview to station
                UpdateStation wnd = new UpdateStation(stationsPO.Code);
                this.Hide();
                wnd.ShowDialog();
                updateDataContext();// and update the datacontext
                this.Show();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
