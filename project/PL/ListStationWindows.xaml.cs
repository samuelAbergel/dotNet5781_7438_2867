using BLAPI;
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
        StationPO stationsPO;
        BO.Line line;
        int index = 0;
        string[] listString = { "Code", "Name" };
        /// <summary>
        /// constructor basic
        /// </summary>
        public ListStationWindows()
        {
            InitializeComponent();
            bl = BLFactory.GetBL();
            updateDataContext();//call fonction to update the data context
            sortBox.ItemsSource = listString;//set the comboBox to sort the list
        }
        /// <summary>
        /// constructor for sort this window i call the window again 
        /// </summary>
        /// <param name="item"></param>
        public ListStationWindows(string item)
        {
            InitializeComponent();
            bl = BLFactory.GetBL();
            updateDataContext();//call fonction to update the data context
            sortBox.ItemsSource = listString;//set the comboBox to sort the list
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(StationList.DataContext);//to sort list 
            view.SortDescriptions.Add(new SortDescription(item, ListSortDirection.Ascending));
        }
        /// <summary>
        /// constructor for when I want to choose stations for a line
        /// </summary>
        /// <param name="line"></param>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public ListStationWindows(BO.Line line ,int index,string item)
        {
            InitializeComponent();
            bl = BLFactory.GetBL();
            Resize();
            sortBox.ItemsSource = listString;//set the comboBox to sort the list
            this.index = index;//set the index
            this.line = line;//set the line
            updateDataContext();//call fonction to update the data context
            if (item != string.Empty)//if i want to sort this windows and choose station for line
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(StationList.DataContext);//to sort the list
                view.SortDescriptions.Add(new SortDescription(item, ListSortDirection.Ascending));
            }
            if(line.listOfStationInLine == null)
            line.listOfStationInLine = new BO.Station[] { new BO.Station() };// init station of line with a base station so that it is not null

        }
        /// <summary>
        /// i resize my windows when i want to choose station for a line because i don't want button remove and update at this moment
        /// </summary>
        private void Resize()
        {
            columnRemove.Width = 0;
            columnUpdate.Width = 0;
            ColumnName.Width = 189;
            ColumnCode.Width = 184;
            ColumnLattitude.Width = 174;
            ColumnLongitude.Width = 186;
        }

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
        /// when you double click you display the information of the station or you choose the station for line regardless of where the window is open
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StationList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            StationPO station = ((FrameworkElement)e.OriginalSource).DataContext as StationPO;//set the bus
            if(index == 0) //if I am in my station list and I want the info
            {
                InformationStationWindow wnd = new InformationStationWindow(station.Code);
                this.Hide();
                wnd.ShowDialog();
                this.Show();
            }
            if (index == 2 && station != null)//and if want to choose station for line
            {
                IEnumerable<BO.Station> list = from item in bl.getAllStation()
                                               where item.Code == station.Code
                                               select item; //get the bus that i want to add
                if (line.listOfStationInLine.FirstOrDefault(p => p.Code == list.First().Code) == null)//if I haven't already added it
                {
                    line.listOfStationInLine = line.listOfStationInLine.Concat(list);//i add it
                    MessageBox.Show(string.Format($"this station :{station.Code} was add"), "bus add", MessageBoxButton.OK, MessageBoxImage.Information);//and I inform him
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
        /// <summary>
        /// to sort the list if i am in list of station or if i want to choose station for line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sortBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string item = sortBox.SelectedItem as string;
            if(index == 2 && item != null)//if i want to choose station fo rline
            {
                ListStationWindows wnd = new ListStationWindows(line,2,item);//I open this resized page
                wnd.Show();
                this.Close();
            }
            else if (item != null)//if i want to see the list of list of station
            {
                ListStationWindows wnd = new ListStationWindows(item);//i open this sorted window 
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

    
    }
}
