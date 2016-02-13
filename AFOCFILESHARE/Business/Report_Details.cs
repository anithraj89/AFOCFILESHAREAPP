using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AFOCFILESHARE.Access;
using System.Data;

namespace AFOCFILESHARE.Business
{
    public class Report_Details
    {
        private DateTime _FromDate;
        private DateTime _ToDate;
        private string _FileName;
        private string _User_Name;

        public string User_Name
        {
            get { return _User_Name; }
            set { _User_Name = value; }
        }

        public DateTime FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
        }

        public DateTime ToDate
        {
            get { return _ToDate; }
            set { _ToDate = value; }
        }

        public string FileName
        {
            get { return _FileName; }
            set { _FileName = value; }
        }


        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        public DataTable GetUserReports(Report_Details objReports)
        {
            dbAccess db = new dbAccess();
            db.AddParameter("@FromDate", objReports.FromDate);
            db.AddParameter("@ToDate", objReports.ToDate);
            ds = db.ExecuteDataSet("sp_getuserdetails");
            dt = ds.Tables[0];
            return dt;
        }

        public DataTable GetFileReports( Report_Details objReports)
        {
            dbAccess db = new dbAccess();
            db.AddParameter("@FromDate", objReports.FromDate);
            db.AddParameter("@ToDate", objReports.ToDate);
            db.AddParameter("@Key", objReports.FileName);
            ds = db.ExecuteDataSet("sp_FileDetailsReport");
            dt = ds.Tables[0];
            return dt;
        }

        public DataTable GetDownloadReports(Report_Details objReports)
        {
            dbAccess db = new dbAccess();
            db.AddParameter("@FromDate", objReports.FromDate);
            db.AddParameter("@ToDate", objReports.ToDate);
            db.AddParameter("@Name", objReports.FileName);
            ds = db.ExecuteDataSet("sp_getdownloadhistory");
            dt = ds.Tables[0];
            return dt;
        }

        public DataTable GetUploadReports(Report_Details objReports)
        {
            dbAccess db = new dbAccess();
            db.AddParameter("@FromDate", objReports.FromDate);
            db.AddParameter("@ToDate", objReports.ToDate);
            db.AddParameter("@Name", objReports.FileName);
            ds = db.ExecuteDataSet("sp_getuploadhistory");
            dt = ds.Tables[0];
            return dt;
        }

    }
}