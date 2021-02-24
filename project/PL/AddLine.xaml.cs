using BLAPI;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        IEnumerable<BO.LineStation> listStation;
        public AddLine(IBL bl)
        {
            InitializeComponent();
            this.bl = bl;
            line = new BO.Line();
            this.DataContext = line;//match the line with the data context
            areaComboBox.ItemsSource = Enum.GetValues(typeof(BO.Areas)).Cast<BO.Areas>();//set the itemsource of combo box to area BO(enum)
            btnAdd.IsEnabled = false;
            areaComboBox.SelectedIndex = 0;
        }
        private void update()
        {
            listStation = bl.GetLineStationsFromLine(line);//search all station in line
            StationBox.ItemsSource = listStation;//set the itemsource to thi liststation with all station pf the line
            StationBox.DisplayMemberPath = "Station";//i want that the combobox display name of station
        }
        private void ButtonAddLine_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IEnumerable<LineStation> lst = bl.GetLineStationsFromLine(line);
                line.Area = (BO.Areas)Enum.Parse(typeof(BO.Areas), areaComboBox.SelectedItem.ToString());
                bl.addLine(line);//use add from blimp
                bl.addLineTrip(line.Code);
                this.Close();//close this window
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "bad entry", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        private void Refuel_PreviewTextInput(object sender, TextCompositionEventArgs e)//to be able to write only numbers
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        /// <summary>
        /// when i want to add station to this line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddStationLine_Click(object sender, RoutedEventArgs e)
        {
            bool flag = true;
            flag = int.TryParse(codeTextBox.Text, out int a);
            if (flag)
            {
                if (codeTextBox.Text != "0")
                {
                    if (bl.isLineExisting(line))
                    {
                        ChooseLineStation wnd = new ChooseLineStation(line, bl);// i open list of station to add 
                        wnd.ShowDialog();
                        if (bl.GetLineStationsFromLine(line).Count() != 0)//if there is a station
                        {
                            codeTextBox.IsEnabled = false;
                            btnAdd.IsEnabled = true;// i can add this line
                            update();//and update it 
                            StationBox.IsEnabled = true;// and i can see all station that i have add
                            StationBox.SelectedIndex = 0;

                        }
                    }
                    else
                        MessageBox.Show("this line already exist", "information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("you must fill in the code field to add stations", "information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("code or id too long", "bad entry", MessageBoxButton.OK, MessageBoxImage.Information);
           
              

        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            if(bl.getLine(int.Parse(codeTextBox.Text)) == null)//if you don't add this line delete all line station ceated
            {
                bl.removeAllLineStationOfLine(int.Parse(codeTextBox.Text));
            }
            this.Close();
            }
            catch (Exception)
            {
                this.Close();
            }

        }

        private void codeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox s = e.Source as TextBox;
                if (s != null)
                {
                    s.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                }

                e.Handled = true;
            }
        }

        private void idTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox s = e.Source as TextBox;
                if (s != null)
                {
                    s.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                }

                e.Handled = true;
            }
        }
    }
}
