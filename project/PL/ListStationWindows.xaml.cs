using BLAPI;
using BO;
using PL.PO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        string[] listString = { "Code", "Name" };
        /// <summary>
        /// constructor basic
        /// </summary>
        public ListStationWindows(IBL bl)
        {
            InitializeComponent();
            this.bl = bl;
            updateDataContext();//call fonction to update the data context
            sortBox.ItemsSource = listString;//set the comboBox to sort the list
        }
        /// <summary>
        /// constructor for sort this window i call the window again 
        /// </summary>
        /// <param name="item"></param>
        public ListStationWindows(string item, IBL bl)
        {
            InitializeComponent();
            this.bl = bl;
            updateDataContext();//call fonction to update the data context
            sortBox.ItemsSource = listString;//set the comboBox to sort the list
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(StationList.DataContext);//to sort list 
            view.SortDescriptions.Add(new SortDescription(item, ListSortDirection.Ascending));
        }
     
      
        /// <summary>
        /// i resize my windows when i want to choose station for a line because i don't want button remove and update at this moment
        /// </summary>
    

        void updateDataContext()
        {
            collection = new ObservableCollection<StationPO>(from item in bl.getAllStation()//get all station of list of sttaion
                                                                      select new StationPO(item));
            StationList.DataContext = null;
            StationList.DataContext = collection;//and restet the data context
        }
        void updateDataContext1(string item)
        {
            collection = new ObservableCollection<StationPO>(from station in bl.searchStation(item)//get the result of search
                                                         select new StationPO(station));
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
                MainStation wnd = new MainStation(bl);//open one page before
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
            Opwindow wnd = new Opwindow(bl);//open th ehome page
            wnd.Show();
            this.Close();//and close this page
        }
        /// <summary>
        /// when you double click you display the information of the station or you choose the station for line regardless of where the window is open
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StationList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            StationPO station = ((FrameworkElement)e.OriginalSource).DataContext as StationPO;//set the bus
            if (station != null)
            {
                InformationStationWindow wnd = new InformationStationWindow(station.Code, bl);
                this.Hide();
                wnd.ShowDialog();
                this.Show();
            }
            
        }
        /// <summary>
        /// button click to remove a line from listview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
                Button btn = sender as Button;//set the button
                StationPO StationPO = btn.DataContext as StationPO;//Set the line of listview to station
                bl.removeStation(StationPO.Code);//and use remove from blimp
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
                StationPO stationsPO = btn.DataContext as StationPO;//set the line of listview to station
                UpdateStation wnd = new UpdateStation(stationsPO.Code,bl);
                this.Hide();
                wnd.ShowDialog();
                updateDataContext();// and update the datacontext
                this.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// to sort the list if i am in list of station or if i want to choose station for line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sortBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string item = sortBox.SelectedItem as string;
           if (item != null)//if i want to see the list of list of station
            {
                ListStationWindows wnd = new ListStationWindows(item,bl);//i open this sorted window 
                wnd.Show();
                this.Close();
            }
        }
        private void OnKeyDownHandler(object sender, KeyEventArgs e)//to press enter 
        {

            if (e.Key == Key.Return)
            {
                string item = searchBox.Text as string;
                if (item != null)
                    updateDataContext1(item);//i search the result and update the list
            }
        }

        private void Button_ClickSimulator(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;//set the button
            StationPO stationsPO = btn.DataContext as StationPO;//set the line of listview to station
            if (bl.listLineOfstationForsimu(stationsPO.getStation(), clock.Instance.startTime).Count() != 0 && clock.Instance.stopWatch.IsRunning)
            {
                Simulator wnd = new Simulator(bl, stationsPO.getStation());
                wnd.Show();
            }
        }

    }
}
