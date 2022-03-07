using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tutorial7
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string constring = ConfigurationManager.ConnectionStrings["userDB"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_User WHERE Name=@Name and Password=@Password", con);
            cmd.Parameters.AddWithValue("Name", txtUserName.Text);
            cmd.Parameters.AddWithValue("Password", txtPassword.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            if (dt.Rows.Count > 0)
            {
                Session["name"] = txtUserName.Text;
                Response.Redirect("Default.aspx");
                Session.RemoveAll();
            }
            else
            {
                LtlMessage.Text = "Username or Password is invalid";
            }
        }
    }
}