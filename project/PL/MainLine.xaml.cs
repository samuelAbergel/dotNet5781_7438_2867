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
    /// Logique d'interaction pour MainLine.xaml
    /// </summary>
    public partial class MainLine : Window
    {
        public MainLine()
        {
            InitializeComponent();
        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            Opwindow wnd = new Opwindow();
            wnd.Show();
            this.Close();
        }

        private void ButtonPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            Opwindow wnd = new Opwindow();
            wnd.Show();
            this.Close();
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            ListLineWindow wnd = new ListLineWindow();
            wnd.Show();
            this.Close();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddLine wnd = new AddLine();
            wnd.Show();
        }
    }
}
