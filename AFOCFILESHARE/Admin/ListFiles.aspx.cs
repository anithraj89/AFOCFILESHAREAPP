using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AFOCFILESHARE.Access;
using System.Data;
using System.Text;

using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Data.SqlClient;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;


namespace AFOCFILESHARE.Admin
{
    public partial class ListFiles : System.Web.UI.Page
    {
        protected AFOCFILESHARE.Business.FileUpload obj = new AFOCFILESHARE.Business.FileUpload();
        public bool Search = false;
        public string key;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public StringBuilder getWhileLoopData()
        {
            StringBuilder htmlStr = new StringBuilder();
            DataSet ds = new DataSet();

            if (!Search)
            {

                ds = obj.Get_Files_List();
            }
            else
            {

                ds = obj.Get_Files_Search(key);

            }

            DataTable dt = new DataTable();
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                if (dt.Rows.Count == 0 || ds.Tables.Count == 0)
                {
                    htmlStr.Append("<tr><td class=" + "'align-center'" + " colspan=6>No Data Found</td></tr>");
                }

                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        int rowno = Convert.ToInt32(dr[0].ToString());
                        int id = Convert.ToInt32(dr[1].ToString());
                        string Name = dr[2].ToString();
                        string extension = dr[3].ToString();
                        string user = dr[4].ToString();
                        decimal size = Convert.ToDecimal(dr[5].ToString());

                        //htmlStr.Append("<tr><td class=" + "'align-center'" + ">" + rowno + "</td><td>" + Name + "</td><td>" + extension + "</td><td>" + size + "</td><td>" + user + "</td><td><a href='../FileDownloader.ashx?file=" + Name + "&id=" + id + "' target='_blank' >Download</a></td><td><a href='../FileExport.ashx?file=" + Name + "&id=" + id + "' target='_blank' >ExportToPDF</a></td></tr>");
                        htmlStr.Append("<tr><td class=" + "'align-center'" + ">" + rowno + "</td><td>" + Name + "</td><td>" + extension + "</td><td>" + size + "</td><td>" + user + "</td><td><a href='../FileExport.ashx?file=" + Name + "&id=" + id + "' target='_blank' >Export To PDF</a></td></tr>");
                    }
                }
            }

            return htmlStr;
        }

        protected void btnsearch_Click(object sender, ImageClickEventArgs e)
        {
            key = txtsearch.Text;
            Search = true;
            getWhileLoopData();
        }

        //protected void ExportToPDF_Click(object sender, EventArgs e)
        //{
        //    //Get the data from database into datatable
        //    string strQuery = "select * from Excel where fileid=40";
        //    SqlCommand cmd = new SqlCommand(strQuery);
        //    DataTable dt = GetData(cmd);

        //    //Create a dummy GridView
        //    GridView GridView1 = new GridView();
        //    GridView1.AllowPaging = false;
        //    GridView1.DataSource = dt;
        //    GridView1.DataBind();

        //    Response.ContentType = "application/pdf";
        //    Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    StringWriter sw = new StringWriter();
        //    HtmlTextWriter hw = new HtmlTextWriter(sw);
        //    GridView1.RenderControl(hw);
        //    StringReader sr = new StringReader(sw.ToString());
        //    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        //    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        //    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //    pdfDoc.Open();
        //    htmlparser.Parse(sr);
        //    pdfDoc.Close();
        //    Response.Write(pdfDoc);
        //    Response.End();  
        //}

        //private DataTable GetData(SqlCommand cmd)
        //{
        //    DataTable dt = new DataTable();
        //    String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["Connection_String"].ConnectionString;
        //    SqlConnection con = new SqlConnection(strConnString);
        //    SqlDataAdapter sda = new SqlDataAdapter();
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Connection = con;
        //    try
        //    {
        //        con.Open();
        //        sda.SelectCommand = cmd;
        //        sda.Fill(dt);
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        con.Close();
        //        sda.Dispose();
        //        con.Dispose();
        //    }
        //}
       

        
    }
}