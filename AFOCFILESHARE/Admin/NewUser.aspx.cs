using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Security.Cryptography;
using System.IO;
using System.Text;


namespace AFOCFILESHARE.Admin
{
    public partial class NewUser : System.Web.UI.Page
    {
        protected AFOCFILESHARE.Business.Client objProfile = new AFOCFILESHARE.Business.Client();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
        private void Clear()
        {
            try
            {
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtRePassword.Text = "";
                txtEmail.Text = "";
                txtEmail_Retype.Text = "";
                ddlPrivilage.SelectedIndex = 0;
                lblUsernameError.Text = "";

            }
            catch
            {
            }
        }

        //code to check whether client username already exists to another client
        private int Check_Username_Already_Exists(string Username)
        {
            int count = 0;
            try
            {
                count = Convert.ToInt32(objProfile.Load_User_Username_Count_By_Text(Username));

            }
            catch
            {
            }
            return count;
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

                int len = stringToDecrypt.Length; inputByteArray = Convert.FromBase64String(stringToDecrypt);


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

        
        protected void btnCancel_Click1(object sender, EventArgs e)
        {
            Response.Redirect("adminhome.aspx");
        }

        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            int countUsername = Check_Username_Already_Exists(txtUsername.Text);

            if (countUsername >= 1)
            {
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Exists", "alert('Username  already Exists')", true);
                // lblEmailError.Text = "";
                //divEmailError.Visible = false;
                lblUsernameError.Text = "Username  already exists.";
                divUsernameError.Visible = true;

            }
            else
            {
                try
                {
                    objProfile.First_Name = txtFirstName.Text;
                    objProfile.Last_Name = txtLastName.Text;
                    objProfile.User_Name = (txtUsername.Text).ToLower();
                    objProfile.Password = DESEncrypt(txtPassword.Text);
                    objProfile.Email = txtEmail.Text;
                    objProfile.Privilage = Convert.ToInt32(ddlPrivilage.SelectedValue);
                    objProfile.Insert_Client_Login_Details(objProfile);
                    AFOCFILESHARE.Business.Email.sendMail("infoafocdubai@gmail.com", txtEmail.Text, "", "", "AFOC File Portal Registration", "<pre><h1>AFOC File Portal Registration</h1><h3><br/><br/>Dear " + txtFirstName.Text + ",<br/>        We have received a request from AFOC that you have registered an account as a User in AFOC File Portal. We are sending your username and password along with this email. Please note the username and password for using the AFOC File Portal website.<br/><br/>        Your username for AFOC File Portal login is.<br/>        " + txtUsername.Text + "<br/>        Your password for AFOC File Portal login is.<br/>        " + txtPassword.Text + "<br/><br/>        If you do not registered, kindly inform us.<br/><br/> Thank You,<br/> afocfileapp.com <br/> P.O Box:6382,<br/> Abu Dhabi,<br/> United Arab Emirates <br/><br/>Request generated by: <br/> URL:<a href='http://www.afocfileapp.com'> http://www.afocfileapp.com </a></h3></pre>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User Created Successfully...please check your Email.')", true);
                    Clear();


                }


                catch
                {

                }
            }

        }

        
    }
}