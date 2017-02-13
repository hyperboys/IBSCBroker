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
using IBSC.DAL;
using IBSC.Model;
using IBSC.Common;

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
            try
            {
#if DEBUG
                MemberData member = new MemberData();
                member.MEMBER_NAME = "Debug";
                member.ROLE_CODE = "member";
                member.MEMBER_STATUS = "A";
                member.MEMBER_SURENAME = "Debug";
                member.MEMBER_USER = "Debug";
                DataCommon.Set("DATA.MEMBER", member);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
#else
                Member member = new MemberDAL().GetMember(txtUser.Text, txtPass.Password);
                if (member != null)
                {
                    if (member.MEMBER_STATUS != "I")
                    {
                        DataCommon.Set("DATA.MEMBER", member);
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                    }
                    else 
                    {
                        Alert.Content = "Member นี้อยู่ในสถานะไม่ให้ใช้งาน";
                        Alert.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    Alert.Content = "Username หรือ Password ไม่ถูกต้อง";
                    Alert.Visibility = Visibility.Visible;
                }
#endif


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtUser.Focus();
            Alert.Visibility = Visibility.Hidden;
        }

        private void txtUser_KeyUp(object sender, KeyEventArgs e)
        {
            CommonControl.KeyUp(sender, e);
        }

        private void txtPass_KeyUp(object sender, KeyEventArgs e)
        {
            CommonControl.KeyUp(sender, e);
        }
    }
}
