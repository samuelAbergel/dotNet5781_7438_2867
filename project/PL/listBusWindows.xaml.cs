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
    /// Logique d'interaction pour listBusWindows.xaml
    /// </summary>
    public partial class listBusWindows : Window
    {
        IBL bl;
        ObservableCollection<BusPO> collection;
        BusPO busPO;
        public listBusWindows()
        {
            bl = BLFactory.GetBL();
            InitializeComponent();
            updateDataContext(); //fonction for update datacontext

        }
        void updateDataContext()
        {
            collection = new ObservableCollection<BusPO>(from item in bl.GetAllBus() //get all bus from list of bus
                                                         select new BusPO(item));
            busList.DataContext = null; //and reset datacontext
            busList.DataContext = collection;
        }

        private void ButtonRefuelling_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button; //set bouton
            busPO = btn.DataContext as BusPO;//set the bus to the datacontext(line of listview)
            RefuellingWindows wnd = new RefuellingWindows(busPO.getBus());//open windows to do refuelling
            wnd.ShowDialog();
            updateDataContext();//update datacontext
        }

        private void ButtonTreatment_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;//set button
            busPO = btn.DataContext as BusPO;//set the bus to the datacontext(line of listview)
            bl.treatment(busPO.getBus());//we call the function to treat the bus
            updateDataContext();//we update the datacontext
        }

        private void busList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BusPO bus = ((FrameworkElement)e.OriginalSource).DataContext as BusPO; //set bus as datacontext(line of listview)

            if(bus != null)//if it exist
            {
                informationWindows wnd = new informationWindows(bus.getBus());//openwindow of information bus
                wnd.ShowDialog();
            }
        }
        /// <summary>
        /// button click to return to home
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
        /// button click  to return a page before
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            MainBus wnd = new MainBus();//open a page before
            wnd.Show();
            this.Close();//and close this page
        }
        /// <summary>
        /// button for update the bus of this line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;//set bus
            busPO = btn.DataContext as BusPO;//set bus of line of listview
            UpdateBus wnd = new UpdateBus(busPO.getBus());//open the page of update bus
            wnd.ShowDialog();
            updateDataContext();//and updat ethe data context
        }
        /// <summary>
        /// button for remove the line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;//set button to sender
            busPO = btn.DataContext as BusPO;//set bus to line of listview
            bl.removeBus(busPO.LicenseNum);//use remove from blimp
            updateDataContext();//and update the data context
        }

    }
}
