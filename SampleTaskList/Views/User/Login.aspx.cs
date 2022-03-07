using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleTaskList.Views.User
{
    public partial class Login : System.Web.UI.Page
    {
        DataTable da = new DataTable();
        Services.User.UserService userservice = new Services.User.UserService();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

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

        #endregion
    }
}