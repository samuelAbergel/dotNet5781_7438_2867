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
        IBL bl;// create instance of IBL
        BO.Station station;
        IEnumerable<BO.Line> lineList;
        public InformationStationWindow(int stationId)
        {
            InitializeComponent();
            bl = BLFactory.GetBL();//and get it with blfactory
            station = bl.getStation(stationId);//use getstation of blimp and put in station
            lineList = bl.getLineOfStation(station);
            this.DataContext = station;//match datacontext and station
            lineBox.ItemsSource = lineList;
            lineBox.DisplayMemberPath = "Code";
        }
    }
}
