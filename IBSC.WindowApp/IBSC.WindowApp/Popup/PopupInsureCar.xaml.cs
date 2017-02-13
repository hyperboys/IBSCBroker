using IBSC.Common;
using IBSC.DAL;
using IBSC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for PopupInsureCar.xaml
    /// </summary>
    public partial class PopupInsureCar : Window
    {
        public PopupInsureCar()
        {
            try
            {
                InitializeComponent();

                DataTable listCar = new CarDAL().GetComboBoxCarName();
                cbbCarName.ItemsSource = listCar.DefaultView;

                DataTable listCompany = new InsureCompanyDAL().GetComboBoxCompanyName();
                cbbCompany.ItemsSource = listCompany.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public PopupInsureCar(string mode)
        {
            try
            {
                InitializeComponent();

                InsureCarData item = (InsureCarData)DataCommon.Get("INSURE_CAR_EDIT");
                txtAssetTime.Text = item.ASSET_TIME.ToString();
                txtCapitalInsure.Text = item.CAPITAL_INSURANCE.ToString();
                txtCoveragePeople.Text = item.LIVE_COVERAGE_PEOPLE.ToString();
                txtCoverageTime.Text = item.LIVE_COVERAGE_TIME.ToString();
                txtDamageCar.Text = item.DAMAGE_TO_VEHICLE.ToString();
                txtFirstDamage.Text = item.FIRST_DAMAGE_PRICE.ToString();
                txtInsureDriver.Text = item.DRIVER_INSURANCE_AMT.ToString();
                txtMEDICAL_FEE_AMT.Text = item.MEDICAL_FEE_AMT.ToString();
                txtMEDICAL_FEE_PEOPLE.Text = item.MEDICAL_FEE_PEOPLE.ToString();
                txtMissingCar.Text = item.MISSING_FIRE_CAR.ToString();
                txtNetPrice.Text = item.NET_PRICE.ToString();
                txtPackage.Text = item.PACKAGE_NAME;
                txtPERSONAL_ACCIDENT_AMT.Text = item.PERSONAL_ACCIDENT_AMT.ToString();
                txtPERSONAL_ACCIDENT_PEOPLE.Text = item.PERSONAL_ACCIDENT_PEOPLE.ToString();
                txtPriolity.Text = item.INSURE_PRIORITY.ToString();
                txtRoundPrice.Text = item.PRICE_ROUND.ToString();
                txtTotalPrice.Text = item.TOTAL_PRICE.ToString();

                txtEff.Text = item.EFFECTIVE_DATE.ToShortDateString();
                txtExp.Text = item.EXPIRE_DATE.ToShortDateString();

                cbbCarYear.SelectedValue = item.CAR_YEAR.ToString();

                DataTable listCar = new CarDAL().GetComboBoxCarName();
                cbbCarName.ItemsSource = listCar.DefaultView;
                cbbCarName.Text = item.CAR_NAME.ToString();

                DataTable listCarModel = new CarDAL().GetComboBoxCarModel(item.CAR_NAME);
                cbbCarModel.ItemsSource = listCarModel.DefaultView;
                cbbCarModel.Text = item.CAR_MODEL.ToString();

                DataTable listCarEngine = new CarDAL().GetComboBoxCarEngine(item.CAR_NAME, item.CAR_MODEL);
                cbbCarEngine.ItemsSource = listCarEngine.DefaultView;
                cbbCarEngine.Text = item.CAR_ENGINE.ToString();

                DataTable listCompany = new InsureCompanyDAL().GetComboBoxCompanyName();
                cbbCompany.ItemsSource = listCompany.DefaultView;
                cbbCompany.Text = item.COMPANY_FULLNAME;

                cbbConfident.SelectedValue = item.CONFIDENTIAL_STATUS == "S" ? "Show" : "Hidden";
                cbbInsureCat.SelectedValue = item.INSURE_CATEGORY.ToString();
                cbbTypeRepair.SelectedValue = item.INSURE_TYPE_REPAIR.ToString();

                if (mode == "VIEW")
                {
                    txtAssetTime.IsEnabled = false;
                    txtCapitalInsure.IsEnabled = false;
                    txtCoveragePeople.IsEnabled = false;
                    txtCoverageTime.IsEnabled = false;
                    txtDamageCar.IsEnabled = false;
                    txtFirstDamage.IsEnabled = false;
                    txtInsureDriver.IsEnabled = false;
                    txtMEDICAL_FEE_AMT.IsEnabled = false;
                    txtMEDICAL_FEE_PEOPLE.IsEnabled = false;
                    txtMissingCar.IsEnabled = false;
                    txtNetPrice.IsEnabled = false;
                    txtPackage.IsEnabled = false;
                    txtPERSONAL_ACCIDENT_AMT.IsEnabled = false;
                    txtPERSONAL_ACCIDENT_PEOPLE.IsEnabled = false;
                    txtPriolity.IsEnabled = false;
                    txtRoundPrice.IsEnabled = false;
                    txtTotalPrice.IsEnabled = false;
                    txtEff.IsEnabled = false;
                    txtExp.IsEnabled = false;
                    cbbCarYear.IsEnabled = false;
                    cbbCarName.IsEnabled = false;
                    cbbCarModel.IsEnabled = false;
                    cbbCarEngine.IsEnabled = false;
                    cbbCompany.IsEnabled = false;
                    cbbConfident.IsEnabled = false;
                    cbbInsureCat.IsEnabled = false;
                    cbbTypeRepair.IsEnabled = false;
                    cbbStatus.IsEnabled = false;
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

                bool complete = false;
                MemberData member = (MemberData)DataCommon.Get("DATA.MEMBER");
                InsureCarData newItem = new InsureCarData();

                if (cbbCompany.Text == "")
                {
                    MessageBox.Show("กรูณาเลือก บริษัทประกันภัย");
                    return;
                }
                newItem.COMPANY_CODE = new InsureCompanyDAL().GetCompanyCode(cbbCompany.Text);
                if (txtPackage.Text == "")
                {
                    MessageBox.Show("กรูณากรอก ชื่อแพคเกจ");
                    return;
                }
                newItem.PACKAGE_NAME = txtPackage.Text;
                if (cbbCarName.Text == "")
                {
                    MessageBox.Show("กรูณาเลือก ยี่ห้อรถยนต์");
                    return;
                }
                if (cbbCarModel.Text == "")
                {
                    MessageBox.Show("กรูณาเลือก รุ่นรถยนต์");
                    return;
                }
                if (cbbCarEngine.Text == "")
                {
                    MessageBox.Show("กรูณาเลือก เครื่องยนต์");
                    return;
                }
                CarData carItem = new CarDAL().GetItem(cbbCarName.Text, cbbCarModel.Text, cbbCarEngine.Text);
                newItem.CAR_ID = carItem.CAR_ID;
                newItem.CAR_CODE = carItem.CAR_CODE;
                newItem.CAR_ENGINE = carItem.CAR_ENGINE;
                newItem.CAR_MODEL = carItem.CAR_MODEL;
                newItem.CAR_NAME = carItem.CAR_NAME;

                newItem.CAR_YEAR = cbbCarYear.Text;
                newItem.CONFIDENTIAL_STATUS = cbbConfident.Text == "Show" ? "S" : "H";
                newItem.CREATE_DATE = DateTime.Now;
                newItem.CREATE_USER = member.MEMBER_USER;
                newItem.INSURE_CAR_STATUS = cbbStatus.Text == "ใช้งาน" ? "A" : "I";
                newItem.INSURE_CATEGORY = cbbInsureCat.Text;
                newItem.INSURE_TYPE_REPAIR = cbbTypeRepair.Text;
                newItem.UPDATE_DATE = DateTime.Now;
                newItem.UPDATE_USER = member.MEMBER_USER;

                if (txtCapitalInsure.Text == "")
                {
                    MessageBox.Show("กรูณากรอก ทุนประกันภัย");
                    return;
                }
                newItem.CAPITAL_INSURANCE = Convert.ToDecimal(txtCapitalInsure.Text);
                if (txtNetPrice.Text == "")
                {
                    MessageBox.Show("กรูณากรอก เบี้ยสุทธิ");
                    return;
                }
                newItem.NET_PRICE = Convert.ToDecimal(txtNetPrice.Text);
                if (txtTotalPrice.Text == "")
                {
                    MessageBox.Show("กรูณากรอก เบี้ยรวม");
                    return;
                }
                newItem.TOTAL_PRICE = Convert.ToDecimal(txtTotalPrice.Text);
                if (txtRoundPrice.Text == "")
                {
                    MessageBox.Show("กรูณากรอก เบี้ยกลม");
                    return;
                }
                newItem.PRICE_ROUND = Convert.ToDecimal(txtRoundPrice.Text);
                int priority = 0;
                bool result = Int32.TryParse(txtPriolity.Text, out priority);
                if (result)
                {
                    newItem.INSURE_PRIORITY = priority;
                }
                else
                {
                    newItem.INSURE_PRIORITY = 999;
                }
                if (txtEff.Text == "")
                {
                    MessageBox.Show("กรูณาเลือก วันที่มีผล");
                    return;
                }
                newItem.EFFECTIVE_DATE = Convert.ToDateTime(txtEff.Text);
                if (txtExp.Text == "")
                {
                    MessageBox.Show("กรูณาเลือก วันที่หมดอายุ");
                    return;
                }
                newItem.EXPIRE_DATE = Convert.ToDateTime(txtExp.Text);
                if (txtCoveragePeople.Text == "")
                {
                    MessageBox.Show("กรูณากรอก ชีวิต ร่างกาย หรืออนามัย /คน");
                    return;
                }
                newItem.LIVE_COVERAGE_PEOPLE = Convert.ToDecimal(txtCoveragePeople.Text);
                if (txtCoverageTime.Text == "")
                {
                    MessageBox.Show("กรูณากรอก ชีวิต ร่างกาย หรืออนามัย /ครั้ง");
                    return;
                }
                newItem.LIVE_COVERAGE_TIME = Convert.ToDecimal(txtCoverageTime.Text);
                if (txtAssetTime.Text == "")
                {
                    MessageBox.Show("กรูณากรอก ทรัพย์สิน/ครั้ง");
                    return;
                }
                newItem.ASSET_TIME = Convert.ToDecimal(txtAssetTime.Text);
                if (txtDamageCar.Text == "")
                {
                    MessageBox.Show("กรูณากรอก ความเสียหายต่อรถยนต์");
                    return;
                }
                newItem.DAMAGE_TO_VEHICLE = Convert.ToDecimal(txtDamageCar.Text);
                if (txtMissingCar.Text == "")
                {
                    MessageBox.Show("กรูณากรอก รถยนต์สูญหาย/ไฟไหม้");
                    return;
                }
                newItem.MISSING_FIRE_CAR = Convert.ToDecimal(txtMissingCar.Text);
                if (txtFirstDamage.Text == "")
                {
                    MessageBox.Show("กรูณากรอก ค่าความเสียหายส่วนแรก");
                    return;
                }
                newItem.FIRST_DAMAGE_PRICE = Convert.ToDecimal(txtFirstDamage.Text);
                if (txtInsureDriver.Text == "")
                {
                    MessageBox.Show("กรูณากรอก ประกันตัวผู้ขับขี่");
                    return;
                }
                newItem.DRIVER_INSURANCE_AMT = Convert.ToDecimal(txtInsureDriver.Text);
                if (txtPERSONAL_ACCIDENT_AMT.Text == "")
                {
                    MessageBox.Show("กรูณากรอก อุบัติเหตุส่วนบุคคล");
                    return;
                }
                newItem.PERSONAL_ACCIDENT_AMT = Convert.ToDecimal(txtPERSONAL_ACCIDENT_AMT.Text);
                if (txtPERSONAL_ACCIDENT_PEOPLE.Text == "")
                {
                    MessageBox.Show("กรูณากรอก จำนวนคนต่ออุบัติเหตุส่วนบุคคล");
                    return;
                }
                newItem.PERSONAL_ACCIDENT_PEOPLE = Convert.ToInt32(txtPERSONAL_ACCIDENT_PEOPLE.Text);
                if (txtMEDICAL_FEE_AMT.Text == "")
                {
                    MessageBox.Show("กรูณากรอก ค่ารักษาพยาบาล");
                    return;
                }
                newItem.MEDICAL_FEE_AMT = Convert.ToDecimal(txtMEDICAL_FEE_AMT.Text);
                if (txtMEDICAL_FEE_PEOPLE.Text == "")
                {
                    MessageBox.Show("กรูณากรอก จำนวนคนต่อค่ารักษาพยาบาล");
                    return;
                }
                newItem.MEDICAL_FEE_PEOPLE = Convert.ToInt32(txtMEDICAL_FEE_PEOPLE.Text);

                if (MessageBox.Show("ยืนยันการบันทึกข้อมูล", "การบันทึกข้อมูล", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    if (DataCommon.Exists("INSURE_CAR_EDIT"))
                    {
                        InsureCarData oldItem = (InsureCarData)DataCommon.Get("INSURE_CAR_EDIT");
                        new InsureCarDAL().Update(oldItem, newItem);
                        complete = true;
                    }
                    else
                    {
                        new InsureCarDAL().Insert(newItem);
                        complete = true;
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

        void NumericTextBoxInput(object sender, TextCompositionEventArgs e)
        {
            CommonControl.NumericTextBoxInput(sender, e);
        }

        private void cbbCarName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataTable listCar = new CarDAL().GetComboBoxCarModel(cbbCarName.SelectedValue.ToString());
            cbbCarModel.ItemsSource = listCar.DefaultView;
            cbbCarEngine.ItemsSource = null;
        }

        private void cbbCarModel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataTable listCar = new CarDAL().GetComboBoxCarEngine(cbbCarName.SelectedValue.ToString(), cbbCarModel.SelectedValue.ToString());
            cbbCarEngine.ItemsSource = listCar.DefaultView;
        }
    }
}
