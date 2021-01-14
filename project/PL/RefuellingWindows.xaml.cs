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
    /// page to do refuelling
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
            txtRefuel.Text = (1200-bus.FuelRemain).ToString();//to set the textbox
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)//to press enter 
        {

            if (e.Key == Key.Return)
            {
                if (int.Parse(txtRefuel.Text) > (1200 - bus.FuelRemain))
                    MessageBox.Show(string.Format("invalid entry, you can add fuel add :" + (1200 - bus.FuelRemain)), "error", MessageBoxButton.OK, MessageBoxImage.Warning);
                else
                {
                    bl.refuelling(int.Parse(this.txtRefuel.Text), bus);//use refuzlling of blimp
                    this.Close();
                }
            }
        }

        private void Refuel_PreviewTextInput(object sender, TextCompositionEventArgs e)//to be able to write only numbers
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
