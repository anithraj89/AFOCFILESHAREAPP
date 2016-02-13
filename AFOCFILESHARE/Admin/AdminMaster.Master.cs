using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AFOCFILESHARE.Admin
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckLogin();
        }
        private void CheckLogin()
        {
            string domain = Request.Url.Authority.ToString();
            //BaseURL = "http://" + domain + "/";
            //Load menu or Do Any database related work
            if (Session["user"] == null || Session["userGroupId"] == null)
            {

                Response.Redirect("../Login.aspx", false);
            }
            else
                if (Session["userGroupId"].ToString() != "1")
                {
                    Response.Redirect("../Login.aspx", false);
                }
        }
        protected string IsCurrent(string page)
        {
            return Request.Url.AbsolutePath.ToLower().EndsWith(page.ToLower()) ? "active" : "";
        }
    }
}