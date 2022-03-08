using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObject;
using DataAccess;
using BusinessLogic;

namespace Tutorial8
{
    public partial class Edit : System.Web.UI.Page
    {
        string constring = ConfigurationManager.ConnectionStrings["userDB"].ConnectionString;
        PetBOL objBOL = new PetBOL();
        PetBLL objBLL = new PetBLL();
        int result;


        /// <summary>
        /// getting id from add page
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                SqlDataReader dr = objBLL.Read(id);
                while (dr.Read())
                {
                    string petid = dr["id"].ToString();
                    string name = dr["name"].ToString();
                    txtName.Text = name;
                    Lblpetid.Text = petid;
                }
            }
        }

        /// <summary>
        /// Updating data
        /// </summary>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                int id = Convert.ToInt32(Lblpetid.Text);
                string name = txtName.Text;
                objBOL.Name = name;
                result = objBLL.Update(objBOL, id);
                if (result > 0)
                {
                    Response.Redirect("Add.aspx");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMesage", "alert('Failed Updating')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMesage", "alert('Please fill name')", true);
            }
        }
    }
}