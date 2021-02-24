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
using BO;
using System.ComponentModel;

namespace PL
{
    /// <summary>
    /// window to display a list of lines
    /// </summary>
    public partial class ListLineWindow : Window
    {
        IBL bl;
        ObservableCollection<LinePO> collection;
        string[] listString = { "Id", "Area", "FirstStation", "LastStation" };
        public ListLineWindow(IBL bl)
        {
            InitializeComponent();
            this.bl = bl;
            updateDataContext();//call this fonction to update data context
            sortBox.ItemsSource = listString;
        }
        public ListLineWindow(string item, IBL bl)
        {
            InitializeComponent();
            this.bl = bl;
            updateDataContext();//call this fonction to update data context
            sortBox.ItemsSource = listString;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(LineList.DataContext);
            view.SortDescriptions.Add(new SortDescription(item, ListSortDirection.Ascending));
        }
        void updateDataContext()
        {
            collection = new ObservableCollection<LinePO>(from item in bl.getAllLine()//get all line of list of line
                                                         select new LinePO(item));
            LineList.DataContext = null;
            LineList.DataContext = collection;//reset the data context
        }
        void updateDataContext1(string item)
        {
            collection = new ObservableCollection<LinePO>(from line in bl.searchLine(item)//get all buses from thelist
                                                             select new LinePO(line));
            LineList.DataContext = null;
            LineList.DataContext = collection;//and restet the data context
        }
        /// <summary>
        /// button to go to home page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            Opwindow wnd = new Opwindow(bl);//open the home page
            wnd.Show();
            this.Close();//and close this page
        }
        /// <summary>
        /// fonction to return one page before
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            MainLine wnd = new MainLine(bl);//open one page before
            wnd.Show();
            this.Close();
        }
        /// <summary>
        /// when you double click you display information of line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LineList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            LinePO linePO = ((FrameworkElement)e.OriginalSource).DataContext as LinePO;//get the  line 
            if (linePO != null && bl.GetLineStationsFromLine(linePO.getLine()).Count() != 0) //if it exist
            {
                listStationInLineWindow wnd = new listStationInLineWindow(linePO.getLine(),bl);//open information page
                this.Hide();
                wnd.ShowDialog();
                this.Show();
            }
        }
        /// <summary>
        /// button click to remove line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;//set button
            LinePO linePO= btn.DataContext as LinePO;//set the line in line
            bl.removeLine(linePO.Code);//use remove from blimp
            bl.removeLineTrip(linePO.Code);
            foreach(var item in bl.GetLineStationsFromLine(linePO.getLine()))
            {
                bl.removeLineStation(item.Station);
            }
            updateDataContext();//and update the data context
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;//set the bus 
            LinePO linePO = btn.DataContext as LinePO;//ste the line in line
            UpdateLine wnd = new UpdateLine(linePO.getLine(),bl);//open window page
            this.Hide();
            wnd.ShowDialog();
            updateDataContext();// an dupdate the data context
            this.Show();
        }
        /// <summary>
        /// to sort the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sortBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string item = sortBox.SelectedItem as string;
            if (item != null)
            {
                ListLineWindow wnd = new ListLineWindow(item,bl);//I open the page again with the constructor which sorts the list
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
                    updateDataContext1(item);//i'mm search and update it
            }
        }
    }
}
