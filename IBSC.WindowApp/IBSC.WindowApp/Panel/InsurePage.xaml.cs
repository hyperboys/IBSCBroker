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
    /// Interaction logic for InsurePage.xaml
    /// </summary>
    public partial class InsurePage : UserControl
    {
        public InsurePage()
        {
            InitializeComponent();
        }

        private void grdInsure_Loaded(object sender, RoutedEventArgs e)
        {
            ReloadData();
        }

        private void ReloadData()
        {
            try
            {
                DataTable listMember = new InsureCompanyDAL().GetAll();
                grdInsure.ItemsSource = listMember.DefaultView;
                DataCommon.Set("LIST_COMPANY", listMember);
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
                int index = grdInsure.SelectedIndex;
                string code = ((DataRowView)grdInsure.SelectedItem).Row.ItemArray[0].ToString();
                InsureCompanyData item = new InsureCompanyDAL().GetItem(code);
                DataCommon.Set("COMPANY_EDIT", item);
                PopupCompanyInsure pop = new PopupCompanyInsure();
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
                DataTable listItem = (DataTable)DataCommon.Get("LIST_COMPANY");
                var results = (from myRow in listItem.AsEnumerable()
                               where myRow.Field<string>("COMPANY_CODE").ToUpper().Contains(txtCompanyCode.Text.ToUpper())
                               && myRow.Field<string>("COMPANY_FULLNAME").ToUpper().Contains(txtCompanyName.Text.ToUpper())
                               && myRow.Field<string>("COMPANY_STATUS").ToUpper() == (cbbStatus.Text == "ใช้งาน" ? "A" : "I")
                               select myRow);
                if (results.Count() > 0)
                {
                    grdInsure.ItemsSource = results.CopyToDataTable<DataRow>().DefaultView;
                }
                else
                {
                    grdInsure.ItemsSource = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Add_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataCommon.Remove("COMPANY_EDIT");
            PopupCompanyInsure pop = new PopupCompanyInsure();
            pop.ShowDialog();
            ReloadData();
        }
    }
}
