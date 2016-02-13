using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AFOCFILESHARE.Business;
using System.Data;
using AFOCFILESHARE.Access;

namespace AFOCFILESHARE.Business
{
    public class FileUpload
    {

        private string _FileName;
        private double _FileSize;
        private string _FileType;
        private string _Extension;
        private string _FilePath;
        private int _UserId;
        private int _FileId;



        private int _Id;
        private string _Name;
        private string _City;
        private string _Address;
        private string _Designation;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }



        public string Designation
        {
            get { return _Designation; }
            set { _Designation = value; }
        }


        public string FileName
        {
            get { return _FileName; }
            set { _FileName = value; }
        }

        public double FileSize
        {
            get { return _FileSize; }
            set { _FileSize = value; }
        }
        public string FileType
        {
            get { return _FileType; }
            set { _FileType = value; }
        }

        public string FilePath
        {
            get { return _FilePath; }
            set { _FilePath = value; }
        }

        public string Extension
        {
            get { return _Extension; }
            set { _Extension = value; }
        }

        public int UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }


        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public int FileId
        {
            get { return _FileId; }
            set { _FileId = value; }
        }

        public int INSERT_File_DETAILS( FileUpload objlog)
        {
            dbAccess db = new dbAccess();
            db.AddParameter("@UserId", objlog.UserId);
            db.AddParameter("@FileName", objlog.FileName);
            db.AddParameter("@FileSize", objlog.FileSize);
            db.AddParameter("@ContentType", objlog.FileType);
            db.AddParameter("@FileExtension", objlog.Extension);
            db.AddParameter("@FilePath", objlog.FilePath);
            return db.ExecuteNonQuery("SP_INSERTFILEDETAILS");
        }


        public int INSERT_File_Excel(FileUpload objlog)
        {
            dbAccess db = new dbAccess();
            db.AddParameter("@UserId", objlog.UserId);
            db.AddParameter("@Id", objlog.Id);
            db.AddParameter("@Name", objlog.Name);
            db.AddParameter("@City", objlog.City);
            db.AddParameter("@Address", objlog.Address);
            db.AddParameter("@Designation", objlog.Designation);
            return db.ExecuteNonQuery("SP_INSERTEXCELDETAILS");
        }
        public int Downlaod_File(FileUpload objlog)
        {
            dbAccess db = new dbAccess();
            db.AddParameter("@UserId", objlog.UserId);
            db.AddParameter("@FileId", objlog.FileId);
            return db.ExecuteNonQuery("SP_DOWNLOADFILE");
        }
        public DataSet Get_Files_List()
        {
            dbAccess db = new dbAccess();
            return db.ExecuteDataSet("SP_GETFILEDETAILS");
        }
        public DataSet Get_Files_Search(string key)
        {
          
            dbAccess db = new dbAccess();
            db.AddParameter("@key", key);
            return db.ExecuteDataSet("SP_GETFILEDETAILSSEARCH");
        }

    }
}