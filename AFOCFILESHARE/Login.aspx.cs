using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using AFOCFILESHARE.Access;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using AFOCFILESHARE.Business;
using AFOCFILESHARE.Enums;


namespace AFOCFILESHARE
{
    public partial class Login : System.Web.UI.Page
    {
        protected AFOCFILESHARE.Business.Admin_User objUser = new AFOCFILESHARE.Business.Admin_User();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// code to Encrypt and Decrypt Password
        /// </summary>
        const string DESKey = "AQWSEDRF";
        const string DESIV = "HGFEDCBA";


        public static string DESDecrypt(string stringToDecrypt)//Decrypt the content
        {

            byte[] key;
            byte[] IV;

            byte[] inputByteArray;
            try
            {

                key = Convert2ByteArray(DESKey);

                IV = Convert2ByteArray(DESIV);
                stringToDecrypt = stringToDecrypt.Replace(" ", "+");
                int len = stringToDecrypt.Length;
                inputByteArray = Convert.FromBase64String(stringToDecrypt);



                DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                MemoryStream ms = new MemoryStream(); CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);

                cs.FlushFinalBlock();

                Encoding encoding = Encoding.UTF8; return encoding.GetString(ms.ToArray());
            }

            catch (System.Exception ex)
            {

                throw ex;
            }





        }

        public static string DESEncrypt(string stringToEncrypt)// Encrypt the content
        {

            byte[] key;
            byte[] IV;

            byte[] inputByteArray;
            try
            {

                key = Convert2ByteArray(DESKey);

                IV = Convert2ByteArray(DESIV);

                inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                MemoryStream ms = new MemoryStream(); CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);

                cs.FlushFinalBlock();

                return Convert.ToBase64String(ms.ToArray());
            }

            catch (System.Exception ex)
            {

                throw ex;
            }

        }

        static byte[] Convert2ByteArray(string strInput)
        {

            int intCounter; char[] arrChar;
            arrChar = strInput.ToCharArray();

            byte[] arrByte = new byte[arrChar.Length];

            for (intCounter = 0; intCounter <= arrByte.Length - 1; intCounter++)
                arrByte[intCounter] = Convert.ToByte(arrChar[intCounter]);

            return arrByte;
        }

        protected void dlupdates_ItemCommand(object source, DataListCommandEventArgs e)
        {
            try
            {
                string slink = "Home";
                string sid = e.CommandArgument.ToString();
                string strURL = "../Admin/AdminHome.aspx?";
                if (HttpContext.Current != null)
                {
                    string strURLWithData = strURL + EncryptQueryString(string.Format("link={0}&id={1}&from={0}", slink, sid));
                    HttpContext.Current.Response.Redirect(strURLWithData);
                }
                else
                { }
            }
            catch
            {
            }
        }


        public string EncryptQueryString(string strQueryString)
        {
            EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
            return objEDQueryString.Encrypt(strQueryString, "r0b1nr0y");
        }

        private string DecryptQueryString(string strQueryString)
        {
            EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
            return objEDQueryString.Decrypt(strQueryString, "r0b1nr0y");
        }

        protected void btnlogin_Click1(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dtUserExist = new DataTable();
            DataTable dtUserGroup = new DataTable();
            //Admin_User objUser = new Admin_User();

            string usergroup;
            int usergroupid;
            string user;
            int userid;
            objUser.Username = txtUserName.Value;
            objUser.Password = DESEncrypt(txtPassword.Value);
            ds = objUser.Select_User_Password(objUser);
            dtUserExist = ds.Tables[0];
            if (dtUserExist.Rows[0][0].ToString() == "true")
            {
                dtUserGroup = ds.Tables[1];
                usergroup = dtUserGroup.Rows[0][0].ToString();
                usergroupid = Convert.ToInt32(usergroup);
                user = dtUserGroup.Rows[0][1].ToString();
                userid = Convert.ToInt32(user);
                Session["user"] = txtUserName.Value;
                Session["userId"] = userid;
                Session["userGroupId"] = usergroupid;

                if (usergroupid == (int)FileShareEnums.UserGroups.admin)
                {
                    Response.Redirect("~/Admin/AdminHome.aspx");
                }
                else if (usergroupid == (int)FileShareEnums.UserGroups.user)
                {
                    Response.Redirect("~/Users/Home.aspx");
                }
                else
                {
                    err.Visible = true;
                }
            }
            else
            {
                err.Visible = true;
            }
        }
    }
}