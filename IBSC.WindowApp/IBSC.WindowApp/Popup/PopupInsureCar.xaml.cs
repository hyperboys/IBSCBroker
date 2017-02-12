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
                newItem.ASSET_TIME = Convert.ToDecimal(txtAssetTime.Text);
                newItem.CAPITAL_INSURANCE = Convert.ToDecimal(txtCapitalInsure.Text);
                CarData carItem = new CarDAL().GetItem(cbbCarName.Text, cbbCarModel.Text, cbbCarEngine.Text);
                newItem.CAR_ID = carItem.CAR_ID;
                newItem.CAR_CODE = carItem.CAR_CODE;
                newItem.CAR_ENGINE = carItem.CAR_ENGINE;
                newItem.CAR_MODEL = carItem.CAR_MODEL;
                newItem.CAR_NAME = carItem.CAR_NAME;
                newItem.CAR_YEAR = cbbCarYear.Text;
                newItem.COMPANY_CODE = new InsureCompanyDAL().GetCompanyCode(cbbCompany.Text);
                newItem.CONFIDENTIAL_STATUS = cbbConfident.Text == "Show" ? "S" : "H";
                newItem.CREATE_DATE = DateTime.Now;
                newItem.CREATE_USER = member.MEMBER_USER;
                newItem.DAMAGE_TO_VEHICLE = Convert.ToDecimal(txtDamageCar.Text);
                newItem.DRIVER_INSURANCE_AMT = Convert.ToDecimal(txtInsureDriver.Text);
                newItem.EFFECTIVE_DATE = Convert.ToDateTime(txtEff.Text);
                newItem.EXPIRE_DATE = Convert.ToDateTime(txtExp.Text);
                newItem.FIRST_DAMAGE_PRICE = Convert.ToDecimal(txtFirstDamage.Text);
                newItem.INSURE_CAR_STATUS = cbbStatus.Text == "ใช้งาน" ? "A" : "I";
                newItem.INSURE_CATEGORY = cbbInsureCat.Text;
                newItem.INSURE_PRIORITY = Convert.ToInt32(txtPriolity.Text);
                newItem.INSURE_TYPE_REPAIR = cbbTypeRepair.Text;
                newItem.LIVE_COVERAGE_PEOPLE = Convert.ToDecimal(txtCoveragePeople.Text);
                newItem.LIVE_COVERAGE_TIME = Convert.ToDecimal(txtCoverageTime.Text);
                newItem.MEDICAL_FEE_AMT = Convert.ToDecimal(txtMEDICAL_FEE_AMT.Text);
                newItem.MEDICAL_FEE_PEOPLE = Convert.ToInt32(txtMEDICAL_FEE_PEOPLE.Text);
                newItem.MISSING_FIRE_CAR = Convert.ToDecimal(txtMissingCar.Text);
                newItem.NET_PRICE = Convert.ToDecimal(txtNetPrice.Text);
                newItem.PACKAGE_NAME = txtPackage.Text;
                newItem.PERSONAL_ACCIDENT_AMT = Convert.ToDecimal(txtPERSONAL_ACCIDENT_AMT.Text);
                newItem.PERSONAL_ACCIDENT_PEOPLE = Convert.ToInt32(txtPERSONAL_ACCIDENT_PEOPLE.Text);
                newItem.PRICE_ROUND = Convert.ToDecimal(txtRoundPrice.Text);
                newItem.TOTAL_PRICE = Convert.ToDecimal(txtTotalPrice.Text);
                newItem.UPDATE_DATE = DateTime.Now;
                newItem.UPDATE_USER = member.MEMBER_USER;
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
