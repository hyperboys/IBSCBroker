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
                txtExp.Text = item.EFFECTIVE_DATE.ToShortDateString();

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
