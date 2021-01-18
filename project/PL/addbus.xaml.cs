using BLAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            int result;
            bool success = int.TryParse(fuelRemainTextBox.Text, out result);
            if (bl.isBusExisting(int.Parse(licenseNumTextBox.Text)))
            {
                if (result <= 1200 && success)
                {
                    bl.addBus(bus);//use add from blImp
                    this.Close();//close this window
                }
                else
                    MessageBox.Show("bad entry", "bad entry", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
                MessageBox.Show("this liscence num already exist", "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        private void Refuel_PreviewTextInput(object sender, TextCompositionEventArgs e)//to be able to write only numbers
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
