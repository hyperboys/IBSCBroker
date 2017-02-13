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
    /// Interaction logic for PopupCar.xaml
    /// </summary>
    public partial class PopupCar : Window
    {
        private CarData item;
        public PopupCar()
        {
            try
            {
                InitializeComponent();
                if (DataCommon.Exists("CAR_EDIT"))
                {
                    item = (CarData)DataCommon.Get("CAR_EDIT");
                    txtCarCode.Text = item.CAR_CODE;
                    txtCarName.Text = item.CAR_NAME;
                    txtCarModel.Text = item.CAR_MODEL;
                    txtCarEngine.Text = item.CAR_ENGINE;
                    txtCarRemark.Text = item.CAR_REMARK;
                    cbbStatus.SelectedIndex = item.CAR_STATUS == "A" ? 0 : 1;
                }
                //else
                //{
                //    txtCarCode.IsEnabled = true;
                //}
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
                if (txtCarCode.Text == "") 
                {
                    MessageBox.Show("กรุณากรอก รหัสรถยนต์");
                    return;
                }
                if (txtCarName.Text == "")
                {
                    MessageBox.Show("กรุณากรอก ยี่ห้อรถยนต์");
                    return;
                }
                if (txtCarModel.Text == "")
                {
                    MessageBox.Show("กรุณากรอก รุ่นรถยนต์");
                    return;
                }
                if (txtCarEngine.Text == "")
                {
                    MessageBox.Show("กรุณากรอก เครื่องรถยนต์");
                    return;
                }
                if (MessageBox.Show("ยืนยันการบันทึกข้อมูล", "การบันทึกข้อมูล", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    bool complete = false;
                    CarDAL dal = new CarDAL();
                    if (DataCommon.Exists("CAR_EDIT"))
                    {
                        item = (CarData)DataCommon.Get("CAR_EDIT");

                        CarData newItem = new CarData();
                        newItem.CAR_CODE = txtCarCode.Text;
                        newItem.CAR_ENGINE = txtCarEngine.Text;
                        newItem.CAR_MODEL = txtCarModel.Text;
                        newItem.CAR_NAME = txtCarName.Text;
                        newItem.CAR_REMARK = txtCarRemark.Text;
                        newItem.CAR_STATUS = cbbStatus.Text == "ใช้งาน" ? "A" : "I";

                        dal.Update(item, newItem);
                        DataCommon.Remove("CAR_EDIT");
                        complete = true;
                    }
                    else
                    {
                        if (dal.GetItem(txtCarCode.Text, txtCarName.Text, txtCarModel.Text, txtCarEngine.Text) == null)
                        {
                            item = new CarData();
                            item.CAR_CODE = txtCarCode.Text;
                            item.CAR_ENGINE = txtCarEngine.Text;
                            item.CAR_MODEL = txtCarModel.Text;
                            item.CAR_NAME = txtCarName.Text;
                            item.CAR_REMARK = txtCarRemark.Text;
                            item.CAR_STATUS = cbbStatus.Text == "ใช้งาน" ? "A" : "I";
                            new CarDAL().Insert(item);
                            complete = true;
                        }
                        else
                        {
                            MessageBox.Show("รหัสรถยนต์นี้ซ้ำในระบบ กรุณาเปลี่ยนรหัสรถยนต์");
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
