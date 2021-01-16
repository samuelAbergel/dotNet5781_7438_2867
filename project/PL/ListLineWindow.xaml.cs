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

namespace PL
{
    /// <summary>
    /// window to display a list of lines
    /// </summary>
    public partial class ListLineWindow : Window
    {
        IBL bl;
        ObservableCollection<LinePO> collection;
        LinePO linePO;
        public ListLineWindow()
        {
            InitializeComponent();
            bl = BLFactory.GetBL();
            updateDataContext();//call this fonction to update data context
        }
        void updateDataContext()
        {
            collection = new ObservableCollection<LinePO>(from item in bl.getAllLine()//get all line of list of line
                                                         select new LinePO(item));
            LineList.DataContext = null;
            LineList.DataContext = collection;//reset the data context
        }
        /// <summary>
        /// button to go to home page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            Opwindow wnd = new Opwindow();//open the home page
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
            MainLine wnd = new MainLine();//open one page before
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
            if (linePO != null && linePO.listOfStationInLine != null) //if it exist
            {
                listStationInLineWindow wnd = new listStationInLineWindow(linePO.getLine());//open information page
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
            bl.removeLine(linePO.Id);//use remove from blimp
            updateDataContext();//and update the data context
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;//set the bus 
            LinePO linePO = btn.DataContext as LinePO;//ste the line in line
            UpdateLine wnd = new UpdateLine(linePO.getLine());//open window page
            this.Hide();
            wnd.ShowDialog();
            updateDataContext();// an dupdate the data context
            this.Show();
        }
    }
}
