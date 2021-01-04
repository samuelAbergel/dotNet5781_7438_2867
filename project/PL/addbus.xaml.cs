using BLAPI;
using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour addbus.xaml
    /// </summary>
    public partial class addbus : Window
    {
        IBL bl;
        BO.Bus bus;
        public addbus()
        {
            InitializeComponent();
            bl = BLFactory.GetBL();
            bus = new BO.Bus();
            this.DataContext = bus;
            statusComboBox.ItemsSource = Enum.GetValues(typeof(BO.BusStatus));

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bl.addBus(bus);
            this.Close();
        }

       
    }
}
