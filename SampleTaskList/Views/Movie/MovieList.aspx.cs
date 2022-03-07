using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Configuration;
using System.IO;
using System.Data;

namespace SampleTaskList.Views.Movie
{
    public partial class MovieList : System.Web.UI.Page
    {
        Models.Movie.Movie moviemodel = new Models.Movie.Movie();
        Services.Movie.MovieService movieservice = new Services.Movie.MovieService();
        DataTable da = new DataTable();

        #region data bind

        /// <summary>
        /// data bind
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

        #endregion data bind

        #region Get Data

        /// <summary>
        /// Get Data
        /// </summary>
        public void GetData()
        {
            da = Services.Movie.MovieService.GetAllData();
            if (da.Rows.Count > 0)
            {
                grvMovie.DataSource = da;
                grvMovie.DataBind();
                grvMovie.Visible = true;
            }
            else
            {
                grvMovie.DataSource = null;
            }
        }

        #endregion Get Data

        #region search movie

        /// <summary>
        /// search movie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            da = Services.Movie.MovieService.GetSearchData(txtSearch.Text);
            if (da.Rows.Count > 0)
            {
                grvMovie.DataSource = da;
                grvMovie.DataBind();
                grvMovie.Visible = true;
            }
            else
            {
                grvMovie.DataSource = null;
                grvMovie.DataBind();
            }
        }

        #endregion search movie

        #region movie add,update,delete

        /// <summary>
        /// go to add page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Session["label"] = "add";
            Response.Redirect("MovieCreate.aspx");
        }

        /// <summary>
        /// deleting movie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvMovie_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(grvMovie.DataKeys[e.RowIndex].Value);
            moviemodel.ID = id;
            bool IsDelete = Services.Movie.MovieService.Delete(moviemodel);
            if (IsDelete)
            {
                Session["alert"] = "Delete successfully";
                Session["alert-type"] = "success";
                GetData();
            }
            else
            {
                Session["alert"] = "Delete failed";
                Session["alert-type"] = "danger";
            }
        }

        /// <summary>
        /// go to update page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvMovie_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["label"] = "update";
            int id = Convert.ToInt32(grvMovie.DataKeys[e.RowIndex].Value);
            Response.Redirect("MovieCreate.aspx?id=" + id);
        }

        #endregion movie add,update,delete

        #region import to excel

        /// <summary>
        /// getting data from excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExcel_Click(object sender, EventArgs e)
        {
            string excelfilepath = Server.MapPath("~/Upload/Movielist.xlsx");
            if (File.Exists(excelfilepath))
            {
                ImoprtExceltoGridView(excelfilepath, ".xlsx", "Yes");
            }
            else
            {
                Response.Write("There is no file to read");
            }
        }

        /// <summary>
        /// importing excel to gridview
        /// </summary>
        /// <param name="File"></param>
        /// <param name="extension"></param>
        /// <param name="ishdr"></param>
        public void ImoprtExceltoGridView(string File, string extension, string ishdr)
        {
            string connectionStr = ConfigurationManager.ConnectionStrings["Excelconnection"].ConnectionString;
            connectionStr = String.Format(connectionStr, File, ishdr);
            OleDbConnection con = new OleDbConnection(connectionStr);
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();
            DataTable dt = new DataTable();
            cmd.Connection = con;
            con.Open();
            DataTable dtexcel = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string sheetname = dtexcel.Rows[0]["TABLE_NAME"].ToString();
            cmd.CommandText = "Select * from [" + sheetname + "]";
            oda.SelectCommand = cmd;
            oda.Fill(dt);
            con.Close();
            grvMovie.DataSource = dt;
            grvMovie.DataBind();
        }

        #endregion import to excel

        #region paging

        /// <summary>
        /// paging
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvMovie_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvMovie.PageIndex = e.NewPageIndex;
            this.GetData();
        }

        #endregion paging
    }
}