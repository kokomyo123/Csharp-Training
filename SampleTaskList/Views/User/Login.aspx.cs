using System;
using System.Data;
using System.Web.UI;

namespace SampleTaskList.Views.User
{
    public partial class Login : System.Web.UI.Page
    {
        #region variable declaration adn page load

        private DataTable da = new DataTable();
        private Services.User.UserService userservice = new Services.User.UserService();

        /// <summary>
        /// page load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        #endregion variable declaration adn page load

        #region checkuser

        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            da = Services.User.UserService.GetData(email, password);
            if (da.Rows.Count > 0)
            {
                Session["email"] = txtEmail.Text;
                Response.Redirect("~/Views/Customer/CustomerList.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMesage", "alert('Email or Password is Invalid')", true);
            }
        }

        #endregion checkuser
    }
}