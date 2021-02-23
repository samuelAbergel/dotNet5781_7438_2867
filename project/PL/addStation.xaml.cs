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
    /// add station to list of sttaaaaaaion
    /// </summary>
    public partial class addStation : Window
    {
        IBL bl;//create instance of IBL
        BO.Station station;
        public addStation(IBL bl)
        {
            InitializeComponent();
            this.bl = bl;
            station = new BO.Station();
            this.DataContext = station;//match datacontext with the instance of  station
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.addStation(station);//use add of bl imp
                this.Close();//close this window
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);
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

        private void codeTextBox_KeyDown(object sender, KeyEventArgs e)
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

        private void lattitudeTextBox_KeyDown(object sender, KeyEventArgs e)
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

        private void longitudeTextBox_KeyDown(object sender, KeyEventArgs e)
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
