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
using BO;

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

        private void LineList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            LinePO linePO = ((FrameworkElement)e.OriginalSource).DataContext as LinePO;
            if (linePO != null && linePO.listOfStationInLine != null)
            {
                listStationInLineWindow wnd = new listStationInLineWindow(linePO.getLine());
                wnd.ShowDialog();
            }
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            LinePO linePO= btn.DataContext as LinePO;
            bl.removeLine(linePO.Id);
            updateDataContext();
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            LinePO linePO = btn.DataContext as LinePO;
            UpdateLine wnd = new UpdateLine(linePO.getLine());
            wnd.ShowDialog();
            updateDataContext();
        }
    }
}
