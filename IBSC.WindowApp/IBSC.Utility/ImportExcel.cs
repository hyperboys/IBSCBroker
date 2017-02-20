using IBSC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace IBSC.Utility
{
    public class ImportExcel
    {

        public ImportExcel()
        {

        }

        public List<InsureCarData> ReadExcel(string pathExcel)
        {
            try
            {
                List<InsureCarData> listInsureCarData = new List<InsureCarData>();

                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Range range;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(pathExcel, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                foreach (Excel.Worksheet xlWorkSheet in xlWorkBook.Worksheets)
                {
                    range = xlWorkSheet.UsedRange;
                    DateTime dateValue;
                    for (int row = 1; row <= range.Rows.Count; row++)
                    {
                        InsureCarData item = new InsureCarData();

                        //COMPANY_CODE
                        if (Convert.ToString((range.Cells[row, EXCEL_DATA.COMPANY_CODE] as Excel.Range).Text) == "")
                        {
                            item.EXCEPTION = "ไม่มีข้อมูลรหัสบริษัทในบรรทัดที่ " + row + " ของ Sheet :" + xlWorkSheet.Name;
                            continue;
                        }
                        item.COMPANY_CODE = Convert.ToString((range.Cells[row, EXCEL_DATA.COMPANY_CODE] as Excel.Range).Text);

                        //EFFECTIVE_DATE
                        if (Convert.ToString((range.Cells[row, EXCEL_DATA.EFFECTIVE_DATE] as Excel.Range).Text) == "")
                        {
                            item.EXCEPTION = "ไม่มีข้อมูลวันที่มีผลในบรรทัดที่ " + row + " ของ Sheet :" + xlWorkSheet.Name;
                            continue;
                        }
                        if (DateTime.TryParse(Convert.ToString((range.Cells[row, EXCEL_DATA.EFFECTIVE_DATE] as Excel.Range).Text), out dateValue))
                        {
                            item.EFFECTIVE_DATE = dateValue;
                        }
                        else 
                        {
                            item.EXCEPTION = "ไม่มีข้อมูลวันที่มีผลผิดในบรรทัดที่ " + row + " ของ Sheet :" + xlWorkSheet.Name;
                            continue;
                        }

                        //EXPIRE_DATE
                        if (Convert.ToString((range.Cells[row, EXCEL_DATA.EXPIRE_DATE] as Excel.Range).Text) == "")
                        {
                            item.EXCEPTION = "ไม่มีข้อมูลวันที่สิ้นสุดในบรรทัดที่ " + row + " ของ Sheet :" + xlWorkSheet.Name;
                            continue;
                        }
                        if (DateTime.TryParse(Convert.ToString((range.Cells[row, EXCEL_DATA.EXPIRE_DATE] as Excel.Range).Text), out dateValue))
                        {
                            item.EXPIRE_DATE = dateValue;
                        }
                        else
                        {
                            item.EXCEPTION = "ไม่มีข้อมูลวันที่มีผลผิดในบรรทัดที่ " + row + "ของ Sheet :" + xlWorkSheet.Name;
                            continue;
                        }
                       

                        //int ASSET_TIME = 0;
                        //bool result = Int32.TryParse(txtPriolity.Text, out priority);
                        //if (result)
                        //{
                        //    item.ASSET_TIME = priority;
                        //}
                        //else
                        //{
                        //    newItem.INSURE_PRIORITY = 999;
                        //}
                        //item.ASSET_TIME = 


                    }
                }


                return listInsureCarData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
