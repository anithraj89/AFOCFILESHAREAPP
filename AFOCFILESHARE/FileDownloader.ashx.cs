using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AFOCFILESHARE.Business;
using AFOCFILESHARE.Access;
using System.IO;

namespace AFOCFILESHARE
{
    /// <summary>
    /// Summary description for FileDownloader
    /// </summary>
    public class FileDownloader : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        protected AFOCFILESHARE.Business.FileUpload obj = new AFOCFILESHARE.Business.FileUpload();
        public void ProcessRequest(HttpContext context)
        {
            string file = context.Request.QueryString["file"];
            int id = Convert.ToInt32(context.Request.QueryString["id"]);
            obj.FileId = id;
            obj.UserId = Convert.ToInt32(context.Session["userId"]);
            string folder = "/uploads/";
            string fileWithFolder = folder + file;

            if (!string.IsNullOrEmpty(file) && File.Exists(context.Server.MapPath(fileWithFolder)))
            {
                //<span class="skimlinks-unlinked">context.Response.Clear</span>();
                context.Response.ContentType = "application/octet-stream";
                //I have set the ContentType to "application/octet-stream" which cover any type of file
                context.Response.AddHeader("content-disposition", "attachment;filename=" + Path.GetFileName(file));
                context.Response.WriteFile(context.Server.MapPath(fileWithFolder));
                //here you can do some statistic or tracking
                //you can also implement other business request such as delete the file after download
                //<span class="skimlinks-unlinked">context.Response.End</span>();
                /// call function to download
                obj.Downlaod_File(obj);
            }
            else
            {
                context.Response.ContentType = "text/plain";
                //<span class="skimlinks-unlinked">context.Response.Write("File</span>ot be found!");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}