using System;
using System.Data;
using System.Data.SqlClient;

namespace SampleTaskList.Views.Movie
{
    public partial class MovieCreate : System.Web.UI.Page
    {
        private Models.Movie.Movie moviemodel = new Models.Movie.Movie();
        private Services.Movie.MovieService movieservice = new Services.Movie.MovieService();
        private DataTable da = new DataTable();

        #region binding data and getting data

        /// <summary>
        /// binding data and getting data
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
                    lblMovie.Text = "Add Movie";
                }
                else if (label == "update")
                {
                    lblMovie.Text = "Update Movie";
                    if (!IsPostBack)
                    {
                        int id = Convert.ToInt32(Request.QueryString["id"]);
                        Services.Movie.MovieService movieservice = new Services.Movie.MovieService();
                        SqlDataReader dr = Services.Movie.MovieService.ReadData(id);
                        while (dr.Read())
                        {
                            string ID = dr["id"].ToString();
                            string movie = dr["movie"].ToString();
                            txtMovie.Text = movie;
                            hfMovie.Value = ID;
                        }
                    }
                }
            }
        }

        #endregion binding data and getting data

        #region InsertData

        /// <summary>
        /// InsertData
        /// </summary>
        private void InsertData()
        {
            moviemodel.MOVIE = txtMovie.Text;
        }

        #endregion InsertData

        #region UpdateData

        /// <summary>
        /// UpdateData
        /// </summary>
        private void UpdateData()
        {
            moviemodel.ID = Convert.ToInt32(hfMovie.Value);
            moviemodel.MOVIE = txtMovie.Text;
        }

        #endregion UpdateData

        #region creating and updating movie

        /// <summary>
        /// creating and updating movie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hfMovie.Value == "")
            {
                da = Services.Movie.MovieService.GetData(txtMovie.Text);

                if (da.Rows.Count > 0)
                {
                    Session["alert"] = "Data already existed";
                    Session["alert-type"] = "warning";
                    Response.Redirect("MovieList.aspx");
                }
                else
                {
                    InsertData();
                    bool success = Services.Movie.MovieService.Insert(moviemodel);
                    if (success)
                    {
                        Session["alert"] = "Created successfully";
                        Session["alert-type"] = "success";
                        Response.Redirect("MovieList.aspx");
                        txtMovie.Text = string.Empty;
                    }
                    else
                    {
                        Session["alert"] = "Creating failed";
                        Session["alert-type"] = "danger";
                        Response.Redirect("MovieList.aspx");
                    }
                }
            }
            else
            {
                da = Services.Movie.MovieService.GetData(txtMovie.Text);
                if (da.Rows.Count > 0)
                {
                    Session["alert"] = "Data already existed";
                    Session["alert-type"] = "warning";
                    Response.Redirect("MovieList.aspx");
                }
                else
                {
                    UpdateData();
                    bool IsUpdate = Services.Movie.MovieService.Update(moviemodel);
                    if (IsUpdate)
                    {
                        Session["alert"] = "Updated successfully";
                        Session["alert-type"] = "success";
                        Response.Redirect("MovieList.aspx");
                    }
                    else
                    {
                        Session["alert"] = "Updating failed";
                        Session["alert-type"] = "danger";
                        Response.Redirect("MovieList.aspx");
                    }
                }
            }
        }

        #endregion creating and updating movie

        #region clear and back

        /// <summary>
        /// clear form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtMovie.Text = string.Empty;
        }

        /// <summary>
        /// back to list page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("MovieList.aspx");
        }

        #endregion clear and back
    }
}