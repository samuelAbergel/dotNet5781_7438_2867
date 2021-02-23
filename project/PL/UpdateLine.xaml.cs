using BLAPI;
using BO;
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
    /// Logique d'interaction pour UpdateLine.xaml
    /// </summary>
    public partial class UpdateLine : Window
    {
        IBL bl;
        BO.Line line;
        IEnumerable<LineStation> listStation;
        public UpdateLine(BO.Line line, IBL bl)
        {
            this.line = line;
            InitializeComponent();
            this.bl = bl;
            this.DataContext = line;//set the data context
            areaComboBox.ItemsSource = Enum.GetValues(typeof(BO.Areas)).Cast<BO.Areas>();//set the itemsource of combo box to area BO(enum)
            areaComboBox.SelectedIndex = (int)line.Area;
            update();
            if (listStation == null)
                StationBox.IsEnabled = false;
        }
        private void update()
        {
            listStation = bl.GetLineStationsFromLine(line);//search all station in line
            StationBox.ItemsSource = listStation;//set the itemsource to thi liststation with all station pf the line
            StationBox.DisplayMemberPath = "Station";//i want that the combobox display name of station
        }
        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            line.Area = (BO.Areas)areaComboBox.SelectedItem;
            bl.updateLine(line);//use the update of blimp
            bl.updateLineTrip(bl.getLineTrip(line.Code));
            this.Close();//and close this page
        }
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonAddStationLine_Click(object sender, RoutedEventArgs e)
        {

            ChooseLineStation wnd = new ChooseLineStation(line,bl);// i open list of station to add 
            wnd.ShowDialog();
            if (bl.GetLineStationsFromLine(line).Count() != 0)//if there is a station
            {
                update();//and update it 
                StationBox.IsEnabled = true;// and i can see all station that i have add
            }
        }
    }
}
