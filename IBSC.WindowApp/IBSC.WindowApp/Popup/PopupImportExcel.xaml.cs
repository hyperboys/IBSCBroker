using IBSC.Common;
using IBSC.DAL;
using IBSC.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;

namespace IBSC.WindowApp.Popup
{
    /// <summary>
    /// Interaction logic for PopupImportExcel.xaml
    /// </summary>
    public partial class PopupImportExcel : Window
    {
        private static List<TextError> items;
        private static CarDAL carDal;
        private static InsureCompanyDAL comDal;
        private static InsureCarDAL insureDal;
        public PopupImportExcel()
        {
            try
            {
                InitializeComponent();
                items = new List<TextError>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnChose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                Nullable<bool> result = dlg.ShowDialog();
                if (result == true)
                {
                    string filename = dlg.FileName;
                    txtPath.Text = filename;
                    btnStart.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WaitProcess wp = new WaitProcess();
                wp.ShowDialog();
                carDal = new CarDAL();
                comDal = new InsureCompanyDAL();
                insureDal = new InsureCarDAL();
                List<InsureCarData> listItem = ReadExcel(txtPath.Text);
                DataCommon.Set("ListInsureCarData", listItem);
                ProcessDatabase();
                btnClose.IsEnabled = true;
                btnSelect.IsEnabled = true;
                wp.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ProcessDatabase()
        {
            try
            {
                int index = 3;
                List<InsureCarData> listItem = (List<InsureCarData>)DataCommon.Get("ListInsureCarData");
                MemberData member = (MemberData)DataCommon.Get("DATA.MEMBER");
                List<InsureCarData> listInsert = new List<InsureCarData>();

                foreach (InsureCarData item in listItem)
                {
                    InsureCarData tmp = new InsureCarData();

                    tmp.ASSET_TIME = item.ASSET_TIME;
                    tmp.CAPITAL_INSURANCE = item.CAPITAL_INSURANCE;

                    if (comDal.CheckItem(item.COMPANY_CODE))
                    {
                        tmp.COMPANY_CODE = item.COMPANY_CODE;
                    }
                    else
                    {
                        tmp.EXCEPTION = "รหัสบริษัทไม่มีในระบบ" + "ในบรรทัดที่ :" + index;
                        item.EXCEPTION_INDEX = index;
                    }

                    tmp.CAR_CODE = item.CAR_CODE;
                    tmp.CAR_ENGINE = item.CAR_ENGINE;
                    tmp.CAR_MODEL = item.CAR_MODEL;
                    tmp.CAR_NAME = item.CAR_NAME;
                    tmp.CAR_YEAR = item.CAR_YEAR;
                    CarData tmpCar = carDal.GetItemForExcel(tmp.CAR_CODE, tmp.CAR_NAME, tmp.CAR_MODEL);
                    if (tmpCar != null)
                    {
                        tmp.CAR_ID = tmpCar.CAR_ID;
                    }
                    else
                    {
                        tmp.EXCEPTION = "ไม่มีข้อมูลรหัสรถยนต์ : " + tmp.CAR_CODE + ", รถยนต์ยี่ห้อ : " + tmp.CAR_NAME + ", รุ่นรถยนต์ : " + tmp.CAR_MODEL + "   ในบรรทัดที่ :" + index;
                        item.EXCEPTION_INDEX = index;
                    }

                    tmp.COMPANY_FULLNAME = item.COMPANY_FULLNAME;
                    tmp.CONFIDENTIAL_STATUS = item.CONFIDENTIAL_STATUS;
                    tmp.CREATE_DATE = item.CREATE_DATE;
                    tmp.CREATE_USER = item.CREATE_USER;
                    tmp.DAMAGE_TO_VEHICLE = item.DAMAGE_TO_VEHICLE;
                    tmp.DRIVER_INSURANCE_AMT = item.DRIVER_INSURANCE_AMT;
                    tmp.EFFECTIVE_DATE = item.EFFECTIVE_DATE;
                    tmp.EXPIRE_DATE = item.EXPIRE_DATE;
                    tmp.FIRST_DAMAGE_PRICE = item.FIRST_DAMAGE_PRICE;
                    tmp.INSURE_CAR_CODE = item.INSURE_CAR_CODE;
                    tmp.INSURE_CAR_STATUS = item.INSURE_CAR_STATUS;
                    tmp.INSURE_CATEGORY = item.INSURE_CATEGORY;
                    tmp.INSURE_PRIORITY = item.INSURE_PRIORITY;
                    tmp.INSURE_TYPE_REPAIR = item.INSURE_TYPE_REPAIR;
                    tmp.LIVE_COVERAGE_PEOPLE = item.LIVE_COVERAGE_PEOPLE;
                    tmp.LIVE_COVERAGE_TIME = item.LIVE_COVERAGE_TIME;
                    tmp.MEDICAL_FEE_AMT = item.MEDICAL_FEE_AMT;
                    tmp.MEDICAL_FEE_PEOPLE = item.MEDICAL_FEE_PEOPLE;
                    tmp.MISSING_FIRE_CAR = item.MISSING_FIRE_CAR;
                    tmp.NET_PRICE = item.NET_PRICE;
                    tmp.PACKAGE_NAME = item.PACKAGE_NAME;
                    tmp.PERSONAL_ACCIDENT_AMT = item.PERSONAL_ACCIDENT_AMT;
                    tmp.PERSONAL_ACCIDENT_PEOPLE = item.PERSONAL_ACCIDENT_PEOPLE;
                    tmp.PRICE_ROUND = item.PRICE_ROUND;
                    tmp.TOTAL_PRICE = item.TOTAL_PRICE;
                    tmp.UPDATE_DATE = item.UPDATE_DATE;
                    tmp.UPDATE_USER = item.UPDATE_USER;
                    tmp.INSURE_CAR_STATUS = "A";

                    if (tmp.EXCEPTION != "")
                    {
                        items.Add(new TextError() { Error = tmp.EXCEPTION, Index = tmp.EXCEPTION_INDEX.ToString() });
                    }
                    else
                    {
                        if (insureDal.CheckItem(tmp))
                        {
                            insureDal.UpdateOnExcel(tmp);
                        }
                        else
                        {
                            listInsert.Add(tmp);
                        }
                    }
                    index++;
                }

                if (listInsert.Count > 0)
                {
                    insureDal.InsertList(listInsert);
                }
                ReloadDataForReFresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtPath_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtPath.Text == "")
            {
                btnStart.IsEnabled = false;
            }
            else
            {
                btnStart.IsEnabled = true;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Create List Object On Excel
        /// </summary>
        /// <param name="pathExcel"></param>
        /// <returns></returns>
        public List<InsureCarData> ReadExcel(string pathExcel)
        {
            try
            {
                List<InsureCarData> listInsureCarData = new List<InsureCarData>();
                bool start = false;

                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Range range;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(pathExcel, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                foreach (Excel.Worksheet xlWorkSheet in xlWorkBook.Worksheets)
                {
                    range = xlWorkSheet.UsedRange;
                    DateTime dateValue;
                    for (int row = 1; row <= range.Rows.Count; row++)
                    {
                        if (Convert.ToString((range.Cells[row, EXCEL_DATA.COMPANY_CODE] as Excel.Range).Text) == "#S")
                        {
                            start = true;
                            continue;
                        }
                        else if (Convert.ToString((range.Cells[row, EXCEL_DATA.COMPANY_CODE] as Excel.Range).Text) == "#E")
                        {
                            start = false;
                            break;
                        }

                        if (start)
                        {
                            InsureCarData item = new InsureCarData();

                            //COMPANY_CODE
                            if (Convert.ToString((range.Cells[row, EXCEL_DATA.COMPANY_CODE] as Excel.Range).Text) == "")
                            {
                                item.EXCEPTION = "ไม่มีข้อมูลรหัสบริษัทในบรรทัดที่ " + row + " ของ Sheet :" + xlWorkSheet.Name;
                                item.EXCEPTION_INDEX = row;
                            }
                            else
                            {
                                item.COMPANY_CODE = Convert.ToString((range.Cells[row, EXCEL_DATA.COMPANY_CODE] as Excel.Range).Text);
                            }

                            //EFFECTIVE_DATE
                            if (Convert.ToString((range.Cells[row, EXCEL_DATA.EFFECTIVE_DATE] as Excel.Range).Text) == "")
                            {
                                item.EXCEPTION = "ไม่มีข้อมูลวันที่มีผลในบรรทัดที่ " + row + " ของ Sheet :" + xlWorkSheet.Name;
                                item.EXCEPTION_INDEX = row;
                            }
                            else
                            {
                                if (DateTime.TryParse(Convert.ToString((range.Cells[row, EXCEL_DATA.EFFECTIVE_DATE] as Excel.Range).Text), out dateValue))
                                {
                                    item.EFFECTIVE_DATE = dateValue;
                                }
                                else
                                {
                                    item.EXCEPTION = "ไม่มีข้อมูลวันที่มีผลผิดในบรรทัดที่ " + row + " ของ Sheet :" + xlWorkSheet.Name;
                                    item.EXCEPTION_INDEX = row;
                                }
                            }

                            //EXPIRE_DATE
                            if (Convert.ToString((range.Cells[row, EXCEL_DATA.EXPIRE_DATE] as Excel.Range).Text) == "")
                            {
                                item.EXCEPTION = "ไม่มีข้อมูลวันที่สิ้นสุดในบรรทัดที่ " + row + " ของ Sheet :" + xlWorkSheet.Name;
                                item.EXCEPTION_INDEX = row;
                            }
                            else
                            {
                                if (DateTime.TryParse(Convert.ToString((range.Cells[row, EXCEL_DATA.EXPIRE_DATE] as Excel.Range).Text), out dateValue))
                                {
                                    item.EXPIRE_DATE = dateValue;
                                }
                                else
                                {
                                    item.EXCEPTION = "ไม่มีข้อมูลวันที่มีผลผิดในบรรทัดที่ " + row + "ของ Sheet :" + xlWorkSheet.Name;
                                    item.EXCEPTION_INDEX = row;
                                }
                            }

                            //INSURE_PRIORITY 
                            int INSURE_PRIORITY = 0;
                            bool result = Int32.TryParse((range.Cells[row, EXCEL_DATA.INSURE_PRIORITY] as Excel.Range).Text, out INSURE_PRIORITY);
                            if (result)
                            {
                                item.INSURE_PRIORITY = INSURE_PRIORITY;
                            }
                            else
                            {
                                item.INSURE_PRIORITY = 999;
                            }

                            //PACKAGE_NAME 
                            if (Convert.ToString((range.Cells[row, EXCEL_DATA.PACKAGE_NAME] as Excel.Range).Text) == "")
                            {
                                item.EXCEPTION = "ไม่มีข้อมูลชื่อ Package ในบรรทัดที่ " + row + " ของ Sheet :" + xlWorkSheet.Name;
                                item.EXCEPTION_INDEX = row;
                            }
                            else
                            {
                                item.PACKAGE_NAME = Convert.ToString((range.Cells[row, EXCEL_DATA.PACKAGE_NAME] as Excel.Range).Text);
                            }

                            //CAR_CODE  
                            if (Convert.ToString((range.Cells[row, EXCEL_DATA.CAR_CODE] as Excel.Range).Text) == "")
                            {
                                item.EXCEPTION = "ไม่มีข้อมูลรหัสรถยนต์ ในบรรทัดที่ " + row + " ของ Sheet :" + xlWorkSheet.Name;
                                item.EXCEPTION_INDEX = row;
                            }
                            else
                            {
                                item.CAR_CODE = Convert.ToString((range.Cells[row, EXCEL_DATA.CAR_CODE] as Excel.Range).Text).ToUpper();
                            }

                            //CAR_NAME   
                            if (Convert.ToString((range.Cells[row, EXCEL_DATA.CAR_NAME] as Excel.Range).Text) == "")
                            {
                                item.EXCEPTION = "ไม่มีข้อมูลยี่ห้อรถยนต์ ในบรรทัดที่ " + row + " ของ Sheet :" + xlWorkSheet.Name;
                                item.EXCEPTION_INDEX = row;
                            }
                            else
                            {
                                item.CAR_NAME = Convert.ToString((range.Cells[row, EXCEL_DATA.CAR_NAME] as Excel.Range).Text).ToUpper();
                            }

                            //CAR_MODEL    
                            if (Convert.ToString((range.Cells[row, EXCEL_DATA.CAR_MODEL] as Excel.Range).Text) == "")
                            {
                                item.EXCEPTION = "ไม่มีข้อมูลรุ่นรถยนต์ ในบรรทัดที่ " + row + " ของ Sheet :" + xlWorkSheet.Name;
                                item.EXCEPTION_INDEX = row;
                            }
                            else
                            {
                                item.CAR_MODEL = Convert.ToString((range.Cells[row, EXCEL_DATA.CAR_MODEL] as Excel.Range).Text).ToUpper();
                            }

                            //CAR_YEAR     
                            if (Convert.ToString((range.Cells[row, EXCEL_DATA.CAR_YEAR] as Excel.Range).Text) == "")
                            {
                                item.EXCEPTION = "ไม่มีข้อมูลปีรถยนต์ ในบรรทัดที่ " + row + " ของ Sheet :" + xlWorkSheet.Name;
                                item.EXCEPTION_INDEX = row;
                            }
                            else
                            {
                                item.CAR_YEAR = Convert.ToString((range.Cells[row, EXCEL_DATA.CAR_YEAR] as Excel.Range).Text);
                            }

                            //INSURE_CATEGORY      
                            if (Convert.ToString((range.Cells[row, EXCEL_DATA.INSURE_CATEGORY] as Excel.Range).Text) == "")
                            {
                                item.EXCEPTION = "ไม่มีข้อมูลประเภทประกันรถยนต์ ในบรรทัดที่ " + row + " ของ Sheet :" + xlWorkSheet.Name;
                                item.EXCEPTION_INDEX = row;
                            }
                            else
                            {
                                item.INSURE_CATEGORY = Convert.ToString((range.Cells[row, EXCEL_DATA.INSURE_CATEGORY] as Excel.Range).Text);
                            }

                            //INSURE_TYPE_REPAIR      
                            if (Convert.ToString((range.Cells[row, EXCEL_DATA.INSURE_TYPE_REPAIR] as Excel.Range).Text) == "")
                            {
                                item.EXCEPTION = "ไม่มีข้อมูลประเภทการซ่อม ในบรรทัดที่ " + row + " ของ Sheet :" + xlWorkSheet.Name;
                                item.EXCEPTION_INDEX = row;
                            }
                            else
                            {
                                item.INSURE_TYPE_REPAIR = Convert.ToString((range.Cells[row, EXCEL_DATA.INSURE_TYPE_REPAIR] as Excel.Range).Text);
                            }

                            //NET_PRICE  
                            decimal NET_PRICE = 0;
                            result = Decimal.TryParse((range.Cells[row, EXCEL_DATA.NET_PRICE] as Excel.Range).Text, out NET_PRICE);
                            if (result)
                            {
                                item.NET_PRICE = NET_PRICE;
                            }
                            else
                            {
                                item.EXCEPTION = "ข้อมูล เบี้ยสุทธิ ไม่ได้เป็นตัวเลข ในบรรทัดที่ " + row + " ของ Sheet :" + xlWorkSheet.Name;
                                item.EXCEPTION_INDEX = row;
                            }

                            //TOTAL_PRICE   
                            decimal TOTAL_PRICE = 0;
                            result = Decimal.TryParse((range.Cells[row, EXCEL_DATA.TOTAL_PRICE] as Excel.Range).Text, out TOTAL_PRICE);
                            if (result)
                            {
                                item.TOTAL_PRICE = TOTAL_PRICE;
                            }
                            else
                            {
                                item.EXCEPTION = "ข้อมูล เบี้ยรวม ไม่ได้เป็นตัวเลข ในบรรทัดที่ " + row + " ของ Sheet :" + xlWorkSheet.Name;
                                item.EXCEPTION_INDEX = row;
                            }

                            //PRICE_ROUND    
                            decimal PRICE_ROUND = 0;
                            result = Decimal.TryParse((range.Cells[row, EXCEL_DATA.PRICE_ROUND] as Excel.Range).Text, out PRICE_ROUND);
                            if (result)
                            {
                                item.PRICE_ROUND = PRICE_ROUND;
                            }
                            else
                            {
                                item.EXCEPTION = "ข้อมูล เบี้ยกลม ไม่ได้เป็นตัวเลข ในบรรทัดที่ " + row + " ของ Sheet :" + xlWorkSheet.Name;
                                item.EXCEPTION_INDEX = row;
                            }

                            //CAPITAL_INSURANCE    
                            decimal CAPITAL_INSURANCE = 0;
                            result = Decimal.TryParse((range.Cells[row, EXCEL_DATA.CAPITAL_INSURANCE] as Excel.Range).Text, out CAPITAL_INSURANCE);
                            if (result)
                            {
                                item.CAPITAL_INSURANCE = CAPITAL_INSURANCE;
                            }
                            else
                            {
                                item.EXCEPTION = "ข้อมูล ทุนประกันภัย ไม่ได้เป็นตัวเลข ในบรรทัดที่ " + row + " ของ Sheet :" + xlWorkSheet.Name;
                                item.EXCEPTION_INDEX = row;
                            }

                            //CONFIDENTIAL_STATUS      
                            if (Convert.ToString((range.Cells[row, EXCEL_DATA.CONFIDENTIAL_STATUS] as Excel.Range).Text) == "")
                            {
                                item.CONFIDENTIAL_STATUS = "S";
                            }
                            else
                            {
                                item.CONFIDENTIAL_STATUS = Convert.ToString((range.Cells[row, EXCEL_DATA.CONFIDENTIAL_STATUS] as Excel.Range).Text);
                            }

                            //LIVE_COVERAGE_PEOPLE    
                            decimal LIVE_COVERAGE_PEOPLE = 0;
                            result = Decimal.TryParse((range.Cells[row, EXCEL_DATA.LIVE_COVERAGE_PEOPLE] as Excel.Range).Text, out LIVE_COVERAGE_PEOPLE);
                            if (result)
                            {
                                item.LIVE_COVERAGE_PEOPLE = LIVE_COVERAGE_PEOPLE;
                            }
                            else
                            {
                                item.EXCEPTION = "ข้อมูล ชีวิต ร่างกาย หรืออนามัย /คน ไม่ได้เป็นตัวเลข ในบรรทัดที่ " + row + " ของ Sheet :" + xlWorkSheet.Name;
                                item.EXCEPTION_INDEX = row;
                            }

                            //LIVE_COVERAGE_TIME    
                            decimal LIVE_COVERAGE_TIME = 0;
                            result = Decimal.TryParse((range.Cells[row, EXCEL_DATA.LIVE_COVERAGE_TIME] as Excel.Range).Text, out LIVE_COVERAGE_TIME);
                            if (result)
                            {
                                item.LIVE_COVERAGE_TIME = LIVE_COVERAGE_TIME;
                            }
                            else
                            {
                                item.EXCEPTION = "ข้อมูล ชีวิต ร่างกาย หรืออนามัย /ครั้ง ไม่ได้เป็นตัวเลข ในบรรทัดที่ " + row + " ของ Sheet :" + xlWorkSheet.Name;
                                item.EXCEPTION_INDEX = row;
                            }

                            //ASSET_TIME    
                            decimal ASSET_TIME = 0;
                            result = Decimal.TryParse((range.Cells[row, EXCEL_DATA.ASSET_TIME] as Excel.Range).Text, out ASSET_TIME);
                            if (result)
                            {
                                item.ASSET_TIME = ASSET_TIME;
                            }
                            else
                            {
                                item.EXCEPTION = "ข้อมูล ทรัพย์สิน/ครั้ง ไม่ได้เป็นตัวเลข ในบรรทัดที่ " + row + " ของ Sheet :" + xlWorkSheet.Name;
                                item.EXCEPTION_INDEX = row;
                            }

                            //DAMAGE_TO_VEHICLE    
                            decimal DAMAGE_TO_VEHICLE = 0;
                            result = Decimal.TryParse((range.Cells[row, EXCEL_DATA.DAMAGE_TO_VEHICLE] as Excel.Range).Text, out DAMAGE_TO_VEHICLE);
                            if (result)
                            {
                                item.DAMAGE_TO_VEHICLE = DAMAGE_TO_VEHICLE;
                            }
                            else
                            {
                                item.EXCEPTION = "ข้อมูล ความเสียหายต่อรถยนต์ ไม่ได้เป็นตัวเลข ในบรรทัดที่ " + row + " ของ Sheet :" + xlWorkSheet.Name;
                                item.EXCEPTION_INDEX = row;
                            }

                            //MISSING_FIRE_CAR    
                            decimal MISSING_FIRE_CAR = 0;
                            result = Decimal.TryParse((range.Cells[row, EXCEL_DATA.MISSING_FIRE_CAR] as Excel.Range).Text, out MISSING_FIRE_CAR);
                            if (result)
                            {
                                item.MISSING_FIRE_CAR = MISSING_FIRE_CAR;
                            }
                            else
                            {
                                item.EXCEPTION = "ข้อมูล รถยนต์สูญหาย/ไฟไหม้ ไม่ได้เป็นตัวเลข ในบรรทัดที่ " + row + " ของ Sheet :" + xlWorkSheet.Name;
                                item.EXCEPTION_INDEX = row;
                            }

                            //FIRST_DAMAGE_PRICE    
                            decimal FIRST_DAMAGE_PRICE = 0;
                            result = Decimal.TryParse((range.Cells[row, EXCEL_DATA.FIRST_DAMAGE_PRICE] as Excel.Range).Text, out FIRST_DAMAGE_PRICE);
                            if (result)
                            {
                                item.FIRST_DAMAGE_PRICE = FIRST_DAMAGE_PRICE;
                            }
                            else
                            {
                                item.EXCEPTION = "ข้อมูล ค่าความเสียหายส่วนแรก ไม่ได้เป็นตัวเลข ในบรรทัดที่ " + row + " ของ Sheet :" + xlWorkSheet.Name;
                                item.EXCEPTION_INDEX = row;
                            }

                            //PERSONAL_ACCIDENT_AMT    
                            decimal PERSONAL_ACCIDENT_AMT = 0;
                            result = Decimal.TryParse((range.Cells[row, EXCEL_DATA.PERSONAL_ACCIDENT_AMT] as Excel.Range).Text, out PERSONAL_ACCIDENT_AMT);
                            if (result)
                            {
                                item.PERSONAL_ACCIDENT_AMT = PERSONAL_ACCIDENT_AMT;
                            }
                            else
                            {
                                item.EXCEPTION = "ข้อมูล อุบัติเหตุส่วนบุคคล ไม่ได้เป็นตัวเลข ในบรรทัดที่ " + row + " ของ Sheet :" + xlWorkSheet.Name;
                                item.EXCEPTION_INDEX = row;
                            }

                            //PERSONAL_ACCIDENT_PEOPLE    
                            int PERSONAL_ACCIDENT_PEOPLE = 0;
                            result = Int32.TryParse((range.Cells[row, EXCEL_DATA.PERSONAL_ACCIDENT_PEOPLE] as Excel.Range).Text, out PERSONAL_ACCIDENT_PEOPLE);
                            if (result)
                            {
                                item.PERSONAL_ACCIDENT_PEOPLE = PERSONAL_ACCIDENT_PEOPLE;
                            }
                            else
                            {
                                item.EXCEPTION = "ข้อมูล จำนวนคน/อุบัติเหตุส่วนบุคคล ไม่ได้เป็นตัวเลข ในบรรทัดที่ " + row + " ของ Sheet :" + xlWorkSheet.Name;
                                item.EXCEPTION_INDEX = row;
                            }

                            //MEDICAL_FEE_AMT    
                            decimal MEDICAL_FEE_AMT = 0;
                            result = Decimal.TryParse((range.Cells[row, EXCEL_DATA.MEDICAL_FEE_AMT] as Excel.Range).Text, out MEDICAL_FEE_AMT);
                            if (result)
                            {
                                item.MEDICAL_FEE_AMT = MEDICAL_FEE_AMT;
                            }
                            else
                            {
                                item.EXCEPTION = "ข้อมูล ค่ารักษาพยาบาล ไม่ได้เป็นตัวเลข ในบรรทัดที่ " + row + " ของ Sheet :" + xlWorkSheet.Name;
                                item.EXCEPTION_INDEX = row;
                            }

                            //MEDICAL_FEE_PEOPLE    
                            int MEDICAL_FEE_PEOPLE = 0;
                            result = Int32.TryParse((range.Cells[row, EXCEL_DATA.MEDICAL_FEE_PEOPLE] as Excel.Range).Text, out MEDICAL_FEE_PEOPLE);
                            if (result)
                            {
                                item.MEDICAL_FEE_PEOPLE = MEDICAL_FEE_PEOPLE;
                            }
                            else
                            {
                                item.EXCEPTION = "ข้อมูล จำนวนคน/ค่ารักษาพยาบาล ไม่ได้เป็นตัวเลข ในบรรทัดที่ " + row + " ของ Sheet :" + xlWorkSheet.Name;
                                item.EXCEPTION_INDEX = row;
                            }

                            //DRIVER_INSURANCE_AMT    
                            decimal DRIVER_INSURANCE_AMT = 0;
                            result = Decimal.TryParse((range.Cells[row, EXCEL_DATA.DRIVER_INSURANCE_AMT] as Excel.Range).Text, out DRIVER_INSURANCE_AMT);
                            if (result)
                            {
                                item.DRIVER_INSURANCE_AMT = DRIVER_INSURANCE_AMT;
                            }
                            else
                            {
                                item.EXCEPTION = "ข้อมูล ประกันตัวผู้ขับขี่ ไม่ได้เป็นตัวเลข ในบรรทัดที่ " + row + " ของ Sheet :" + xlWorkSheet.Name;
                            }

                            if (item.EXCEPTION != "")
                            {
                                items.Add(new TextError() { Error = item.EXCEPTION, Index = item.EXCEPTION_INDEX.ToString() });
                            }
                            else
                            {
                                listInsureCarData.Add(item);
                            }
                        }
                    }
                }

                xlWorkBook.Close(0);
                xlApp.Quit();
                return listInsureCarData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ReloadDataForReFresh()
        {
            try
            {
                viewError.ItemsSource = items;
                viewError.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder textDate = new StringBuilder();
                string path = string.Empty;
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                do
                {
                    saveFileDialog.ShowDialog();
                    path = saveFileDialog.FileName;

                } while (path == string.Empty);

                foreach (TextError item in items)
                {
                    textDate.AppendLine(item.Error);
                }
                System.IO.File.WriteAllText(path + ".txt", textDate.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }

    public class TextError
    {
        public string Error { get; set; }
        public string Index { get; set; }
    }
}
