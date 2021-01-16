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
    /// add line to window of list line
    /// </summary>
    public partial class AddLine : Window
    {
        IBL bl;//create instance of IBL
        BO.Line line;
        IEnumerable<Station> listStation;
        public AddLine()
        {
            InitializeComponent();
            bl = BLFactory.GetBL();// and get it with blFactory
            line = new BO.Line();
            this.DataContext = line;//match the line with the data context
            areaComboBox.ItemsSource = Enum.GetValues(typeof(BO.Areas)).Cast<BO.Areas>();//set the itemsource of combo box to area BO(enum)
            btnAdd.IsEnabled = false;
        }
        private void update()
        {
            listStation = bl.getStationOfLine(line);
            StationBox.ItemsSource = listStation;
            StationBox.DisplayMemberPath = "Name";
        }
        private void ButtonAddLine_Click(object sender, RoutedEventArgs e)
        {
            bl.addLine(line);//use add from blimp
            this.Close();//close this window
        }

        private void ButtonAddStationLine_Click(object sender, RoutedEventArgs e)
        {
            ListStationWindows wnd = new ListStationWindows(line, 2);
            wnd.ShowDialog();
            line.listOfStationInLine = line.listOfStationInLine.Where(p => p.Code != 0);
            if (line.listOfStationInLine != null && line.listOfStationInLine.Count() != 0 )
            {
                btnAdd.IsEnabled = true;
                update();
                StationBox.IsEnabled = true;
            }
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
