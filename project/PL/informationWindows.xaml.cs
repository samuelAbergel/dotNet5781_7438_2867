using BLAPI;
using PL.PO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logique d'interaction pour informationWindows.xaml
    /// </summary>
    public partial class informationWindows : Window
    {
        public informationWindows(BO.Bus bus, IBL bl)
        {
            InitializeComponent();
            this.DataContext = bus; //match data context and bus
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
