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
        ObservableCollection<AdjacentStationsPO> collection;
        AdjacentStationsPO adjacentStationsPO;
        public ListStationWindows()
        {
            InitializeComponent();
            bl = BLFactory.GetBL();
            updateDataContext();//call fonction to update the data context
        }
        void updateDataContext()
        {
            collection = new ObservableCollection<AdjacentStationsPO>(from item in bl.getAdjacentStation()//get all station of list of sttaion
                                                                      select new AdjacentStationsPO(item));
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
            MainStationWindow wnd = new MainStationWindow();//open one page before
            wnd.Show();
            this.Close();//and close this page
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
            AdjacentStationsPO adjacentStationsPO = ((FrameworkElement)e.OriginalSource).DataContext as AdjacentStationsPO;//set the line of list view to station
            ChoiceStationWindows wnd = new ChoiceStationWindows(adjacentStationsPO.getAdjacentStations(),1); //and open window to choose station 1 or 2
            wnd.Show();
        }
        /// <summary>
        /// button click to remove a line from listview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;//set the button
            AdjacentStationsPO adjacentStationsPO = btn.DataContext as AdjacentStationsPO;//Set the line of listview to station
            bl.removeAdjacentStation(adjacentStationsPO.Station1);//and use remove from blimp
            updateDataContext();//and update the datacontext
        }
        /// <summary>
        /// button for update one line of the listview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;//set the button
            AdjacentStationsPO adjacentStationsPO = btn.DataContext as AdjacentStationsPO;//set the line of listview to station
            ChoiceStationWindows wnd = new ChoiceStationWindows(adjacentStationsPO.getAdjacentStations(),2);//open page to choose sttaion 1 or 2
            wnd.Show();
            updateDataContext();// and update the datacontext
        }
    }
}
