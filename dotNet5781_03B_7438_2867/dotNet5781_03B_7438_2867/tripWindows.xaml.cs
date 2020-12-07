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

namespace dotNet5781_03B_7438_2867
{
    /// <summary>
    /// Logique d'interaction pour tripWindows.xaml
    /// </summary>
    public partial class tripWindows : Window
    {

        public tripWindows(Bus bus)
        {
            InitializeComponent();
            this.DataContext = bus;

        }
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Return)
            {
                this.Close();
            }
        }

        private void gasolTrip_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
