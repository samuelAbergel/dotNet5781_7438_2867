using BLAPI;
using PL.PO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// windows of list of bus
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
            updateDataContext();//call fonction to update the data context
        }
        void updateDataContext()
        {
            collection = new ObservableCollection<BusPO>(from item in bl.GetAllBus()//get all buses from thelist
                                                         select new BusPO(item));
            busList.DataContext = null;
            busList.DataContext = collection;//and reset the data context
        }
        /// <summary>
        /// button click to refuel a bus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRefuelling_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;//set the button
            busPO = btn.DataContext as BusPO;//set the line of listview to the bus
            if (busPO.Status == BO.BusStatus.ReadyToGo)//if it's possible
            {
                RefuellingWindows wnd = new RefuellingWindows(busPO.getBus());//open the window to refuel
                wnd.ShowDialog();
                btn.IsEnabled = false;//set the button so that we cannot press
                Refuelling(busPO, 100000, btn);//call fonction to use backgroundWOrker
            }
        }

        private void Refuelling(BusPO busPO, int time, Button btn)
        {
            List<object> lst = new List<object> { busPO, time, btn };//put all data in list
            BackgroundWorker Refuelling = new BackgroundWorker();//create background worker
            Refuelling.DoWork += Refuelling_DoWork;
            Refuelling.RunWorkerCompleted += Refuelling_RunWorkedCompleted;
            Refuelling.RunWorkerAsync(lst);
        }

        private void Refuelling_RunWorkedCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<Object> lst = (List<object>)e.Result;//take the list with all data
            Button ButtonRefuelling_Click = lst[2] as Button;//set the button
            BusPO bus = lst[0] as BusPO;//set the bus
            bus.Status = BO.BusStatus.ReadyToGo;//set the statue
            ButtonRefuelling_Click.IsEnabled = true; //you can press the button
            updateDataContext();//update the data context
        }

        private void Refuelling_DoWork(object sender, DoWorkEventArgs a)
        {
            List<object> lst = (List<object>)a.Argument;//set the list with all data
            BusPO busPO = lst[0] as BusPO;//set the bus
            busPO.Status = BO.BusStatus.refueling;//set the statue
            int value = (int)lst[1];//take the value that you can't press during this period
            Thread.Sleep(10000);//wait this period
            a.Result = lst;//set the list to result
        }


        private void ButtonTreatment_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;//set the button
            busPO = btn.DataContext as BusPO;//set the bus
            if (busPO.Status == BO.BusStatus.ReadyToGo)//if it's possible
            {
                bl.treatment(busPO.getBus());//use treatment of blimp
                btn.IsEnabled = false;//you can't press the button
                Treatment(busPO, 10000, btn);//call fonction with backgroun worker
            }
        }


        private void Treatment(BusPO busPO, int time, Button btn)
        {
            List<object> lst = new List<object> { busPO, time, btn };//set all data in list
            BackgroundWorker Treatment = new BackgroundWorker();//create background worker
            Treatment.DoWork += Treatment_DoWork;
            Treatment.RunWorkerCompleted += Treatment_RunWorkedCompleted;
            Treatment.RunWorkerAsync(lst);
        }

        private void Treatment_RunWorkedCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<Object> lst = (List<object>)e.Result;//set all data in list
            Button ButtonTreatment_Click = lst[2] as Button;//set the button
            BusPO bus = lst[0] as BusPO;//set the bus
            bus.Status = BO.BusStatus.ReadyToGo;//set the statue
            ButtonTreatment_Click.IsEnabled = true;//you can press the button
            updateDataContext();//update the data context
        }
        private void Treatment_DoWork(object sender, DoWorkEventArgs a)
        {
            List<object> lst = (List<object>)a.Argument;//take all data inlist
            BusPO busPO = lst[0] as BusPO;//set bus
            busPO.Status = BO.BusStatus.inTreatment;//set statue
            int value = (int)lst[1];//set value that you can't press the button during this period
            Thread.Sleep(value);//wait this period
            a.Result = lst;//set the list in result
        }/// <summary>
        /// when you double click you opzn information window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void busList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BusPO bus = ((FrameworkElement)e.OriginalSource).DataContext as BusPO;//set the bus
            if (bus != null)//if it exist
            {
                informationWindows wnd = new informationWindows(bus.getBus());//open page withthe information
                wnd.ShowDialog();
            }
        }
        /// <summary>
        /// to go to the home
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            Opwindow wnd = new Opwindow();
            wnd.Show();
            this.Close();
        }
        /// <summary>
        /// to go to one page before
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            MainBus wnd = new MainBus();
            wnd.Show();
            this.Close();
        }
        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;//set the button
            busPO = btn.DataContext as BusPO;//set the bus
            UpdateBus wnd = new UpdateBus(busPO.getBus());//open page for update
            wnd.ShowDialog();
            updateDataContext();//and update the datacontext
        }
        /// <summary>
        /// for remove a line of listview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;//set the button
            busPO = btn.DataContext as BusPO;//set the bus
            bl.removeBus(busPO.LicenseNum);//use remove from blimp
            updateDataContext();//and update the data context
        }
    }

}