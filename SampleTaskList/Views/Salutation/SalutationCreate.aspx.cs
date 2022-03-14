using System;
using System.Data;
using System.Data.SqlClient;

namespace SampleTaskList.Views.Salutation
{
    public partial class SalutationCreate1 : System.Web.UI.Page
    {
        private Models.Salutation.Salutation salutationmodel = new Models.Salutation.Salutation();
        private Services.Salutation.SalutationService salutationservice = new Services.Salutation.SalutationService();
        private DataTable da = new DataTable();

        #region load Data

        /// <summary>
        /// Load Data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["label"] != null)
            {
                string label = Session["label"].ToString();
                if (label == "add")
                {
                    LblSalutation.Text = "Add Salutation";
                }
                else if (label == "update")
                {
                    LblSalutation.Text = "Update Salutation";
                    if (!IsPostBack)
                    {
                        int id = Convert.ToInt32(Request.QueryString["id"]);
                        Services.Salutation.SalutationService salutationservice = new Services.Salutation.SalutationService();
                        SqlDataReader dr = Services.Salutation.SalutationService.ReadData(id);
                        while (dr.Read())
                        {
                            string ID = dr["id"].ToString();
                            string name = dr["salutation"].ToString();
                            txtSalutation.Text = name;
                            hfSalutation.Value = ID;
                        }
                    }
                }
            }
        }

        #endregion load Data

        #region InsertData

        /// <summary>
        /// InsertData
        /// </summary>
        private void InsertData()
        {
            salutationmodel.SALUTATION = txtSalutation.Text;
        }

        #endregion InsertData

        #region UpdateData

        /// <summary>
        /// UpdateData
        /// </summary>
        private void UpdateData()
        {
            salutationmodel.ID = Convert.ToInt32(hfSalutation.Value);
            salutationmodel.SALUTATION = txtSalutation.Text;
        }

        #endregion UpdateData

        #region salutation create,update

        /// <summary>
        /// Creating and Updating Salutation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hfSalutation.Value == "")
            {
                da = Services.Salutation.SalutationService.GetData(txtSalutation.Text);
                if (da.Rows.Count > 0)
                {
                    Session["alert"] = "Data already existed";
                    Session["alert-type"] = "warning";
                    Response.Redirect("SalutationList.aspx");
                }
                else
                {
                    InsertData();
                    bool success = Services.Salutation.SalutationService.Insert(salutationmodel);
                    if (success)
                    {
                        Session["alert"] = "Created successfully";
                        Session["alert-type"] = "success";
                        Response.Redirect("SalutationList.aspx");
                        txtSalutation.Text = string.Empty;
                    }
                    else
                    {
                        Session["alert"] = "Creating failed";
                        Session["alert-type"] = "danger";
                        Response.Redirect("SalutationList.aspx");
                    }
                }
            }
            else
            {
                da = Services.Salutation.SalutationService.GetData(txtSalutation.Text);
                if (da.Rows.Count > 0)
                {
                    Session["alert"] = "Data already existed";
                    Session["alert-type"] = "warning";
                    Response.Redirect("SalutationList.aspx");
                }
                else
                {
                    UpdateData();
                    bool IsUpdate = Services.Salutation.SalutationService.Update(salutationmodel);
                    if (IsUpdate)
                    {
                        Session["alert"] = "Updated successfully";
                        Session["alert-type"] = "success";
                        Response.Redirect("SalutationList.aspx");
                    }
                    else
                    {
                        Session["alert"] = "Updating failed";
                        Session["alert-type"] = "danger";
                        Response.Redirect("SalutationList.aspx");
                    }
                }
            }
        }

        #endregion salutation create,update

        #region clear and back

        /// <summary>
        /// clear form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtSalutation.Text = string.Empty;
        }

        /// <summary>
        /// back to list page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("SalutationList.aspx");
        }

        #endregion clear and back
    }
}