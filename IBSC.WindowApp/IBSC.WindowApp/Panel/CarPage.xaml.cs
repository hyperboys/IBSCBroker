using IBSC.Common;
using IBSC.DAL;
using IBSC.Model;
using IBSC.WindowApp.Popup;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IBSC.WindowApp.Panel
{
    /// <summary>
    /// Interaction logic for CarPage.xaml
    /// </summary>
    public partial class CarPage : UserControl
    {
        public CarPage()
        {
            InitializeComponent();
        }

        private void grdCar_Loaded(object sender, RoutedEventArgs e)
        {
            ReloadData();
        }

        private void ReloadData()
        {
            try
            {
                DataTable listMember = new CarDAL().GetAll();
                grdCar.ItemsSource = listMember.DefaultView;
                DataCommon.Set("LIST_CAR", listMember);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = grdCar.SelectedIndex;
                string carCode = ((DataRowView)grdCar.SelectedItem).Row.ItemArray[0].ToString();
                string carName = ((DataRowView)grdCar.SelectedItem).Row.ItemArray[1].ToString();
                string carModel = ((DataRowView)grdCar.SelectedItem).Row.ItemArray[2].ToString();
                string carEngine = ((DataRowView)grdCar.SelectedItem).Row.ItemArray[3].ToString();
                CarData carItem = new CarDAL().GetItem(carCode, carName,carModel,carEngine);
                DataCommon.Set("CAR_EDIT", carItem);
                PopupCar pop = new PopupCar();
                pop.ShowDialog();
                ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DataTable listItem = (DataTable)DataCommon.Get("LIST_CAR");
                var results = (from myRow in listItem.AsEnumerable()
                               where myRow.Field<string>("CAR_NAME").ToUpper().Contains(txtCarBand.Text.ToUpper())
                               && myRow.Field<string>("CAR_CODE").ToUpper().Contains(txtCarCode.Text.ToUpper())
                               && myRow.Field<string>("CAR_MODEL").ToUpper().Contains(txtCarModel.Text.ToUpper())
                               && myRow.Field<string>("CAR_STATUS").ToUpper().Contains(cbbStatus.Text == "ใช้งาน" ? "A" : "I")
                               select myRow);
                if (results.Count() > 0)
                {
                    grdCar.ItemsSource = results.CopyToDataTable<DataRow>().DefaultView;
                }
                else
                {
                    grdCar.ItemsSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Add_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataCommon.Remove("CAR_EDIT");
            PopupCar pop = new PopupCar();
            pop.ShowDialog();
            ReloadData();
        }
    }
}
