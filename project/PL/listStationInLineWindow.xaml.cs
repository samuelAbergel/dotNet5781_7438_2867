using BLAPI;
using PL.PO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logique d'interaction pour listStationInLineWindow.xaml
    /// </summary>
    public partial class listStationInLineWindow : Window
    {
        IBL bl;
        ObservableCollection<AdjacentStationsPO> collection;
        AdjacentStationsPO adjacentStationsPO;
        BO.Line line;
        public listStationInLineWindow(BO.Line line)
        {
            bl = BLFactory.GetBL();
            InitializeComponent();
            this.line = line;
            updateDataContext();
        }
        void updateDataContext()
        {
            collection = new ObservableCollection<AdjacentStationsPO>(from item in bl.getStationOfLine(line)
                                                         select new AdjacentStationsPO(item));
            AdjacentStationList.DataContext = null;
            AdjacentStationList.DataContext = collection;
        }
    }
}
