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
    /// add station to list of sttaaaaaaion
    /// </summary>
    public partial class addStation : Window
    {
        IBL bl;//create instance of IBL
        BO.Station station;
        public addStation()
        {
            InitializeComponent();
            bl = BLFactory.GetBL();//and get it with blfactory
            station = new BO.Station();
            this.DataContext = station;//match datacontext with the instance of  station
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (bl.isStationExisting(int.Parse(codeTextBox.Text)))
            {
                bl.addStation(station);//use add of bl imp
                this.Close();//close this window
            }
            else
                MessageBox.Show("this station code already exist", "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
