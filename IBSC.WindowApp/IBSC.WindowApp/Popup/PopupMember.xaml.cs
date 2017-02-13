using IBSC.Common;
using IBSC.DAL;
using IBSC.Model;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace IBSC.WindowApp.Popup
{
    /// <summary>
    /// Interaction logic for PopupMember.xaml
    /// </summary>
    public partial class PopupMember : Window
    {
        private MemberData member;
        public PopupMember()
        {
            try
            {
                InitializeComponent();
                if (DataCommon.Exists("MEMBER_EDIT"))
                {
                    member = (MemberData)DataCommon.Get("MEMBER_EDIT");
                    txtName.Text = member.MEMBER_NAME;
                    txtSureName.Text = member.MEMBER_SURENAME;
                    txtUser.Text = member.MEMBER_USER;
                    cbbRole.SelectedIndex = member.ROLE_CODE.ToUpper() == "ADMIN" ? 1 : 2;
                    cbbStatus.SelectedIndex = member.MEMBER_STATUS == "A" ? 0 : 1;
                }
                else
                {
                    txtUser.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("ยืนยันการบันทึกข้อมูล", "การบันทึกข้อมูล", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    bool complete = false;
                    MemberDAL dal = new MemberDAL();
                    if (cbbRole.Text.Equals("กรุณาเลือก"))
                    {
                        MessageBox.Show("กรุณาเลือก Role ก่อนบันทึก");
                        return;
                    }
                    if (DataCommon.Exists("MEMBER_EDIT"))
                    {
                        member = (MemberData)DataCommon.Get("MEMBER_EDIT");
                        member.MEMBER_NAME = txtName.Text;
                        member.ROLE_CODE = cbbRole.Text.ToLower();
                        member.MEMBER_STATUS = cbbStatus.Text == "ใช้งาน" ? "A" : "I";
                        member.MEMBER_SURENAME = txtSureName.Text;
                        dal.UpdateMember(member);
                        DataCommon.Remove("MEMBER_EDIT");
                        complete = true;
                    }
                    else
                    {
                        if (dal.GetMember(txtUser.Text) == null)
                        {
                            member = new MemberData();
                            member.MEMBER_NAME = txtName.Text;
                            member.ROLE_CODE = cbbRole.Text.ToLower();
                            member.MEMBER_STATUS = cbbStatus.Text == "ใช้งาน" ? "A" : "I";
                            member.MEMBER_SURENAME = txtSureName.Text;
                            member.MEMBER_PASSWORD = txtUser.Text;
                            member.MEMBER_USER = txtUser.Text;
                            new MemberDAL().InsertMember(member);
                            complete = true;
                        }
                        else
                        {
                            MessageBox.Show("Username นี้ซ้ำในระบบ กรุณาเปลี่ยน Username");
                        }
                    }
                    if (complete)
                    {
                        MessageBox.Show("บันทึกข้อมูลสำเร็จ");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
