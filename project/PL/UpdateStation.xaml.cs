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
    /// Logique d'interaction pour UpdateStation.xaml
    /// </summary>
    public partial class UpdateStation : Window
    {
        IBL bl;
        BO.Station Stations;
        public UpdateStation(int idStation)
        {
            InitializeComponent();
            bl = BLFactory.GetBL();
            Stations = bl.getStation(idStation);
            this.DataContext = Stations;
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            bl.updateStation(Stations);
            this.Close();
        }
    }
}
