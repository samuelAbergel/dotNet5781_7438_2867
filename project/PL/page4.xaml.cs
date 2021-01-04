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
    public partial class page4 : Window
    {

        public page4()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            addbus wnd = new addbus();
            wnd.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            listBusWindows wnd = new listBusWindows();
            wnd.ShowDialog();
        }
    }
}
