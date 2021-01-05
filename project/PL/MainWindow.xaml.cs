using BL;
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
    /// Logique d'interaction pour page2.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL bl;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBus_Click(object sender, RoutedEventArgs e)
        {
            MainBus wnd = new MainBus();
            wnd.Show();
            this.Close();
        }

        private void ButtonLine_Click_1(object sender, RoutedEventArgs e)
        {
            MainLine wnd = new MainLine();
            wnd.Show();
            this.Close();
        }
    }
}
