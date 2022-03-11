using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleTaskList.Views.Salutation
{
    public partial class SalutationCreate : System.Web.UI.Page
    {
        #region variable declaration

        private Models.Salutation.Salutation salutationmodel = new Models.Salutation.Salutation();
        private Services.Salutation.SalutationService salutationservice = new Services.Salutation.SalutationService();
        private DataTable da = new DataTable();
        #endregion variable declaration



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

        #endregion bind data

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

        #endregion Get Data

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
            int id = Convert.ToInt32(grvSalutation.DataKeys[e.RowIndex].Value);
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

        #endregion Salutation Add,Update,Delete

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

        #endregion search salutation

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

        #endregion paging

<<<<<<< HEAD
        #region clear and search text changed

        /// <summary>
        /// search text box changed
=======
        #region clear and search data paging update

        /// <summary>
        /// clear data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            GetData();
        }

        /// <summary>
        /// search data paging update
>>>>>>> c82f9fc2dc6b17d66a4f6e4a3faf02c251b97b58
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

<<<<<<< HEAD
        /// <summary>
        /// clear text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            this.GetData();
        }

        #endregion clear and search text changed
=======
        #endregion clear and search data paging update
>>>>>>> c82f9fc2dc6b17d66a4f6e4a3faf02c251b97b58
    }
}