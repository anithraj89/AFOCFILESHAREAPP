using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.OleDb;
using System.Configuration;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Text;
using System.Net.Mail;
using System.Net.Mime;


namespace AFOCFILESHARE.Admin
{
    public partial class ExcelUpload : System.Web.UI.Page
    {
        protected AFOCFILESHARE.Business.FileUpload obj = new AFOCFILESHARE.Business.FileUpload();
        DataTable dt = new DataTable();
        OleDbConnection Econ;
        SqlConnection con;
        string CommandText;
        string conStr = "";
        string constr, Query, sqlconn;  
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        private void ExcelConn(string FilePath)
        {

            constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", FilePath);
            Econ = new OleDbConnection(constr);

        }
        private void connection()
        {
            sqlconn = ConfigurationManager.ConnectionStrings["Connection_String"].ConnectionString;
            con = new SqlConnection(sqlconn);

        }

        private void InsertExcelRecords(string FilePath)
        {
            ExcelConn(FilePath);
            Query = string.Format("Select [Name],[City],[Address],[Designation] FROM [Sheet1$]");  
            //Query = string.Format("SELECT * FROM [Sheet1$]");
            OleDbCommand Ecom = new OleDbCommand(Query, Econ);
            Econ.Open();

            DataSet ds = new DataSet();
            OleDbDataAdapter oda = new OleDbDataAdapter(Query, Econ);
            Econ.Close();
            oda.Fill(ds);
            DataTable Exceldt = ds.Tables[0];
            connection();
            //creating object of SqlBulkCopy    
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            //assigning Destination table name    
            objbulk.DestinationTableName = "Excel";
            //Mapping Table column    
            objbulk.ColumnMappings.Add("Name", "Name");
            objbulk.ColumnMappings.Add("City", "City");
            objbulk.ColumnMappings.Add("Address", "Address");
            objbulk.ColumnMappings.Add("Designation", "Designation");
            //inserting Datatable Records to DataBase    
            con.Open();
            objbulk.WriteToServer(Exceldt);
            con.Close();

        }  
        protected void btnsubmit_Click1(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

                string FilePath = Server.MapPath(FolderPath + FileName);

                obj.UserId = Convert.ToInt32(Session["userId"]);
                obj.FilePath = FilePath;
                obj.FileName = FileName;
                obj.FileSize = FileUpload1.FileContent.Length;
                //get file extension
                obj.Extension = Extension;
                string fileType = null;
                switch (obj.Extension)
                {
                    
                    case ".xls":
                        fileType = "application/vnd.ms-excel";
                        break;
                    case ".xlsx":
                        fileType = "application/vnd.ms-excel";
                        break;
                   

                    default:
                        fileType = "Unknown";
                        break;
                }
                obj.FileType = fileType.ToString();
               // FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Uploads/" + obj.FileName.Trim()));



                //Response.ContentType = "application/pdf";
                //Response.AddHeader("content-disposition", "attachment;filename=TestPage.pdf");
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //StringWriter sw = new StringWriter();
                //HtmlTextWriter hw = new HtmlTextWriter(sw);
                //this.Page.RenderControl(hw);
                //StringReader sr = new StringReader(sw.ToString());
                //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
                //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                //pdfDoc.Open();
                //htmlparser.Parse(sr);
                //pdfDoc.Close();
                //Response.Write(pdfDoc);
                //Response.End();
             

               


              //MailMessage mail = new MailMessage();
               // SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
              //  mail.From = new MailAddress(txtFromEmailID.Text);
               // mail.To.Add(txtTOEmailID.Text);
              //  mail.Subject = txtSubject.Text;
              //  mail.Attachments.Add(new Attachment(FilePath));

              //  SmtpServer.Port = 587;
              //  SmtpServer.Credentials = new System.Net.NetworkCredential(txtFromEmailID.Text, txtPassword.Text);
               // SmtpServer.EnableSsl = true;
              //  SmtpServer.Send(mail);


                 //anith1
                MailMessage mail = new MailMessage();
              
               string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                Attachment myAttachment = new Attachment(FileUpload1.FileContent, fileName);

                mail.Attachments.Add(myAttachment);
               // close anith1
                

                ////MemoryStream ms = new MemoryStream();

                ////mail.Attachments.Add(new Attachment(ms, pdfDoc));

                //MailMessage message = new MailMessage();
                //FileStream fileStream = File.Create("PdfPath");
                //var memoryStream = new MemoryStream();
                //fileStream.Position = 0;
                //fileStream.CopyTo(memoryStream);
                //message.Attachments.Add(new Attachment(memoryStream, Path.GetFileName("PdfPath")));

              


                FileUpload1.SaveAs(FilePath);
                Import_To_Grid(FilePath, Extension);
                SaveDataBase();
                obj.INSERT_File_DETAILS(obj);
                
               // obj.INSERT_File_Excel(obj);
                //divLoginError.Visible = false;

                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('The file has been uploaded.')", true);

                AFOCFILESHARE.Business.Email.sendMailAttachment("infoafocdubai@gmail.com", "nith2799@gmail.com", "", "", "AFOC File Portal Registration", "<pre><h1>AFOC File Portal Registration</h1><h3><br/><br/>Dear ,<br/>        We have received a request from AFOC that you have registered an account as a User in AFOC File Portal. We are sending your username and password along with this email. Please note the username and password for using the AFOC File Portal website.<br/><br/>        Your username for AFOC File Portal login is.<br/>        " + myAttachment + "<br/>        Your password for AFOC File Portal login is.<br/>        <br/><br/>        If you do not registered, kindly inform us.<br/><br/> Thank You,<br/> afocfileapp.com <br/> P.O Box:6382,<br/> Abu Dhabi,<br/> United Arab Emirates <br/><br/>Request generated by: <br/> URL:<a href='http://www.afocfileapp.com'> http://www.afocfileapp.com </a></h3></pre>", myAttachment);
               ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('The file has been uploaded.');window.location = 'ListFiles.aspx';", true);
            }



