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
        BO.AdjacentStations adjacentStations;
        public addStation()
        {
            InitializeComponent();
            bl = BLFactory.GetBL();//and get it with blfactory
            adjacentStations = new BO.AdjacentStations();
            this.DataContext = adjacentStations;//match datacontext with the instance of adjacent station
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            bl.addAdjacentStation(adjacentStations);//use add of bl imp
            this.Close();//close this window
        }
    }
}
