﻿using BLAPI;
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
    /// Logique d'interaction pour UpdateBus.xaml
    /// </summary>
    public partial class UpdateBus : Window
    {
        IBL bl;
        BO.Bus bus;
        public UpdateBus(BO.Bus bus)
        {
            this.bus = bus;
            InitializeComponent();
            bl = BLFactory.GetBL();
            this.DataContext = bus;
            statusComboBox.ItemsSource = Enum.GetValues(typeof(BO.BusStatus)).Cast<BO.BusStatus>();
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            bl.updateBus(bus);
            this.Close();
        }
    }
}