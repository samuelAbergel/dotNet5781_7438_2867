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
    /// Logique d'interaction pour Mail.xaml
    /// </summary>
    public partial class Mail : Window
    {
        IBL bl;
        public Mail(IBL bl)
        {
            InitializeComponent();
            this.bl = bl;
        }
        private void OnKeyDownHandler(object sender, KeyEventArgs e)//to press enter 
        {
            try
            {
              if (e.Key == Key.Return)
              {
                try
                {
                    bl.SignIn(txtMail.Text);
                    MessageBox.Show("your mail was add successfully","password",MessageBoxButton.OK, MessageBoxImage.Information);
                        MainWindow wnd = new MainWindow();
                        wnd.Show();
                        this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "bad entry", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
              }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "bad entry", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
