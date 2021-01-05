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
    /// Logique d'interaction pour page4.xaml
    /// </summary>
    public partial class MainBus : Window
    {
        public MainBus()
        {
            InitializeComponent();
        }
        
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Addbus wnd = new Addbus();
            wnd.Show();
            this.Close();
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            listBusWindows wnd = new listBusWindows();
            wnd.Show();
            this.Close();
        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow wnd = new MainWindow();
            wnd.Show();
            this.Close();
        }

        private void ButtonPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow wnd = new MainWindow();
            wnd.Show();
            this.Close();
        }
    }
}
