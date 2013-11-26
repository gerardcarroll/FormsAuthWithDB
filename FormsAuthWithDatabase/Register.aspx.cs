using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

namespace FormsAuthWithDatabase
{
    public partial class Register : System.Web.UI.Page
    {
        FormsAuthDBEntities db1 = new FormsAuthDBEntities();

        FormsAuthDBEntities1 db = new FormsAuthDBEntities1();

        string hashPassword = "";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateAccount_Click(object sender, EventArgs e)
        {
            if (TxtPassword.Text == ConfirmPass.Text)
            {
                if(UserNameOK())
                {
                    using (MD5 md5Hash = MD5.Create())
                    {
                        //Let hashPassword = What is returned from the GetMd5Hash method
                        hashPassword = GetMd5Hash(md5Hash, TxtPassword.Text);

                        RegisterNewUser();
                    }
                }

                else
                {
                    LblMatch.Text = "Username already chosen";
                }

            }
            else
            {
                LblMatch.Text = "Passwords do not match";
            }
            
        }

        private void RegisterNewUser()
        {
            Users_tbl user = new Users_tbl();
            user.UserName = TxtUsername.Text;
            user.Password = hashPassword;

            try
            {
                db.Users_tbl.Add(user);
                db.SaveChanges();
            }
            catch
            {
                LblMatch.Text = "Registration has failed";
            }
            finally
            {
                Response.Redirect("Default.aspx");
            }
        }

        private bool UserNameOK()
        {
            var q = from u in db.Users_tbl
                    select u.UserName;

            foreach (var item in q)
            {
                if (TxtUsername.Text == item)
                {
                    return false;
                }                
            }

            return true;
        }

        private string GetMd5Hash(MD5 md5Hash, string p)
        {
            string output = "";

            // Convert the input string to a byte array and compute the hash. 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(p));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            //StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            foreach (byte b in data)
            {
                output += b.ToString("x2");
            }

            //for (int i = 0; i < data.Length; i++)
            //{
            //    sBuilder.Append(data[i].ToString("x2"));
            //}

            // Return the hexadecimal string. 
            return output;
        }
    }
}