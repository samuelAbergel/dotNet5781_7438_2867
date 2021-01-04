using BLAPI;
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
    /// Logique d'interaction pour RefuellingWindows.xaml
    /// </summary>
    public partial class RefuellingWindows : Window
    {
        IBL bl;
        BO.Bus bus;
        public RefuellingWindows(BO.Bus bus)
        {
            this.bus = bus;
            InitializeComponent();
            bl = BLFactory.GetBL();
            txtRefuel.Text = bus.FuelRemain.ToString();
            
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)//to press enter 
        {

            if (e.Key == Key.Return)
            {
                bl.refuelling(int.Parse(this.txtRefuel.Text), bus);
                this.Close();
            }
        }

        private void Refuel_PreviewTextInput(object sender, TextCompositionEventArgs e)//to be able to write only numbers
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
