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
    /// Interaction logic for PopupCompanyInsure.xaml
    /// </summary>
    public partial class PopupCompanyInsure : Window
    {
        private InsureCompanyData item;
        public PopupCompanyInsure()
        {
            try
            {
                InitializeComponent();
                if (DataCommon.Exists("COMPANY_EDIT"))
                {
                    item = (InsureCompanyData)DataCommon.Get("COMPANY_EDIT");
                    txtCompantCode.Text = item.COMPANY_CODE;
                    txtCompantFullName.Text = item.COMPANY_FULLNAME;
                    //txtPicPath.Text = item.COMPANY_PATH_PIC;
                    txtRemark.Text = item.COMPANY_REMARK;
                    //txtShortName.Text = item.COMPANY_SHORTNAME;
                    cbbStatus.SelectedIndex = item.COMPANY_STATUS == "A" ? 0 : 1;
                }
                else
                {
                    txtCompantCode.IsEnabled = true;
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
                if (txtCompantCode.Text == "")
                {
                    MessageBox.Show("กรุณากรอก รหัสบริษัท");
                    return;
                }
                if (txtCompantFullName.Text == "")
                {
                    MessageBox.Show("กรุณากรอก ชื่อเต็มบริษัท");
                    return;
                }
                if (MessageBox.Show("ยืนยันการบันทึกข้อมูล", "การบันทึกข้อมูล", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    bool complete = false;
                    InsureCompanyDAL dal = new InsureCompanyDAL();
                    if (DataCommon.Exists("COMPANY_EDIT"))
                    {
                        item = (InsureCompanyData)DataCommon.Get("COMPANY_EDIT");
                        item.COMPANY_CODE = txtCompantCode.Text;
                        item.COMPANY_FULLNAME = txtCompantFullName.Text;
                        item.COMPANY_PATH_PIC = "";
                        item.COMPANY_REMARK = txtRemark.Text;
                        item.COMPANY_SHORTNAME = "";
                        item.COMPANY_STATUS = cbbStatus.Text == "ใช้งาน" ? "A" : "I";

                        dal.Update(item);
                        DataCommon.Remove("COMPANY_EDIT");
                        complete = true;
                    }
                    else
                    {
                        if (dal.GetItem(txtCompantCode.Text) == null)
                        {
                            item = new InsureCompanyData();
                            item.COMPANY_CODE = txtCompantCode.Text;
                            item.COMPANY_FULLNAME = txtCompantFullName.Text;
                            item.COMPANY_PATH_PIC = "";
                            item.COMPANY_REMARK = txtRemark.Text;
                            item.COMPANY_SHORTNAME = "";
                            item.COMPANY_STATUS = cbbStatus.Text == "ใช้งาน" ? "A" : "I";
                            new InsureCompanyDAL().Insert(item);
                            complete = true;
                        }
                        else
                        {
                            MessageBox.Show("รหัสบริษัทนี้ซ้ำในระบบ กรุณาเปลี่ยนรหัสบริษัท");
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
