using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AFOCFILESHARE.Access;
using System.Data;
using System.Text;


namespace AFOCFILESHARE.Users
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

                        htmlStr.Append("<tr><td class=" + "'align-center'" + ">" + rowno + "</td><td>" + Name + "</td><td>" + extension + "</td><td>" + size + "</td><td>" + user + "</td><td><a href='../FileDownloader.ashx?file=" + Name + "&id=" + id + "' target='_blank' >Download</a></td></tr>");
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
    }
}