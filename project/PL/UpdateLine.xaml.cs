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
    /// Logique d'interaction pour UpdateLine.xaml
    /// </summary>
    public partial class UpdateLine : Window
    {
        IBL bl;
        BO.Line line;
        public UpdateLine(BO.Line line)
        {
            this.line = line;
            InitializeComponent();
            bl = BLFactory.GetBL();
            this.DataContext = line;
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            bl.updateLine(line);
            this.Close();
        }
    }
}
