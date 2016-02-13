using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AFOCFILESHARE.Business;
using AFOCFILESHARE.Access;
using System.IO;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Data.SqlClient;


using iTextSharp.text;

using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Web.UI;



namespace AFOCFILESHARE
{
    /// <summary>
    /// Summary description for FileExport
    /// </summary>
    public class FileExport : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        protected AFOCFILESHARE.Business.FileUpload obj = new AFOCFILESHARE.Business.FileUpload();
        public void ProcessRequest(HttpContext context)
        {
            string file = context.Request.QueryString["file"];
            string[] filename = file.Split('.');
            int len = filename.Length;
            string name= string.Empty;
            for (int i = 0; i < len-1; i++) 
            {
                name += filename[i];
                name += ".";
            }
            int id = Convert.ToInt32(context.Request.QueryString["id"]);
            obj.FileId = id;
            obj.UserId = Convert.ToInt32(context.Session["userId"]);
            //Get the data from database into datatable
            string strQuery = "select Name,City,Address,Designation from Excel where fileid= " + id + " ";
            SqlCommand cmd = new SqlCommand(strQuery);
            DataTable dt = GetData(cmd);

            //Create a dummy GridView
            GridView GridView1 = new GridView();
            GridView1.AllowPaging = false;
            GridView1.DataSource = dt;
            GridView1.DataBind();
            obj.Downlaod_File(obj);


           
            context.Response.ContentType = "application/pdf";
            context.Response.AddHeader("content-disposition", "attachment;filename=" + name + "pdf");
           // context.Response.TransmitFile(filePath);
            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView1.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);

            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, context.Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            context.Response.Write(pdfDoc);
            context.Response.End();
          
        }


        private DataTable GetData(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["Connection_String"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            try
            {
                con.Open();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                sda.Dispose();
                con.Dispose();
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