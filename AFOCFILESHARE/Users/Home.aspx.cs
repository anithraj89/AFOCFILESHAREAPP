using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AFOCFILESHARE.Access;
using AFOCFILESHARE.Business;
using System.Data.SqlClient;

namespace AFOCFILESHARE.Users
{
    public partial class Home : System.Web.UI.Page
    {
        protected AFOCFILESHARE.Business.Admin_User objUser = new AFOCFILESHARE.Business.Admin_User();
        protected void Page_Load(object sender, EventArgs e)
        {
            int UploadCount = Convert.ToInt32(objUser.Get_File_UploadCount());
            lblUpload.Text = UploadCount.ToString();
            int DownloadCount = Convert.ToInt32(objUser.Get_File_DownloadCount());
            lblDownload.Text = DownloadCount.ToString();
            int UserCount = Convert.ToInt32(objUser.Get_UserCount());
            lblUsers.Text = UserCount.ToString();
        }
    }
}