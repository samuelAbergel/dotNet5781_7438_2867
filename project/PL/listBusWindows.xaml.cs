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
            updateDataContext();

        }
        void updateDataContext()
        {
            collection = new ObservableCollection<BusPO>(from item in bl.GetAllBus()
                                                         select new BusPO(item));
            busList.DataContext = null;
            busList.DataContext = collection;
        }

        private void ButtonRefuelling_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            busPO = btn.DataContext as BusPO;
            RefuellingWindows wnd = new RefuellingWindows(busPO.getBus());
            wnd.ShowDialog();
            updateDataContext();
        }

        private void ButtonTreatment_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            busPO = btn.DataContext as BusPO;
            bl.treatment(busPO.getBus());
            updateDataContext();
        }

        private void busList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BusPO bus = ((FrameworkElement)e.OriginalSource).DataContext as BusPO;

            if(bus != null)
            {
                informationWindows wnd = new informationWindows(bus.getBus());
                wnd.ShowDialog();
            }
        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            Opwindow wnd = new Opwindow();
            wnd.Show();
            this.Close();
        }

        private void ButtonPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            MainBus wnd = new MainBus();
            wnd.Show();
            this.Close();
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            busPO = btn.DataContext as BusPO;
            UpdateBus wnd = new UpdateBus(busPO.getBus());
            wnd.ShowDialog();
            updateDataContext();
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            busPO = btn.DataContext as BusPO;
            bl.removeBus(busPO.LicenseNum);
            updateDataContext();
        }

        private void busList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
