using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tutorial10
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        #region Variable Declaration

        private SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["userDB"].ConnectionString);
        private SqlCommand cmd;

        #endregion Variable Declaration

        #region Login and Reset Password

        /// <summary>
        /// Login
        /// </summary>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["userDB"].ConnectionString);
            cmd = new SqlCommand("SELECT Password FROM tbl_User WHERE Name=@Name and Password=@Password", con);
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
            }
            else
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["userDB"].ConnectionString);
                string name = txtUserName.Text;
                int id;
                cmd = new SqlCommand("SELECT * FROM tbl_User WHERE Name='" + name + "'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    id = Convert.ToInt32(dr["id"]);
                    name = dr["Name"].ToString();
                    ResetPassword(id, name);
                }
                con.Close();
            }
        }

        /// <summary>
        /// Resetting password
        /// </summary>
        private void ResetPassword(int id, string name)
        {
            Session["Email"] = name;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["userDB"].ConnectionString);
            cmd = new SqlCommand("Update tbl_User set Password=NULL,Status=1 WHERE id=@id", con);
            cmd.Parameters.AddWithValue("id", id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Reset.aspx");
        }

        #endregion Login and Reset Password
    }
}