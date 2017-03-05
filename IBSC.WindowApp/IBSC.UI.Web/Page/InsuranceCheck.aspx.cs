using IBSC.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IBSC.UI.Web.Page
{
    public partial class InsuranceCheck : System.Web.UI.Page
    {
        private static InsureCarDAL insureCarDal;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    insureCarDal = new InsureCarDAL();
                    DataTable dt = insureCarDal.GetComboBoxCarYear();
                    foreach (DataRow row in dt.Rows)
                    {
                        ddlCarYear.Items.Add(new ListItem(row[0].ToString(), row[0].ToString()));
                    }
                    ddlCarYear.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            headCar.Visible = true;
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {

        }

        protected void ddlCarYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = insureCarDal.GetComboBoxCarName(ddlCarYear.Text);
                
                ddlCarName.Items.Clear();
                ddlCarName.Items.Add(new ListItem("กรุณาเลือก","กรุณาเลือก"));
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ddlCarName.Items.Add(new ListItem(row[0].ToString(), row[0].ToString()));
                    }
                    ddlCarName.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}