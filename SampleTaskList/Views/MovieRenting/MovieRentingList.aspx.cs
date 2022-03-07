using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleTaskList.Views.MovieRenting
{
    public partial class MovieRentingList : System.Web.UI.Page
    {
        private Models.MovieRenting.MovieRent movierentmodel = new Models.MovieRenting.MovieRent();
        private Services.MovieRenting.MovieRentService movierentservice = new Services.MovieRenting.MovieRentService();
        private DataTable da = new DataTable();

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
            da = Services.MovieRenting.MovieRentService.GetAllData();
            if (da.Rows.Count > 0)
            {
                grvMovieRent.DataSource = da;
                grvMovieRent.DataBind();
                grvMovieRent.Visible = true;
            }
            else
            {
                grvMovieRent.DataSource = null;
            }
        }

        #endregion Get Data

        #region search movierent

        /// <summary>
        /// search movierent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            da = Services.MovieRenting.MovieRentService.GetSearchData(txtSearch.Text);
            if (da.Rows.Count > 0)
            {
                grvMovieRent.DataSource = da;
                grvMovieRent.DataBind();
                grvMovieRent.Visible = true;
            }
            else
            {
                grvMovieRent.DataSource = null;
                grvMovieRent.DataBind();
            }
        }

        #endregion search movierent

        #region movierent add,update,delete

        /// <summary>
        /// go to creat page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Session["label"] = "add";
            Response.Redirect("MovieRentingCreate.aspx");
        }

        /// <summary>
        /// delet movierent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvMovieRent_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(grvMovieRent.DataKeys[e.RowIndex].Value);
            movierentmodel.ID = id;
            bool IsDelete = Services.MovieRenting.MovieRentService.Delete(movierentmodel);
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

        /// <summary>
        /// go to update  page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvMovieRent_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["label"] = "update";
            int id = Convert.ToInt32(grvMovieRent.DataKeys[e.RowIndex].Value);
            Response.Redirect("MovieRentingCreate.aspx?id=" + id);
        }

        #endregion movierent add,update,delete

        #region export to excel

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            grvMovieRent.Columns[5].Visible = false;
            grvMovieRent.Columns[6].Visible = false;

            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    grvMovieRent.AllowPaging = false;
                    GetData();
                    grvMovieRent.RenderControl(hw);
                    string filename = Path.Combine(Server.MapPath("~/Download"), DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss") + "Movierentlist.xls");
                    StreamWriter writer = File.AppendText(filename);
                    writer.WriteLine(sw.ToString());
                    writer.Close();
                }
            }
            Session["alert"] = "file downloaded successfully";
            Session["alert-type"] = "success";
        }

        #endregion export to excel

        #region paging

        /// <summary>
        /// paging
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvMovieRent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvMovieRent.PageIndex = e.NewPageIndex;
            this.GetData();
        }

        #endregion paging
    }
}