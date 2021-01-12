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
    public partial class MainWindow : Window
    {

        IBL bl = BLFactory.GetBL();
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// button to open the next
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Opwindow wnd = new Opwindow();
            wnd.Show();
            this.Close();
        }
        /// <summary>
        /// button to close all
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
