using BLAPI;
using BO;
using System;
using System.Collections.Generic;
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
using System.Windows.Threading;

namespace PL
{
    /// <summary>
    /// Logique d'interaction pour Time.xaml
    /// </summary>
    public partial class Time : Window
    {
       
        IBL bl;
        public Time(IBL bl)
        {
            InitializeComponent();
            this.bl = bl;
        }
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            if (firstStationTextBox.Text != "" && WithSecondsTimePicker.SelectedTime.Value.TimeOfDay != null)
            {
                clock.Instance.rate = int.Parse(firstStationTextBox.Text);
                clock.Instance.startTime = WithSecondsTimePicker.SelectedTime.Value.TimeOfDay;
                this.Close();
            }
            else
                MessageBox.Show("you must fill the rate and hours", "information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
       
    }
}
