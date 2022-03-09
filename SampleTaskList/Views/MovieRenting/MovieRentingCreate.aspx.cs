using System;
using System.Data;
using System.Data.SqlClient;

namespace SampleTaskList.Views.MovieRenting
{
    public partial class MovieRentingCreate : System.Web.UI.Page
    {
        private Models.MovieRenting.MovieRent movierentmodel = new Models.MovieRenting.MovieRent();
        private DataTable da = new DataTable();

        #region data binding and getting data

        /// <summary>
        /// Data binding and get data
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
                    lblMovierent.Text = "Add MovieRenting";
                    if (!IsPostBack)
                    {
                        LoadMovie();
                        LoadCustomer();
                    }
                }
                else if (label == "update")
                {
                    lblMovierent.Text = "Update MovieRenting";
                    if (!IsPostBack)
                    {
                        LoadMovie();
                        LoadCustomer();
                        int id = Convert.ToInt32(Request.QueryString["id"]);
                        SqlDataReader dr = Services.MovieRenting.MovieRentService.ReadData(id);
                        while (dr.Read())
                        {
                            string ID = dr["id"].ToString();
                            int movie_id = Convert.ToInt32(dr["movie_id"].ToString());
                            int customer_id = Convert.ToInt32(dr["customer_id"].ToString());
                            hfMovieRent.Value = ID;
                            ddlMovie.SelectedValue = movie_id.ToString();
                            ddlCustomer.SelectedValue = customer_id.ToString();
                        }
                    }
                }
            }
        }

        #endregion data binding and getting data

        #region InsertData

        /// <summary>
        /// InsertData
        /// </summary>
        private void InsertData()
        {
            movierentmodel.MovieID = Convert.ToInt32(ddlMovie.SelectedValue);
            movierentmodel.CustomerID = Convert.ToInt32(ddlCustomer.SelectedValue);
        }

        #endregion InsertData

        #region UpdateData

        /// <summary>
        /// UpdateData
        /// </summary>
        private void UpdateData()
        {
            movierentmodel.ID = Convert.ToInt32(hfMovieRent.Value);
            movierentmodel.MovieID = Convert.ToInt32(ddlMovie.SelectedValue);
            movierentmodel.CustomerID = Convert.ToInt32(ddlCustomer.SelectedValue);
        }

        #endregion UpdateData

        #region binding movie and customer

        /// <summary>
        /// binding movie list
        /// </summary>
        public void LoadMovie()
        {
            da = Services.Movie.MovieService.GetAllData();
            if (da.Rows.Count > 0)
            {
                ddlMovie.DataSource = da;
                ddlMovie.DataValueField = "id";
                ddlMovie.DataTextField = "movie";
                ddlMovie.DataBind();
            }
        }

        /// <summary>
        /// binding customer list
        /// </summary>
        public void LoadCustomer()
        {
            da = Services.Customer.CustomerService.GetAllData();
            if (da.Rows.Count > 0)
            {
                ddlCustomer.DataSource = da;
                ddlCustomer.DataValueField = "id";
                ddlCustomer.DataTextField = "full_name";
                ddlCustomer.DataBind();
            }
        }

        #endregion binding movie and customer

        #region adding and updating

        /// <summary>
        /// adding and updating movie rent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hfMovieRent.Value == "")
            {
                da = Services.MovieRenting.MovieRentService.GetData(Convert.ToInt32(ddlMovie.SelectedValue), Convert.ToInt32(ddlCustomer.SelectedValue));
                if (da.Rows.Count > 0)
                {
                    Session["alert"] = "Data already existed";
                    Session["alert-type"] = "warning";
                    Response.Redirect("MovieRentingList.aspx");
                }
                else
                {
                    InsertData();
                    bool success = Services.MovieRenting.MovieRentService.Insert(movierentmodel);
                    if (success)
                    {
                        Session["alert"] = "Created successfully";
                        Session["alert-type"] = "success";
                        Response.Redirect("MovieRentingList.aspx");
                    }
                    else
                    {
                        Session["alert"] = "Creating failed";
                        Session["alert-type"] = "danger";
                        Response.Redirect("MovieRentingList.aspx");
                    }
                }
            }
            else
            {
                da = Services.MovieRenting.MovieRentService.GetData(Convert.ToInt32(ddlMovie.SelectedValue), Convert.ToInt32(ddlCustomer.SelectedValue));
                if (da.Rows.Count > 0)
                {
                    Session["alert"] = "Data already existed";
                    Session["alert-type"] = "warning";
                    Response.Redirect("MovieRentingList.aspx");
                }
                else
                {
                    UpdateData();
                    bool IsUpdate = Services.MovieRenting.MovieRentService.Update(movierentmodel);
                    if (IsUpdate)
                    {
                        Session["alert"] = "Updated successfully";
                        Session["alert-type"] = "success";
                        Response.Redirect("MovieRentingList.aspx");
                    }
                    else
                    {
                        Session["alert"] = "Updating failed";
                        Session["alert-type"] = "danger";
                        Response.Redirect("MovieRentingList.aspx");
                    }
                }
            }
        }

        #endregion adding and updating

        #region clear and back

        /// <summary>
        /// clear form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            ddlMovie.SelectedIndex = -1;
            ddlCustomer.SelectedIndex = -1;
        }

        /// <summary>
        /// back to list page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("MovieRentingList.aspx");
        }

        #endregion clear and back
    }
}