using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleTaskList.Views.Movie
{
    public partial class MovieList : System.Web.UI.Page
    {
        #region variable declaration

        private Models.Movie.Movie moviemodel = new Models.Movie.Movie();
        private Services.Movie.MovieService movieservice = new Services.Movie.MovieService();
        private DataTable da = new DataTable();

        #endregion variable declaration

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

        #region import excel data to database

        /// <summary>
        /// importing data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnImport_Click(object sender, EventArgs e)
        {
            string excelPath = Server.MapPath("~/Upload/MovieList.xlsx");
            if (File.Exists(excelPath))
            {
                string conString = string.Empty;
                string extension = Path.GetExtension("MovieList.xlsx");
                switch (extension)
                {
                    case ".xls": //Excel 97-03
                        conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                        break;

                    case ".xlsx": //Excel 07 or higher
                        conString = ConfigurationManager.ConnectionStrings["Excel07+ConString"].ConnectionString;
                        break;
                }
                conString = string.Format(conString, excelPath);
                OleDbConnection oconn = new OleDbConnection(conString);
                try
                {
                    oconn.Open();
                    string sheet1 = oconn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();
                    OleDbCommand ocmd = new OleDbCommand("SELECT * FROM [" + sheet1 + "]", oconn);

                    OleDbDataReader odr = ocmd.ExecuteReader();
                    string movie = ""; ;
                    while (odr.Read())
                    {
                        movie = valid(odr, 1);
                        // Checking email exist or not.
                        // If not exist then insert record.
                        if (!IsEmailExist(movie))
                        {
                            insertdataintosql(movie);
                        }
                    }
                    oconn.Close();

                    Session["alert"] = "Data Inserted Sucessfully";
                    Session["alert-type"] = "success";
                    GetData();
                }
                catch (DataException ee)
                {
                }
            }
            else
            {
                Session["alert"] = "File doesn't exist";
                Session["alert-type"] = "danger";
            }
        }

        /// <summary>
        /// check existing data
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        private bool IsEmailExist(string movie)
        {
            bool exist = false;
            string conStr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            SqlConnection conn = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            // Change the query as per your condition.
            string query1 = "SELECT movie FROM tbl_movie WHERE movie = @movie";
            cmd.CommandText = query1;
            cmd.Parameters.Add("@movie", SqlDbType.NVarChar, 100).Value = movie;
            cmd.CommandType = CommandType.Text;
            conn.Open();
            object i = cmd.ExecuteScalar();
            if (i != null)
            {
                exist = true;
            }
            conn.Close();
            return exist;
        }

        /// <summary>
        /// check vaild
        /// </summary>
        /// <param name="myreader"></param>
        /// <param name="stval"></param>
        /// <returns></returns>
        protected string valid(OleDbDataReader myreader, int stval) //if any columns are found null then they are replaced by zero
        {
            object val = myreader[stval];
            if (val != DBNull.Value)
                return val.ToString();
            else
                return Convert.ToString(0);
        }

        /// <summary>
        /// inserting data to database
        /// </summary>
        /// <param name="movie"></param>
        public void insertdataintosql(string movie)
        {
            string conStr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            SqlConnection conn = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            string query1 = "INSERT INTO tbl_movie (movie) VALUES (@movie);SELECT SCOPE_IDENTITY()";
            cmd.CommandText = query1;
            cmd.Parameters.Add("@movie", SqlDbType.NVarChar, 100).Value = movie;
            cmd.CommandType = CommandType.Text;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            grvMovie.DataBind();
        }

        #endregion import excel data to database
    }
}