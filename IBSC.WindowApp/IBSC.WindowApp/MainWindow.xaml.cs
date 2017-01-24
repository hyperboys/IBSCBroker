using IBSC.Common;
using IBSC.Model;
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
using System.Windows.Threading;

namespace IBSC.WindowApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Member member;
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                this.dateText.Content = DateTime.Now.ToString("HH:mm:ss");
            }, this.Dispatcher);

            member = (Member)DataCommon.Get("DATA.MEMBER");
            lblName.Content = member.MEMBER_NAME + " " + member.MEMBER_SURENAME;
            lblUsername.Content = member.MEMBER_USER;

            if (!member.MEMBER_ROLE.Equals("admin")) 
            {
                btnMember.Visibility = System.Windows.Visibility.Hidden;
                btnInsureCompany.Visibility = System.Windows.Visibility.Hidden;
                btnCar.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PopupChangePassword popup = new PopupChangePassword();
            popup.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Login l = new Login();
            l.Show();
        }

        private void btnInsureCompany_Click(object sender, RoutedEventArgs e)
        {
            this.pageCar.Visibility = System.Windows.Visibility.Hidden;
            this.pageCheckInsure.Visibility = System.Windows.Visibility.Hidden;
            this.pageInsure.Visibility = System.Windows.Visibility.Visible;
            this.pageInsureCar.Visibility = System.Windows.Visibility.Hidden;
            this.pageMember.Visibility = System.Windows.Visibility.Hidden;
        }

        private void btnCar_Click(object sender, RoutedEventArgs e)
        {
            this.pageCar.Visibility = System.Windows.Visibility.Visible;
            this.pageCheckInsure.Visibility = System.Windows.Visibility.Hidden;
            this.pageInsure.Visibility = System.Windows.Visibility.Hidden;
            this.pageInsureCar.Visibility = System.Windows.Visibility.Hidden;
            this.pageMember.Visibility = System.Windows.Visibility.Hidden;
        }

        private void btnInsure_Click(object sender, RoutedEventArgs e)
        {
            this.pageCar.Visibility = System.Windows.Visibility.Hidden;
            this.pageCheckInsure.Visibility = System.Windows.Visibility.Hidden;
            this.pageInsure.Visibility = System.Windows.Visibility.Hidden;
            this.pageInsureCar.Visibility = System.Windows.Visibility.Visible;
            this.pageMember.Visibility = System.Windows.Visibility.Hidden;
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            this.pageCar.Visibility = System.Windows.Visibility.Hidden;
            this.pageCheckInsure.Visibility = System.Windows.Visibility.Visible;
            this.pageInsure.Visibility = System.Windows.Visibility.Hidden;
            this.pageInsureCar.Visibility = System.Windows.Visibility.Hidden;
            this.pageMember.Visibility = System.Windows.Visibility.Hidden;
        }

        private void btnMember_Click(object sender, RoutedEventArgs e)
        {
            this.pageCar.Visibility = System.Windows.Visibility.Hidden;
            this.pageCheckInsure.Visibility = System.Windows.Visibility.Hidden;
            this.pageInsure.Visibility = System.Windows.Visibility.Hidden;
            this.pageInsureCar.Visibility = System.Windows.Visibility.Hidden;
            this.pageMember.Visibility = System.Windows.Visibility.Visible;
        }

    }
}
