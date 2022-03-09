using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleTaskList.Views.MovieRenting
{
    public partial class MovieRentingList : System.Web.UI.Page
    {
        #region variable declaration

        private Models.MovieRenting.MovieRent movierentmodel = new Models.MovieRenting.MovieRent();
        private Services.MovieRenting.MovieRentService movierentservice = new Services.MovieRenting.MovieRentService();
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
                grvMovieRent.DataBind();
            }

            grvMovieRent.UseAccessibleHeader = true;
            grvMovieRent.HeaderRow.TableSection = TableRowSection.TableHeader;
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
            grvMovieRent.UseAccessibleHeader = true;
            grvMovieRent.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        #region export database data to excel

        /// <summary>
        /// exporting data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExport_Click(object sender, EventArgs e)
        {
            da = Services.MovieRenting.MovieRentService.GetSearchData(txtSearch.Text);
            if (Directory.Exists("~/Download"))
            {
                string filename = Path.Combine(Server.MapPath("~/Download"), DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss") + "Movierentlist.xls");
                ExportToExcel(da, filename);
            }
            else
            {
                Directory.CreateDirectory(Server.MapPath("~/Download"));
                string filename = Path.Combine(Server.MapPath("~/Download"), DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss") + "Movierentlist.xls");
                ExportToExcel(da, filename);
            }
        }

        /// <summary>
        /// export to excel
        /// </summary>
        /// <param name="table"></param>
        /// <param name="filePath"></param>
        private void ExportToExcel(DataTable table, string filePath)
        {
            StreamWriter Strwriter = new StreamWriter(filePath, false);
            Strwriter.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
            Strwriter.Write("<font style='font-size:15.0pt; font-family:TimesNewRoman;'>");
            Strwriter.Write("<BR><BR><BR>");
            Strwriter.Write("<Table border='2' bgColor='#ffffff' borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:15.0pt; font-family:TimesNewRoman; background:white;'> <TR>");
            int dtcolumncount = table.Columns.Count;
            for (int j = 1; j < dtcolumncount; j++)
            {
                Strwriter.Write("<Td style='background:aquamarine;'>");
                Strwriter.Write("<B>");
                Strwriter.Write(table.Columns[j].ToString());
                Strwriter.Write("</B>");
                Strwriter.Write("</Td>");
            }
            Strwriter.Write("</TR>");
            foreach (DataRow row in table.Rows)
            {
                Strwriter.Write("<TR>");
                for (int i = 1; i < table.Columns.Count; i++)
                {
                    Strwriter.Write("<Td>");
                    Strwriter.Write(row[i].ToString());
                    Strwriter.Write("</Td>");
                }
                Strwriter.Write("</TR>");
            }
            Strwriter.Write("</Table>");
            Strwriter.Write("</font>");
            Strwriter.Close();
            Session["alert"] = "successfully exported";
            Session["alert-type"] = "success";
            GetData();
        }

        #endregion export database data to excel

        #region clear and search paging update

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
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void txtSearch_TextChanged(object sender, EventArgs e)
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
            grvMovieRent.UseAccessibleHeader = true;
            grvMovieRent.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        #endregion clear and search paging update
    }
}