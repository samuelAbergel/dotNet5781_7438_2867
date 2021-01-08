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
    /// Logique d'interaction pour InformationStationWindow.xaml
    /// </summary>
    public partial class InformationStationWindow : Window
    {
        IBL bl;
        BO.Station station;
        public InformationStationWindow(int stationId)
        {
            InitializeComponent();
            bl = BLFactory.GetBL();
            station = bl.getStation(stationId);
            this.DataContext = station;
        }
    }
}
