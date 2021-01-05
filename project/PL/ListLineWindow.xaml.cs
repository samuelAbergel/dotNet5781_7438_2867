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
    /// Logique d'interaction pour ListLineWindow.xaml
    /// </summary>
    public partial class ListLineWindow : Window
    {
        IBL bl;
        ObservableCollection<LinePO> collection;
        LinePO linePO;
        public ListLineWindow()
        {
            InitializeComponent();
            bl = BLFactory.GetBL();
            updateDataContext();
        }
        void updateDataContext()
        {
            collection = new ObservableCollection<LinePO>(from item in bl.getAllLine()
                                                         select new LinePO(item));
            LineList.DataContext = null;
            LineList.DataContext = collection;
        }
        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow wnd = new MainWindow();
            wnd.Show();
            this.Close();
        }

        private void ButtonPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            MainLine wnd = new MainLine();
            wnd.Show();
            this.Close();
        }

        private void LineList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
