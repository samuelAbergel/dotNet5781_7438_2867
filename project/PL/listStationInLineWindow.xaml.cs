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
    /// this window display list of station in line
    /// </summary>
    public partial class listStationInLineWindow : Window
    {
        IBL bl;
        ObservableCollection<StationPO> collection;
        StationPO stationPO;
        BO.Line line;
        public listStationInLineWindow(BO.Line line)
        {
            bl = BLFactory.GetBL();
            InitializeComponent();
            this.line = line;
            updateDataContext();//call fonction to update the data context
        }
        void updateDataContext()
        {
            collection = new ObservableCollection<StationPO>(from item in bl.getStationOfLine(line)//get all station of list of station
                                                         select new StationPO(item));
            StationList.DataContext = null;
            StationList.DataContext = collection;//and reset the data context
        }

    }
}
