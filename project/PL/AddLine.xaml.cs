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
    /// Logique d'interaction pour AddLine.xaml
    /// </summary>
    public partial class AddLine : Window
    {
        IBL bl;
        BO.Line line;
        public AddLine()
        {
            InitializeComponent();
            bl = BLFactory.GetBL();
            line = new BO.Line();
            this.DataContext = line;
            areaComboBox.ItemsSource = Enum.GetValues(typeof(BO.Areas)).Cast<BO.Areas>();
        }
        private void ButtonAddLine_Click(object sender, RoutedEventArgs e)
        {
            bl.addLine(line);
            this.Close();
        }
    }
}
