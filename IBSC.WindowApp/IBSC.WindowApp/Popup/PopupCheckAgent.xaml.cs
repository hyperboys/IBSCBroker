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
    /// Interaction logic for PopupCheckAgent.xaml
    /// </summary>
    public partial class PopupCheckAgent : Window
    {
        CheckInsureCarData item;
        MemberData member;
        public PopupCheckAgent()
        {
            try
            {
                InitializeComponent();
                item = (CheckInsureCarData)DataCommon.Get("CHECK_INSURE_CAR_EDIT");
                txtDate.Text = item.CREATE_DATE.ToString();
                txtEMail.Text = item.AGENT_EMAIL;
                txtName.Text = item.AGENT_NAME;
                txtTel.Text = item.AGENT_TEL + "," + item.AGENT_PHONE;
                txtAgentCode.Text = item.AGENT_CODE;
                member = (MemberData)DataCommon.Get("DATA.MEMBER");
                if (member.ROLE_CODE.Equals("admin"))
                {
                    btnCancel.Visibility = System.Windows.Visibility.Hidden;
                    btnSave.Visibility = System.Windows.Visibility.Hidden;
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
                    item.REMARK = txtRemark.Text;
                    item.SELECT_INSURANCE_STATUS = "03";
                    new CheckInsureCarDAL().UpdateComplete(item);
                    MessageBox.Show("บันทึกข้อมูลสำเร็จ");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            InsureCarData insureItem = new InsureCarDAL().GetItem(item.INSURE_CAR_CODE);
            DataCommon.Set("INSURE_CAR_EDIT", insureItem);
            PopupInsureCar popup = new PopupInsureCar("VIEW");
            popup.Show();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("ยืนยันการบันทึกข้อมูล", "การบันทึกข้อมูล", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    item.REMARK = txtRemark.Text;
                    item.SELECT_INSURANCE_STATUS = "04";
                    new CheckInsureCarDAL().UpdateComplete(item);
                    MessageBox.Show("บันทึกข้อมูลสำเร็จ");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
