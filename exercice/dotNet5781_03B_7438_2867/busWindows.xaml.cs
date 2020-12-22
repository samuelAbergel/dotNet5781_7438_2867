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

namespace dotNet5781_03B_7438_2867
{
    /// <summary>
    /// Logique d'interaction pour busWindows.xaml
    /// </summary>
    public partial class busWindows : Window
    {
        Bus myBus;
        public busWindows()
        {
            InitializeComponent();
            myBus = new Bus();

            this.DataContext = myBus;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListBuses.GetListBuses().AddBus(myBus);
            this.Close();
        }
    }
}
