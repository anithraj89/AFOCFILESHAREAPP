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
    public partial class ReportDownloadDetails : System.Web.UI.Page
    {
        dbAccess objDbAccess = new dbAccess();
        Report_Details objReports = new Report_Details();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            objReports.FromDate = Convert.ToDateTime(txtFromdateUpload.Text);
            objReports.ToDate = Convert.ToDateTime(txtTodateUpload.Text);
            objReports.FileName = ddlUsers.SelectedItem.Text.ToString();
            ShowReport();
        }

        private void ShowReport()
        {

            //Reset
            rptListDownloadDetails.Reset();

            // Data Source
            DataTable dt = new DataTable();
            dt.TableName = "DownloadFile";
            dt = objReports.GetDownloadReports(objReports);
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            rptListDownloadDetails.LocalReport.DataSources.Add(rds);

            //Path
            rptListDownloadDetails.LocalReport.ReportPath = "ListDownloadReports.rdlc";
            //Parameters
            // List<ReportParameter> myParams = new List<ReportParameter>();


            ReportParameter[] rptParams = new ReportParameter[3];

            rptParams[0] = new ReportParameter("FromDate", txtFromdateUpload.Text);
            rptParams[1] = new ReportParameter("ToDate", txtTodateUpload.Text);
            if (ddlUsers.SelectedItem.Text == "All")
            {
                rptParams[2] = new ReportParameter("UserName", "");
            }
            else
            {
                rptParams[2] = new ReportParameter("UserName", ddlUsers.SelectedItem.Text);
            }


            rptListDownloadDetails.LocalReport.SetParameters(rptParams);
            //Refesh

            rptListDownloadDetails.LocalReport.Refresh();
            // Just set the name of data table


        }
    }
}