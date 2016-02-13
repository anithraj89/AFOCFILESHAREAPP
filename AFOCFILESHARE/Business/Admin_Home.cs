using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using AFOCFILESHARE.Access;
namespace AFOCFILESHARE.Business 
{
    public class Admin_Home
    {
        private int _id;
      
        private string _22KT;
       

        public int Id
        {
            get { return _id; }
            set { _id = value; }

        }
   

        public string strContents
        {
            get { return _22KT; }
            set { _22KT = value; }

        }

       

        public DataSet Bind_Price_Details()
        {
            dbAccess db = new dbAccess();
            return db.ExecuteDataSet("Sp_select_Genereal ");

        }

        public int Insert_Details(Admin_Home Home)
        {
            dbAccess db = new dbAccess();
            db.AddParameter("@Id", Home.Id);
            db.AddParameter("@22kt", Home.strContents);
            return db.ExecuteNonQuery("SP_INSERT_DETAILS");

        }
       
    }
}