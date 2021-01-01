using BL;
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
    /// Logique d'interaction pour page3.xaml
    /// </summary>
    public partial class page3 : Window
    {

        BO.Bus bus;
        public page3(IBL bl)
        {
            InitializeComponent();
            bus = new BO.Bus();
        }


    }
}
