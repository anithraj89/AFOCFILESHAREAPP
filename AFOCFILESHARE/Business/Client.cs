using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using AFOCFILESHARE.Access;

namespace AFOCFILESHARE.Business
{
    public class Client
    {
        private string _Email;
        private string _First_Name;
        private string _Last_Name;
        private string _User_Name;
        private string _Password;
        private int _Privilage;
        private string _Client_Name;
        private string _Description;
        private string _Address1;
        private string _Address2;
        private string _City;
        private string _State;
        private string _Pincode;
        private string _Country;
        private string _Region;
        private string _Phone;
        private string _Mobile;
        private string _Info_Email;
        private string _Website;
        private string _SeqQues;
        private string _SeqAns;
        private bool _NewsLetter;
        private bool _Offers;
        private int _Login_Id;


        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public string First_Name
        {
            get { return _First_Name; }
            set { _First_Name = value; }
        }

        public string Last_Name
        {
            get { return _Last_Name; }
            set { _Last_Name = value; }
        }

        public string User_Name
        {
            get { return _User_Name; }
            set { _User_Name = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public int Privilage
        {
            get { return _Privilage; }
            set { _Privilage = value; }
        }
        
        public string Client_Name
        {
            get { return _Client_Name; }
            set { _Client_Name = value; }
        }

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public string Address1
        {
            get { return _Address1; }
            set { _Address1 = value; }
        }

        public string Address2
        {
            get { return _Address2; }
            set { _Address2 = value; }
        }

        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        public string State
        {
            get { return _State; }
            set { _State = value; }
        }

        public string Pincode
        {
            get { return _Pincode; }
            set { _Pincode = value; }
        }

        public string Country
        {
            get { return _Country; }
            set { _Country = value; }
        }

        public string Region
        {
            get { return _Region; }
            set { _Region = value; }
        }

        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        public string Mobile
        {
            get { return _Mobile; }
            set { _Mobile = value; }
        }

        public string Info_Email
        {
            get { return _Info_Email; }
            set { _Info_Email = value; }
        }

        public string Website
        {
            get { return _Website; }
            set { _Website = value; }
        }

        public string SeqQues
        {
            get { return _SeqQues; }
            set { _SeqQues = value; }
        }

        public string SeqAns
        {
            get { return _SeqAns; }
            set { _SeqAns = value; }
        }

        public bool NewsLetter
        {
            get { return _NewsLetter; }
            set { _NewsLetter = value; }
        }

        public bool Offers
        {
            get { return _Offers; }
            set { _Offers = value; }
        }

        public int Login_Id
        {
            get { return _Login_Id; }
            set { _Login_Id = value; }
        }

        public int Load_Client_Email_Count_By_Text(string Email)
        {
            dbAccess db = new dbAccess();
            db.AddParameter("@Email", Email);
            return Convert.ToInt32(db.ExecuteScalar("SP_TBL_CLIENT_LOGIN_LOAD_EMAIL_COUNT_BY_TEXT"));
        }
        public int Load_Client_Username_Count_By_Text(string Username)
        {
            dbAccess db = new dbAccess();
            db.AddParameter("@Username", Username);
            return Convert.ToInt32(db.ExecuteScalar("SP_TBL_CLIENT_LOGIN_LOAD_USERNAME_COUNT_BY_TEXT"));
        }

        //public int insert_client(Client profile)
        //{
        //    dbAccess db = new dbAccess();
        //    db.AddParameter("@First_Name", profile.First_Name);
        //    db.AddParameter("@Last_Name", profile.Last_Name);
        //    db.AddParameter("@User_Name", profile.User_Name);
        //    db.AddParameter("@Password", profile.Password);
        //    db.AddParameter("@Email", profile.Email);
        //    db.AddParameter("@Gender", profile.Privilage);
        //    db.AddParameter("@Client_Name", profile.Client_Name);
        //    db.AddParameter("@Description", profile.Description);
        //    db.AddParameter("@Address1", profile.Address1);
        //    db.AddParameter("@Address2", profile.Address2);
        //    db.AddParameter("@City", profile.City);
        //    db.AddParameter("@State", profile.State);
        //    db.AddParameter("@Country", profile.Country);
        //    db.AddParameter("@Region", profile.Region);
        //    db.AddParameter("@Pincode", profile.Pincode);
        //    db.AddParameter("@Phone", profile.Phone);
        //    db.AddParameter("@Mobile", profile.Mobile);
        //    db.AddParameter("@Info_Email", profile.Info_Email);
        //    db.AddParameter("@Website", profile.Website);
        //    db.AddParameter("@SeqQues", profile.SeqQues);
        //    db.AddParameter("@SeqAns", profile.SeqAns);
        //    db.AddParameter("@NewsLetter", profile.NewsLetter);
        //    db.AddParameter("@Offers", profile.Offers);
        //    return db.ExecuteNonQuery("SP_TBL_CLIENT_PROFILE_INSERT_V2");
        //}

        public int Load_User_Email_Count_By_Text(string Email)
        {
            dbAccess db = new dbAccess();
            db.AddParameter("@Email", Email);
            return Convert.ToInt32(db.ExecuteScalar("SP_TBL_LOGIN_V2_LOAD_EMAIL_COUNT_BY_TEXT"));
        }
        public int Load_User_Username_Count_By_Text(string Username)
        {
            dbAccess db = new dbAccess();
            db.AddParameter("@Username", Username);
            return Convert.ToInt32(db.ExecuteScalar("sp_checkuser"));
        }

        public int Insert_Client_Login_Details(Client profile)
        {
            dbAccess db = new dbAccess();
            db.AddParameter("@FirstName", profile.First_Name);
            db.AddParameter("@LastName", profile.Last_Name);
            db.AddParameter("@UserName", profile.User_Name);
            db.AddParameter("@Password", profile.Password);
            db.AddParameter("@Email", profile.Email);
            db.AddParameter("@Usergroupid", profile.Privilage);
            
            return db.ExecuteNonQuery("SP_CreateNewUser");
        }

        public int update_client(Client profile)
        {
            dbAccess db = new dbAccess();
            db.AddParameter("@First_Name", profile.First_Name);
            db.AddParameter("@Last_Name", profile.Last_Name);
            db.AddParameter("@User_Name", profile.User_Name);
            db.AddParameter("@Email", profile.Email);
            db.AddParameter("@Gender", profile.Privilage);
            db.AddParameter("@Client_Name", profile.Client_Name);
            db.AddParameter("@Description", profile.Description);
            db.AddParameter("@Address1", profile.Address1);
            db.AddParameter("@Address2", profile.Address2);
            db.AddParameter("@City", profile.City);
            db.AddParameter("@State", profile.State);
            db.AddParameter("@Country", profile.Country);
            db.AddParameter("@Region", profile.Region);
            db.AddParameter("@Pincode", profile.Pincode);
            db.AddParameter("@Phone", profile.Phone);
            db.AddParameter("@Mobile", profile.Mobile);
            db.AddParameter("@Info_Email", profile.Info_Email);
            db.AddParameter("@Website", profile.Website);
            db.AddParameter("@Login_Id", profile.Login_Id);
            return db.ExecuteNonQuery("SP_TBL_CLIENT_PROFILE_UPDATE_V2");
        }
    }
}