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
    /// main page
    /// </summary>
    public partial class Opwindow : Window
    {
        IBL bl;
        public Opwindow(IBL bl)
        {
            InitializeComponent();
            this.bl = bl;
        }
        /// <summary>
        /// to go to page of main bus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBus_Click(object sender, RoutedEventArgs e)
        {
            MainBus wnd = new MainBus(bl);
            wnd.Show();
            this.Close();
        }
        /// <summary>
        /// to go to page of main line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLine_Click_1(object sender, RoutedEventArgs e)
        {
            MainLine wnd = new MainLine(bl);
            wnd.Show();
            this.Close();
        }
        /// <summary>
        /// to go to page of main station
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonStation_Click(object sender, RoutedEventArgs e)
        {
            MainStation wnd = new MainStation(bl);
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
