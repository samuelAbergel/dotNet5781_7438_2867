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
    /// main page of sttaion
    /// </summary>
    public partial class MainStation : Window
    {
        IBL bl;
        public MainStation(IBL bl)
        {
            this.bl = bl;
            InitializeComponent();
        }
        /// <summary>
        /// to go to the home
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            Opwindow wnd = new Opwindow(bl);
            wnd.Show();
            this.Close();
        }
        /// <summary>
        /// to go one page before
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            Opwindow wnd = new Opwindow(bl);
            wnd.Show();
            this.Close();
        }
        /// <summary>
        /// to go to page for search station
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            ListStationWindows wnd = new ListStationWindows(bl);
            wnd.Show();
            this.Close();
        }
        /// <summary>
        /// to go to page for add station
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            addStation wnd = new addStation(bl);
            this.Hide();
            wnd.ShowDialog();
            this.Show();
        }

     
    }
}