           //// string CurrentFilePath = Path.GetFullPath(FileUpload1.PostedFile.FileName);
           // string CurrentFilePath = Server.MapPath(FileUpload1.PostedFile.FileName);
           // InsertExcelRecords(CurrentFilePath); 
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
       

        

        private void SaveDataBase()
        {
            string ssqltable = "Excel";
            OleDbConnection oledbconn = new OleDbConnection(conStr);
            OleDbCommand oledbcmd = new OleDbCommand(CommandText, oledbconn);
            oledbconn.Open();
            OleDbDataReader dr = oledbcmd.ExecuteReader();
            connection();
            SqlBulkCopy bulkcopy = new SqlBulkCopy(sqlconn);
            bulkcopy.DestinationTableName = ssqltable;
            while (dr.Read())
            {
                bulkcopy.WriteToServer(dr);
            }
            dr.Close();
            oledbconn.Close();
        }

        private void Import_To_Grid(string FilePath, string Extension)
        {
            
            switch (Extension)
            {
                case ".xls": //Excel 97-03
                    conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]
                             .ConnectionString;
                    break;
                case ".xlsx": //Excel 07
                    conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]
                              .ConnectionString;
                    break;
            }
            conStr = String.Format(conStr, FilePath);
            OleDbConnection connExcel = new OleDbConnection(conStr);
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();
            
            cmdExcel.Connection = connExcel;

            //Get the name of First Sheet
            connExcel.Open();
            DataTable dtExcelSchema;
            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            connExcel.Close();

            //Read Data from First Sheet
            connExcel.Open();
            CommandText = "SELECT * From [" + SheetName + "]";
            cmdExcel.CommandText = CommandText;
            oda.SelectCommand = cmdExcel;
            oda.Fill(dt);
            connExcel.Close();

            //Bind Data to GridView
            //GridView1.Caption = Path.GetFileName(FilePath);
            //GridView1.DataSource = dt;
            //GridView1.DataBind();
        }

        protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //string FolderPath = ConfigurationManager.AppSettings["FolderPath"];
            //string FileName = GridView1.Caption;
            //string Extension = Path.GetExtension(FileName);
            //string FilePath = Server.MapPath(FolderPath + FileName);

            //Import_To_Grid(FilePath, Extension);
            //GridView1.PageIndex = e.NewPageIndex;
            //GridView1.DataBind();
        }


        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        //protected void btnExportPDF_Click(object sender, EventArgs e)
        //{
        //    Response.ContentType = "application/pdf";
        //    Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    StringWriter sw = new StringWriter();
        //    HtmlTextWriter hw = new HtmlTextWriter(sw);
        //    GridView1.AllowPaging = false;
        //    GridView1.DataBind();
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



