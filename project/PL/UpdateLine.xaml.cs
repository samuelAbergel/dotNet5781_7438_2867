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
        IEnumerable<Station> listStation;
        public UpdateLine(BO.Line line)
        {
            this.line = line;
            InitializeComponent();
            bl = BLFactory.GetBL();
            this.DataContext = line;//set the data context
            update();
            if (listStation == null)
                StationBox.IsEnabled = false;
        }
        private void update()
        {
            listStation = bl.getStationOfLine(line);//search all station in line
            StationBox.ItemsSource = listStation;//set the itemsource to thi liststation with all station pf the line
            StationBox.DisplayMemberPath = "Name";//i want that the combobox display name of station
        }
        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            bl.updateLine(line);//use the update of blimp
            this.Close();//and close this page
        }
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonAddStationLine_Click(object sender, RoutedEventArgs e)
        {

            ListStationWindows wnd = new ListStationWindows(line, 2, string.Empty);// i open list of station to add 
            wnd.ShowDialog();
            line.listOfStationInLine = line.listOfStationInLine.Where(p => p.Code != 0);//i take the new line but i'm remove the fisrt station that I added so that the list is not null
            if (line.listOfStationInLine != null && line.listOfStationInLine.Count() != 0)//if there is a station
            {
                update();//and update it 
                StationBox.IsEnabled = true;// and i can see all station that i have add
            }
        }
    }
}
