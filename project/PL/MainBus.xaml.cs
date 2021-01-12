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
    ///home page of bus
    /// </summary>
    public partial class MainBus : Window
    {
        public MainBus()
        {
            InitializeComponent();
        }
        /// <summary>
        /// button to open page page to add a bus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Addbus wnd = new Addbus();//open window to add bus
            wnd.Show();
        }
        /// <summary>
        /// open page to search bus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            listBusWindows wnd = new listBusWindows();//open page to search bus
            wnd.Show();
            this.Close();//and close this page
        }
        /// <summary>
        /// button to go to the window home
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            Opwindow wnd = new Opwindow();
            wnd.Show();
            this.Close();
        }
        /// <summary>
        /// button to go one page before
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            Opwindow wnd = new Opwindow();
            wnd.Show();
            this.Close();
        }
    }
}
