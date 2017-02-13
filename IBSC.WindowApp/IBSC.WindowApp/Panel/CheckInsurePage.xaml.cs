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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace IBSC.WindowApp.Panel
{
    /// <summary>
    /// Interaction logic for CheckInsurePage.xaml
    /// </summary>
    public partial class CheckInsurePage : UserControl
    {
        public CheckInsurePage()
        {
            try
            {
                InitializeComponent();
                DataTable listCar = new CarDAL().GetComboBoxCarName();
                cbbCarName.ItemsSource = listCar.DefaultView;

                MemberData member = (MemberData)DataCommon.Get("DATA.MEMBER");
                if (!member.ROLE_CODE.Equals("admin"))
                {
                    cbbStatus.Visibility = System.Windows.Visibility.Hidden;
                    lblStatus.Visibility = System.Windows.Visibility.Hidden;
                }

                SetTimer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        protected void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void SetTimer()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 20);
            dispatcherTimer.Start();
        }

        private void grdInsure_Loaded(object sender, RoutedEventArgs e)
        {
            ReloadData();
        }

        private void ReloadData()
        {
            try
            {
                DataTable listItem;
                MemberData member = (MemberData)DataCommon.Get("DATA.MEMBER");
                if (!member.ROLE_CODE.Equals("admin"))
                {
                    listItem = new CheckInsureCarDAL().GetAll("01");
                }
                else 
                {
                    listItem = new CheckInsureCarDAL().GetAll();
                }
                
                grdInsure.ItemsSource = listItem.DefaultView;
                DataCommon.Set("LIST_CHECK_INSURE_CAR", listItem);
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
                CheckInsureCarDAL objDal = new CheckInsureCarDAL();
                string code = ((DataRowView)grdInsure.SelectedItem).Row.ItemArray[0].ToString();
                if (objDal.CheckStatus(code) != "01") 
                {
                    MessageBox.Show("มีพนักงานท่ายอื่นดำเนินการแล้ว");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cbbCarName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbbCarName.SelectedValue != null)
                {
                    DataTable listCar = new CarDAL().GetComboBoxCarModel(cbbCarName.SelectedValue.ToString());
                    cbbCarModel.ItemsSource = listCar.DefaultView;
                    cbbCarEngine.ItemsSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cbbCarModel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbbCarName.SelectedValue != null && cbbCarModel.SelectedValue != null)
                {
                    DataTable listCar = new CarDAL().GetComboBoxCarEngine(cbbCarName.SelectedValue.ToString(), cbbCarModel.SelectedValue.ToString());
                    cbbCarEngine.ItemsSource = listCar.DefaultView;
                }
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
                string condStatus = "";
                switch (cbbStatus.Text) 
                {
                    case "กรุณาเลือก":
                        {
                            condStatus = "";
                        }break;
                    case "ส่งเรื่อง": 
                        {
                            condStatus = "01";
                        }break;
                    case "ติดต่อแล้ว":
                        {
                            condStatus = "02";
                        } break;
                    case "ข้อมูลเท็จ":
                        {
                            condStatus = "03";
                        } break;   
                }
                DataTable listItem = (DataTable)DataCommon.Get("LIST_CHECK_INSURE_CAR");
                var results = (from myRow in listItem.AsEnumerable()
                               where myRow.Field<string>("CAR_YEAR").ToUpper().Contains(cbbCarYear.Text == "กรุณาเลือก" ? "" : cbbCarYear.Text)
                               && myRow.Field<string>("CAR_NAME").Contains(cbbCarName.Text)
                               && myRow.Field<string>("CAR_MODEL").Contains(cbbCarModel.Text)
                               && myRow.Field<string>("CAR_ENGINE").Contains(cbbCarEngine.Text)
                               && myRow.Field<string>("SELECT_INSURANCE_STAUTS").Contains(condStatus)
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

        private void Reset_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                cbbCarName.ItemsSource = null;
                DataTable listCar = new CarDAL().GetComboBoxCarName();
                cbbCarName.ItemsSource = listCar.DefaultView;
                cbbCarModel.ItemsSource = null;
                cbbCarEngine.ItemsSource = null;
                cbbCarYear.SelectedIndex = 0;
                cbbStatus.SelectedIndex = 0;
                ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
