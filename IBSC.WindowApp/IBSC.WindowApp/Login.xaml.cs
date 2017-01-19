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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IBSC.WindowApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnSignOn_Click(object sender, RoutedEventArgs e)
        {
            Alert.Visibility = Visibility.Visible;
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtUser.Focus();
            Alert.Visibility = Visibility.Hidden;
        }

        private void txtUser_KeyUp(object sender, KeyEventArgs e)
        {
            FocusAdvancement.KeyUp(sender,e);
        }

        private void txtPass_KeyUp(object sender, KeyEventArgs e)
        {
            FocusAdvancement.KeyUp(sender, e);
        }
    }
}
