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
    public partial class ReportListAllFiles : System.Web.UI.Page
    {
        dbAccess objDbAccess = new dbAccess();
        Report_Details objReports = new Report_Details();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            objReports.FromDate = Convert.ToDateTime(txtFromdateListFiles.Text);
            objReports.ToDate = Convert.ToDateTime(txtTodateListFiles.Text);
            objReports.FileName = txtFileName.Text;
            ShowReport();
        }
        private void ShowReport()
        {

            //Reset
            rptListFiles.Reset();

            // Data Source
            DataTable dt = new DataTable();
            dt.TableName = "UploadFile";
            dt = objReports.GetFileReports(objReports);
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            rptListFiles.LocalReport.DataSources.Add(rds);

            //Path
            rptListFiles.LocalReport.ReportPath = "ListAllFileReports.rdlc";
            //Parameters
            // List<ReportParameter> myParams = new List<ReportParameter>();


            ReportParameter[] rptParams = new ReportParameter[3];

            rptParams[0] = new ReportParameter("FromDate", txtFromdateListFiles.Text);
            rptParams[1] = new ReportParameter("ToDate", txtTodateListFiles.Text);
            if (txtFileName.Text == "")
            {
                rptParams[2] = new ReportParameter("FileName", new string[] { null });
            }
            else
            {
                rptParams[2] = new ReportParameter("FileName", txtFileName.Text);
            }


            rptListFiles.LocalReport.SetParameters(rptParams);
            //Refesh

            rptListFiles.LocalReport.Refresh();
            // Just set the name of data table


        }
    }
}