using IBSC.Common;
using IBSC.DAL;
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

namespace IBSC.WindowApp
{
    /// <summary>
    /// Interaction logic for PopupUser.xaml
    /// </summary>
    public partial class PopupUser : Window
    {
        private Member member;
        public PopupUser()
        {
            InitializeComponent();
            member = (Member)DataCommon.Get("DATA.MEMBER");
            lblUsername.Content = member.MEMBER_USER;
        }

        private void btnConfrim_Click(object sender, RoutedEventArgs e)
        {
            if (!new MemberDAL().SingOn(lblUsername.Content.ToString(), txtOldPassword.Password))
            {
                this.Alert.Content = "รหัสผ่านเก่าไม่ถูกต้อง";
                this.Alert.Visibility = System.Windows.Visibility.Visible;
                return;
            }
            else if(txtOldPassword.Password.Equals(txtNewPassword.Password))
            {
                this.Alert.Content = "รหัสผ่านเก่ากับรหัสผ่านใหม่ตรงกัน";
                this.Alert.Visibility = System.Windows.Visibility.Visible;
                return;
            }
            else if (!txtNewPassword.Password.Equals(txtConNewPassword.Password))
            {
                this.Alert.Content = "คอนเฟิร์มรหัสผ่านใหม่ไม่ถูกต้อง";
                this.Alert.Visibility = System.Windows.Visibility.Visible;
                return;
            }
            else if (MessageBox.Show("ยืนยันการเปลี่ยนรหัสผ่าน", "เปลี่ยนรหัสผ่าน", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                member.MEMBER_PASSWORD = txtNewPassword.Password;
                new MemberDAL().UpdateMember(member);
                DataCommon.Set("DATA.MEMBER",member);
                this.Close();
            }
        }
    }
}
