using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AFOCFILESHARE.Access;
using AFOCFILESHARE.Business;
using Microsoft.Reporting.WebForms;
using System.Data;
namespace AFOCFILESHARE.Admin
{
    public partial class ReportUserDetails : System.Web.UI.Page
    {
        dbAccess objDbAccess = new dbAccess();
        Report_Details objReports = new Report_Details();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            objReports.FromDate = Convert.ToDateTime(txtFromdateUser.Text);
            objReports.ToDate = Convert.ToDateTime(txtTodateUser.Text);
            ShowReport();
        }

        private void ShowReport()
        {

            //Reset
            rptListUsers.Reset();

            // Data Source
            DataTable dt = new DataTable();
            dt.TableName = "UserDetails";
            dt = objReports.GetUserReports(objReports);
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            rptListUsers.LocalReport.DataSources.Add(rds);

            //Path
            rptListUsers.LocalReport.ReportPath = "ListAllUsers.rdlc";
            //Parameters
            // List<ReportParameter> myParams = new List<ReportParameter>();


            ReportParameter[] rptParams = new ReportParameter[2];

            rptParams[0] = new ReportParameter("FromDate", txtFromdateUser.Text);
            rptParams[1] = new ReportParameter("ToDate", txtTodateUser.Text);



            rptListUsers.LocalReport.SetParameters(rptParams);
            //Refesh

            rptListUsers.LocalReport.Refresh();
            // Just set the name of data table


        }
    }
}