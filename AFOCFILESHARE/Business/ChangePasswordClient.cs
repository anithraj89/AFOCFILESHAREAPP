using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using AFOCFILESHARE.Access;

namespace AFOCFILESHARE.Business
{
    public class ChangePasswordClient
    {
        private string _User_Name;
        private string _Current_Password;
        private string _New_Password;
        private string _Email_Address;

        public String User_Name
        {
            get { return _User_Name; }
            set { _User_Name = value; }
        }

        public string Current_Password
        {
            get { return _Current_Password; }
            set { _Current_Password = value; }
        }

        public string New_Password
        {
            get { return _New_Password; }
            set { _New_Password = value; }
        }

        public string Email_Address
        {
            get { return _Email_Address; }
            set { _Email_Address = value; }
        }


        public string Load_Password_By_Id(ChangePasswordClient client)
        {
            dbAccess db = new dbAccess();
            db.AddParameter("@UserId", client.User_Name);
            return db.ExecuteScalar("SP_TBL_CLIENT_LOGIN_LOAD_PASSWORD_BY_ID").ToString();
        }
        public int Change_Password(ChangePasswordClient client)
        {
            dbAccess db = new dbAccess();
            db.AddParameter("@UserId", client.User_Name);
            db.AddParameter("@Password", client.New_Password);
            return db.ExecuteNonQuery("SP_TBL_CLIENT_LOGIN_UPDATE_PASSWORD");
        }
        public string Load_Client_Current_Email_By_Id(ChangePasswordClient client)
        {
            dbAccess db = new dbAccess();
            db.AddParameter("@Client_Id", client.User_Name);
            return db.ExecuteScalar("SP_TBL_CLIENT_LOGIN_LOAD_CURRENT_EMAIL_BY_ID").ToString();
        }
        public string Load_Client_Current_Username_By_Id(ChangePasswordClient client)
        {
            dbAccess db = new dbAccess();
            db.AddParameter("@Usernmae", client.User_Name);
            return db.ExecuteScalar("SP_TBL_CLIENT_LOGIN_LOAD_CURRENT_USERNAME_BY_ID").ToString();
        }
        public string Load_User_Current_Email_By_Id(ChangePasswordClient client)
        {
            dbAccess db = new dbAccess();
            db.AddParameter("@Usernmae", client.User_Name);
            return db.ExecuteScalar("SP_EmailidbyId").ToString();
        }
        public string Load_User_Current_Username_By_Id(ChangePasswordClient client)
        {
            dbAccess db = new dbAccess();
            db.AddParameter("@Usernmae", client.User_Name);
            return db.ExecuteScalar("SP_UsernamebyId").ToString();
        }
        public DataSet Load_User_Password_By_Id(ChangePasswordClient client)
        {
            dbAccess db = new dbAccess();
            db.AddParameter("@Username", client.User_Name);
            db.AddParameter("@Password", client.Current_Password);
            return db.ExecuteDataSet("SP_checklogin");
        }
        public int Change_User_Password(ChangePasswordClient client)
        {
            dbAccess db = new dbAccess();
            db.AddParameter("@Username", client.User_Name);
            db.AddParameter("@newPassword", client.New_Password);
            return db.ExecuteNonQuery("SP_updatepassword");
        }
    }
}