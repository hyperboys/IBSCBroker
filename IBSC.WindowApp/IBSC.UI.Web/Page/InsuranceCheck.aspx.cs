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
            try
            {
                DataTable dt = insureCarDal.GetAllCondition(ddlCarYear.Text, ddlCarName.Text, ddlCarModel.Text);
                if (dt != null && dt.Rows.Count > 0)
                {
                    string tmpCar = dt.Rows[0]["CAR_NAME"].ToString() + " " + dt.Rows[0]["CAR_MODEL"].ToString()
                        + " " + dt.Rows[0]["CAR_ENGINE"].ToString() + " ปี " + dt.Rows[0]["CAR_YEAR"].ToString();
                    lblCarName.Text = tmpCar;
                    lblCarNameDesc.Text = tmpCar;
                    imageCar.Src = @"../logoCar/" + dt.Rows[0]["CAR_IMAGE"].ToString();

                    string tmpInsureCompany = "";
                    int countRow = 1;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (tmpInsureCompany == "")
                        {
                            tmpInsureCompany = row["COMPANY_FULLNAME"].ToString();

                            accordion.InnerHtml += @" <div class=""panel panel-default"">";
                            accordion.InnerHtml += @"<div class=""panel-heading panel-heading-link"">";
                            accordion.InnerHtml += @"<a data-toggle=""collapse"" style=""height: 50px;"" data-parent=""#accordion"" href=""#" + row["INSURE_CODE"].ToString() + @" class=""list-ins collapsed"">";
                            accordion.InnerHtml += @" <div class=""col-xs-2 col-md-1 no-padding"">";
                            accordion.InnerHtml += @" <img class=""img-responsive img-circle center-block"" src=""../logoCompany/VIB.jpg"" style=""max-width: 30px; background-color: white; margin-top: 5px;"" />";
                            accordion.InnerHtml += @"</div>";
                            accordion.InnerHtml += @"<div class=""col-xs-10 col-md-6 hideOverflow no-padding"">";
                            accordion.InnerHtml += @"<span id=""ContentPlaceHolder_rptIns_Label2_0"">วิริยะประกันภัย</span>";
                            accordion.InnerHtml += @"</div>";
                        }
                        else if (tmpInsureCompany == row["COMPANY_FULLNAME"].ToString())
                        {

                        }
                        else
                        {
                            accordion.InnerHtml += @"</div>";

                            tmpInsureCompany = row["COMPANY_FULLNAME"].ToString();
                        }
                    }


                    headCar.Visible = true;
                }


            }
            catch (Exception ex)
            {

            }
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
                ddlCarModel.Items.Clear();
                ddlCarName.Items.Add(new ListItem("กรุณาเลือก", "กรุณาเลือก"));
                ddlCarModel.Items.Add(new ListItem("กรุณาเลือก", "กรุณาเลือก"));

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

        protected void ddlCarName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = insureCarDal.GetComboBoxCarModel(ddlCarYear.Text, ddlCarName.Text);

                ddlCarModel.Items.Clear();
                ddlCarModel.Items.Add(new ListItem("กรุณาเลือก", "กรุณาเลือก"));
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ddlCarModel.Items.Add(new ListItem(row[0].ToString(), row[0].ToString()));
                    }
                    ddlCarModel.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}