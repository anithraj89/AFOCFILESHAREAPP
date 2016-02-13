using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace AFOCFILESHARE.Users
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            System.Web.Security.FormsAuthentication.SignOut();
            //Response.Redirect("frmLogin.aspx", false);
            Response.Redirect("../Index.aspx", false);
        }
        [WebMethod]
        public static int LogoutCheck()
        {
            if (HttpContext.Current.Session["user"] == null)
            {
                return 0;
            }
            return 1;
        }
    }
}