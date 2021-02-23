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
        IEnumerable<BO.Line> listLine;
        public Addbus(IBL bl)
        {
            InitializeComponent();
            this.bl = bl;
            bus = new BO.Bus();
            listLine = bl.getAllLine();
            lineBox.ItemsSource = listLine;
            lineBox.DisplayMemberPath = "Code";
            bus.FromDate = DateTime.Today.AddMonths(-56);//so that the displayed date is not 01/01/0001
            this.DataContext = bus;//the bus corresponds to the datacontext
            lineBox.SelectedIndex = 0;

        }
        private void ButtonAddBus_Click(object sender, RoutedEventArgs e)
        {
                    try
                    {
                        BO.Line line = lineBox.SelectedItem as BO.Line;
                        bus.BusOfLine = line.Code;
                        bus.TotalTrip = int.Parse(totalTripTextBox.Text);
                        bl.addBus(bus);//use add from blImp
                        this.Close();//close this window

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "bad entry", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
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

        private void fuelRemainTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox s = e.Source as TextBox;
                if (s != null)
                {
                    s.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                }

                e.Handled = true;
            }
        }

        private void licenseNumTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox s = e.Source as TextBox;
                if (s != null)
                {
                    s.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                }

                e.Handled = true;
            }
        }
    }
}
