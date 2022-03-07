using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tutorial10
{
    public partial class Reset : System.Web.UI.Page
    {
        #region Variable Declaration and Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private string constring = ConfigurationManager.ConnectionStrings["userDB"].ConnectionString;

        #endregion Variable Declaration and Page Load

        #region Change new Password and Send Email

        /// <summary>
        /// Changing new password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNewPass.Text) && !string.IsNullOrEmpty(txtConfirmPass.Text))
            {
                if (txtNewPass.Text == txtConfirmPass.Text)
                {
                    SendEmail();
                    string email = Session["Email"].ToString();
                    SqlConnection con = new SqlConnection(constring);
                    SqlCommand cmd = new SqlCommand("Update tbl_User Set Password=@Password,Status=0 Where Name=@Name", con);
                    cmd.Parameters.AddWithValue("Name", email);
                    cmd.Parameters.AddWithValue("Password", txtNewPass.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    LtlMessage.Text = "confirm password must be same with new password";
                }
            }
            else
            {
                LtlMessage.Text = "please fill your password and confirm password";
            }
        }

        /// <summary>
        /// Sending Email
        /// </summary>
        private void SendEmail()
        {
            try
            {
                string to = Session["Email"].ToString(); //To address
                string from = "yehtetaung791998@gmail.com"; //From address
                MailMessage message = new MailMessage(from, to);
                string mailbody = "<center><h1>Resetting Password</h1></center>";
                mailbody += "<p>Dear Sir,</p><br>";
                mailbody += "<p style='padding-left:30px;'>Congratulation</p>";
                mailbody += "<p style='padding-left:30px;'>Your resetting password is successful</p>";
                mailbody += "<p style='padding-left:100px;'>From Company</p>";
                message.Subject = "Resetting password";
                message.Body = mailbody;
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;
                SmtpClient client = new SmtpClient("smtp.gmail.com", 578); //Gmail smtp
                System.Net.NetworkCredential basicCredential1 = new
                System.Net.NetworkCredential("yehtetaung791998@gmail.com", "password");
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = basicCredential1;
                client.Send(message);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        #endregion Change new Password and Send Email
    }
}