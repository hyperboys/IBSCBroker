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
                DataTable listCar = new CarDAL().GetComboBoxCarName();
                cbbCarName.ItemsSource = listCar.DefaultView;


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
