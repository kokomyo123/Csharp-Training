using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleTaskList.Views.Customer
{
    public partial class CustomerList : System.Web.UI.Page
    {
        #region variable declaration

        private Models.Customer.Customer customermodel = new Models.Customer.Customer();
        private Services.Customer.CustomerService customerservice = new Services.Customer.CustomerService();
        private DataTable da = new DataTable();

        #endregion variable declaration

        #region binding data

        /// <summary>
        /// binding data
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

        #endregion binding data

        #region Get Data

        /// <summary>
        /// Get Data
        /// </summary>
        public void GetData()
        {
            da = Services.Customer.CustomerService.GetAllData();
            if (da.Rows.Count > 0)
            {
                grvCustomer.DataSource = da;
                grvCustomer.DataBind();
                grvCustomer.Visible = true;
            }
            else
            {
                grvCustomer.DataSource = null;
                grvCustomer.DataBind();
            }
            grvCustomer.UseAccessibleHeader = true;
            grvCustomer.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        #endregion Get Data

        #region customer add,update,delete

        /// <summary>
        /// go to add page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Session["label"] = "add";
            Response.Redirect("CustomerCreate.aspx");
        }

        /// <summary>
        /// go to update page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvCustomer_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["label"] = "update";
            int id = Convert.ToInt32(grvCustomer.DataKeys[e.RowIndex].Value);
            Response.Redirect("CustomerCreate.aspx?id=" + id);
        }

        /// <summary>
        /// deleting customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvCustomer_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int mid;
            int id = Convert.ToInt32(grvCustomer.DataKeys[e.RowIndex].Value);
            da = Services.MovieRenting.MovieRentService.GetAllData();
            for (int j = 0; j < da.Rows.Count; j++)
            {
                mid = Convert.ToInt32(da.Rows[j]["customer_id"]);
                if (mid == id)
                {
                    Session["alert"] = "Data Exist You can't delete this";
                    Session["alert-type"] = "warning";
                    GetData();
                    return;
                }
            }
            customermodel.ID = id;
            bool IsDelete = Services.Customer.CustomerService.Delete(customermodel);
            if (IsDelete)
            {
                Session["alert"] = "Deleted successfully";
                Session["alert-type"] = "success";
                GetData();
            }
            else
            {
                Session["alert"] = "Deleting failed";
                Session["alert-type"] = "danger";
            }
        }

        #endregion customer add,update,delete

        #region search customer

        /// <summary>
        /// search customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            da = Services.Customer.CustomerService.GetSearchData(txtSearch.Text);
            if (da.Rows.Count > 0)
            {
                grvCustomer.DataSource = da;
                grvCustomer.DataBind();
                grvCustomer.Visible = true;
            }
            else
            {
                grvCustomer.DataSource = null;
                grvCustomer.DataBind();
            }
            grvCustomer.UseAccessibleHeader = true;
            grvCustomer.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        #endregion search customer

        #region paging

        /// <summary>
        /// paging
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvCustomer_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvCustomer.PageIndex = e.NewPageIndex;
            this.GetData();
        }

        #endregion paging

        #region clear text data and search

        /// <summary>
        /// clear text data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            this.GetData();
        }

        /// <summary>
        /// search text changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            da = Services.Customer.CustomerService.GetSearchData(txtSearch.Text);
            if (da.Rows.Count > 0)
            {
                grvCustomer.DataSource = da;
                grvCustomer.DataBind();
                grvCustomer.Visible = true;
            }
            else
            {
                grvCustomer.DataSource = null;
                grvCustomer.DataBind();
            }
            grvCustomer.UseAccessibleHeader = true;
            grvCustomer.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        #endregion clear text data and search
    }
}