//        public void importdatafromexcel(string excelfilepath)
//        {
//        //declare variables - edit these based on your particular situation
//        string ssqltable = "tdatamigrationtable";
//        // make sure your sheet name is correct, here sheet name is sheet1, so you can change your sheet name if have different
//        string myexceldataquery = "select student,rollno,course from [sheet1$]";
//        try
//        {
//        //create our connection strings
//        string sexcelconnectionstring = @"provider=microsoft.jet.oledb.4.0;data source=" + excelfilepath +
//        ";extended properties=" + "\"excel 8.0;hdr=yes;\"";
//        string ssqlconnectionstring = "server=mydatabaseservername;user id=dbuserid;password=dbuserpassword;database=databasename;connection reset=false";
//        //execute a query to erase any previous data from our destination table
//        string sclearsql = "delete from " + ssqltable;
//        SqlConnection sqlconn = new SqlConnection(ssqlconnectionstring);
//        SqlCommand sqlcmd = new SqlCommand(sclearsql, sqlconn);
//        sqlconn.Open();
//        sqlcmd.ExecuteNonQuery();
//        sqlconn.Close();
//        //series of commands to bulk copy data from the excel file into our sql table
//        OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
//        OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);
//        oledbconn.Open();
//        OleDbDataReader dr = oledbcmd.ExecuteReader();
//        SqlBulkCopy bulkcopy = new SqlBulkCopy(ssqlconnectionstring);
//        bulkcopy.DestinationTableName = ssqltable;
//        while (dr.Read())
//        {
//            bulkcopy.WriteToServer(dr);
//        }
     
//        oledbconn.Close();
//    }
//    catch (Exception ex)
//    {
//        //handle exception
//    }
//}


        //public void ReadExcel()
        //{

        //    string connString = ConfigurationManager.ConnectionStrings["xlsx"].ConnectionString;
        //    // Create the connection object
        //    OleDbConnection oledbConn = new OleDbConnection(connString);
        //    try
        //    {
        //        // Open connection
        //        oledbConn.Open();

        //        // Create OleDbCommand object and select data from worksheet Sheet1
        //        OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", oledbConn);

        //        // Create new OleDbDataAdapter
        //        OleDbDataAdapter oleda = new OleDbDataAdapter();

        //        oleda.SelectCommand = cmd;

        //        // Create a DataSet which will hold the data extracted from the worksheet.
        //        DataSet ds = new DataSet();

        //        // Fill the DataSet from the data extracted from the worksheet.
        //        oleda.Fill(ds, "Customer");

        //        // Bind the data to the GridView
        //        //GridView1.DataSource = ds.Tables[0].DefaultView;
        //       // GridView1.DataBind();
        //    }
        //    catch
        //    {
        //    }
        //    finally
        //    {
        //        // Close connection
        //        oledbConn.Close();
        //    }
        //}

        //public void CreateDatabase()
        //{
        //    //string sCreateDatabase = "CREATE DATABASE SampleDb";
        //    string sCreateTable = "CREATE TABLE Books (BookID INTEGER PRIMARY KEY IDENTITY," +
        //        "Title CHAR(50) NOT NULL , Author CHAR(50), " +
        //        "PageCount INTEGER,Topic CHAR(30),Code CHAR(15))";
        //    string sInsertFirstRow = "INSERT INTO BOOKS (TITLE,AUTHOR,PAGECOUNT,TOPIC,CODE)"
        //        + "VALUES('Test Book','Test Author', 100, 'Test Topic', 'Test Code');";

        //    SqlConnection mycon = new SqlConnection();
        //    //mycon.ConnectionString = ConfigurationManager.ConnectionStrings["SampleDb"].ConnectionString;//"workstation id=;initial catalog=; integrated security=SSPI";

        //    SqlCommand mycomm = new SqlCommand();
        //    //mycomm.CommandType = CommandType.Text;
        //    //mycomm.CommandText = sCreateDatabase;
        //    mycomm.Connection = mycon;

        //    //try
        //    //{
        //    //    //    Open the connection
        //    //    mycon.Open();
        //    //    //    Execute CreateDatabase query
        //    //    mycomm.ExecuteNonQuery();
        //    //}
        //    //catch
        //    //{
        //    //    //    Catch any errors and show the error message
        //    //    //MessageBox.Show(" The database already exists. ");
        //    //}
        //    //finally
        //    //{
        //    //    mycon.Close();
        //    //}

        //    // string connString = ConfigurationManager.ConnectionStrings["SampleDb"].ConnectionString;

        //    mycon.ConnectionString = ConfigurationManager.ConnectionStrings["SampleDb"].ConnectionString;
        //    try
        //    {
        //        //    Open the connection
        //        mycon.Open();
        //        //    Execute CreateTable query
        //        mycomm.CommandText = sCreateTable;
        //        mycomm.ExecuteNonQuery();
        //        //    Execute InsertFirstRow query
        //        mycomm.CommandText = sInsertFirstRow;
        //        mycomm.ExecuteNonQuery();
        //    }
        //    catch
        //    {
        //        //    Catch any errors and show the error message
        //        //MessageBox.Show(" There is already a table named 'Books' in the database. ");
        //    }
        //    finally
        //    {
        //        mycon.Close();
        //    }
        //}


    }
}