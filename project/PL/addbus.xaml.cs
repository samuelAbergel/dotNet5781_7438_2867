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
    /// add bus to windows list bus
    /// </summary>
    public partial class Addbus : Window
    {
        IBL bl;//create an instance of IBL
        BO.Bus bus;//create BO bus
        public Addbus()
        {
            InitializeComponent();
            bl = BLFactory.GetBL();//and get it with blfactory
            bus = new BO.Bus();
            this.DataContext = bus;//the bus corresponds to the datacontext
            statusComboBox.ItemsSource = Enum.GetValues(typeof(BO.BusStatus)).Cast<BO.BusStatus>();//set item source of combo box to bus statue BO

        }
        private void ButtonAddBus_Click(object sender, RoutedEventArgs e)
        {
            bl.addBus(bus);//use add from blImp
            this.Close();//close this window
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
