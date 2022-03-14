using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAOs;
namespace SampleTaskList.Views.Salutation
{
    public partial class SalutationCreate : System.Web.UI.Page
    {

        Models.Salutation.Salutation salutationmodel = new Models.Salutation.Salutation();
        Services.Salutation.SalutationService salutationservice = new Services.Salutation.SalutationService();
      
        DataTable da = new DataTable();

        #region bind data
        /// <summary>
        /// bind data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("~/Views/User/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                GetData();
            }
        }
        #endregion

        #region Get Data
        /// <summary>
        /// Get Data
        /// </summary>
        public void GetData()
        {
          da = Services.Salutation.SalutationService.GetAllData();
            if (da.Rows.Count > 0)
            {
                grvSalutation.DataSource = da;
                grvSalutation.DataBind();
                grvSalutation.Visible = true;
            }
            else
            {
                grvSalutation.DataSource = null;
                grvSalutation.DataBind();
            }
            grvSalutation.UseAccessibleHeader = true;
            grvSalutation.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        #endregion


        #region Salutation Add,Update,Delete
        /// <summary>
        /// Add Salutation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Session["label"] = "add";
            Response.Redirect("SalutationCreate.aspx");
        }

        /// <summary>
        /// update salutation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvSalutation_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["label"] = "update";
            int id = Convert.ToInt32(grvSalutation.DataKeys[e.RowIndex].Value);
            Response.Redirect("SalutationCreate.aspx?id=" + id);
        }

        /// <summary>
        /// delete salutation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvSalutation_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int sid;
            int id = Convert.ToInt32(grvSalutation.DataKeys[e.RowIndex].Value);
            da = Services.Customer.CustomerService.GetAllData();
            for(int j = 0; j < da.Rows.Count; j++)
            {
                sid = Convert.ToInt32(da.Rows[j]["salutation_id"]);
                if (sid == id)
                {
                    Session["alert"] = "Data Exist You can't delet this";
                    Session["alert-type"] = "warning";
                    GetData();
                    return;
                }
            }
            salutationmodel.ID = id;
            bool IsDelete = Services.Salutation.SalutationService.Delete(salutationmodel);
            if (IsDelete)
            {
                Session["alert"] = "Delete successfully";
                Session["alert-type"] = "success";
                GetData();
            }
            else
            {
                Session["alert"] = "Deleting failed";
                Session["alert-type"] = "danger";
            }
        }

        #endregion


        #region search salutation
        /// <summary>
        /// Search salutation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            da = Services.Salutation.SalutationService.GetSearchData(txtSearch.Text);
            if (da.Rows.Count > 0)
            {
                grvSalutation.DataSource = da;
                grvSalutation.DataBind();
                grvSalutation.Visible = true;
            }
            else
            {
                grvSalutation.DataSource = null;
                grvSalutation.DataBind();
            }
            grvSalutation.UseAccessibleHeader = true;
            grvSalutation.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        #endregion

        #region paging
        /// <summary>
        /// Paging
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvSalutation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
           grvSalutation.PageIndex = e.NewPageIndex;
            this.GetData();
        }
        #endregion

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            da = Services.Salutation.SalutationService.GetSearchData(txtSearch.Text);
            if (da.Rows.Count > 0)
            {
                grvSalutation.DataSource = da;
                grvSalutation.DataBind();
                grvSalutation.Visible = true;
            }
            else
            {
                grvSalutation.DataSource = null;
                grvSalutation.DataBind();
            }
            grvSalutation.UseAccessibleHeader = true;
            grvSalutation.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
          txtSearch.Text = string.Empty;
            this.GetData();
        }
    }
}