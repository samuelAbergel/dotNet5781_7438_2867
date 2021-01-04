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
      //  IEnumerable<BO.Bus> listBus;
        ObservableCollection<BusPO> collection;
        BusPO busPO;
        public listBusWindows()
        {
            bl = BLFactory.GetBL();
            InitializeComponent();
            updateDataContext();

             // bus = new BO.Bus();
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
    }
}
