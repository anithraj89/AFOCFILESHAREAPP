using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using AFOCFILESHARE.Access;


namespace AFOCFILESHARE.Business
{
    public class Admin_User
    {

        private string _username;
        private string _password;
        private string _status;
        private int _login_Id;


        public int Login_Id
        {
            get { return _login_Id; }
            set { _login_Id = value; }
        }
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }


        public DataSet Select_User_Password(Admin_User user)
        {
            dbAccess db = new dbAccess();
            db.AddParameter("@UserName", user._username);
            db.AddParameter("@Password", user.Password);
            return db.ExecuteDataSet("sp_CheckLogin");
        }

        public int Get_File_UploadCount()
        {
            dbAccess db = new dbAccess();

            return db.ExecuteStoredProcedure("sp_GetUploadCount");

        }
        public int Get_File_DownloadCount()
        {
            dbAccess db = new dbAccess();

            return db.ExecuteStoredProcedure("sp_GetDownloadCount");

        }
        public int Get_UserCount()
        {
            dbAccess db = new dbAccess();

            return db.ExecuteStoredProcedure("sp_GetUserCount");

        }
        
    }
}