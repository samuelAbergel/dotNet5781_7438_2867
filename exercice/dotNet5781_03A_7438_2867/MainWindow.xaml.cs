using dotNet5781_02_7438_2867;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dotNet5781_03A_7438_2867
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<BusLine> busLines;
        private BusLine currentDisplayBusLine;
        static Random rnd = new Random();
        public MainWindow()
        {
            InitializeComponent();
            initBuses();
            initComboBox();
        }

        private void initComboBox()
        {
            cbBusLines.ItemsSource = busLines;
            cbBusLines.DisplayMemberPath = "LineNumber";
            cbBusLines.SelectedIndex = 0;
            ShowBusLine(((BusLine)cbBusLines.SelectedItem).LineNumber);
        }
        private void cbBusLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowBusLine((cbBusLines.SelectedValue as BusLine).LineNumber);
        }

        private void ShowBusLine(int busLineNum)
        {
            currentDisplayBusLine = busLines[returnIndex(busLineNum)];
            UpGrid.DataContext = currentDisplayBusLine;
            lbBusLineStations.DataContext = currentDisplayBusLine.Line;
        }
        private int returnIndex(int a)
        {
            for (int i = 0; i < busLines.Count; i++)
                if (busLines[i].LineNumber == a)
                    return i;
            return 0;
        }
        private void initBuses()
        {
            Random rnd = new Random();
            busLines = new List<BusLine>();
            for (int i = 0; i < 10; i++)
            {
                Area area = returnArea();
                busLines.Add(new BusLine(rnd.Next(100), area));
                for (int j = 0; j < 4; j++)
                {
                    busLines[i].AddStation(j, new BusLineStation(rnd.Next(999999)));
                }
            }
        }

        public Area returnArea()
        {
            Area area;
            bool success;
            string tostring = "";
            int index;
            index = rnd.Next(0, 4);
            switch (index)
            {
                case 0:
                    tostring = "GENERAL";
                    break;
                case 1:
                    tostring = "NORTH";
                    break;
                case 2:
                    tostring = "SOUTH";
                    break;
                case 3:
                    tostring = "CENTER";
                    break;
                case 4:
                    tostring = "JERUSALEM";
                    break;
                default:
                    break;
            }
            success = Enum.TryParse(tostring, out area);
            return area;
        }
    }
}
