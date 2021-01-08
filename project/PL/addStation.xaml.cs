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
    /// Logique d'interaction pour addStation.xaml
    /// </summary>
    public partial class addStation : Window
    {
        IBL bl;
        BO.AdjacentStations adjacentStations;
        public addStation()
        {
            InitializeComponent();
            bl = BLFactory.GetBL();
            adjacentStations = new BO.AdjacentStations();
            this.DataContext = adjacentStations;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            bl.addAdjacentStation(adjacentStations);
            this.Close();
        }
    }
}
