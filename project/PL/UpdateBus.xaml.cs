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
    /// Logique d'interaction pour UpdateBus.xaml
    /// </summary>
    public partial class UpdateBus : Window
    {
        IBL bl;
        BO.Bus bus;
        public UpdateBus(BO.Bus bus)
        {
            this.bus = bus;
            InitializeComponent();
            bl = BLFactory.GetBL();
            this.DataContext = bus;//set the datacontext
            statusComboBox.ItemsSource = Enum.GetValues(typeof(BO.BusStatus)).Cast<BO.BusStatus>();///set the combobox to busstatue
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            int result;
            bool success = int.TryParse(fuelRemainTextBox.Text, out result);
            if (result <= 1200 && success)
            { 
                bl.updateBus(bus);//use the update of blimp
                this.Close();//and close this page
            }
            else
                MessageBox.Show("bad entry", "bad entry", MessageBoxButton.OK, MessageBoxImage.Warning);
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
