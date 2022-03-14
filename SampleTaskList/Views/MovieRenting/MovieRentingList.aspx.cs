using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleTaskList.Views.MovieRenting
{
    public partial class MovieRentingList : System.Web.UI.Page
    {
        Models.MovieRenting.MovieRent movierentmodel = new Models.MovieRenting.MovieRent();
        Services.MovieRenting.MovieRentService movierentservice = new Services.MovieRenting.MovieRentService();
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

        #endregion

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
        #endregion

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

        #endregion


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
        #endregion


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
            for (int j = 1; j < dtcolumncount-2; j++)
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
                for (int i = 1; i < table.Columns.Count-2; i++)
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

        #endregion

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            this.GetData();
        }

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

        #region sendEmail
        /// <summary>
        /// Sending Email
        /// </summary>
        /// <param name="file"></param>
        private void sendEmail(string file)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress("yehtetaung791998@gmail.com");
                string ccaddress = "yehtetaung791998@gmail.com,donotbelievepeople@gmail.com";
                for (int i = 0; i < ccaddress.Split(',').Length; i++)
                {
                    message.CC.Add(new MailAddress(ccaddress.Split(',')[i]));
                }
                message.To.Add(new MailAddress("yehtetaung791998@gmail.com"));
                string mailbody = "<center><h1>Movie Renting</h1></center>";
                mailbody += "<p><h3>Hi Guy,</h3></p>";
                mailbody += "<p>Thank you for renting our movies.Here is your rented movie list.</p>";
                mailbody += "<p>Please tell us if you are inconvenient.</p>";
                mailbody += "<p>We look forward to hearing from you</p>";
                mailbody += "<p>Best regards,<p>";
                mailbody += "<p><h4>Movie Renting company🎬</h4></p>";
                message.Subject = "Movie Renting List";
                message.Body = mailbody;
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;
                message.Attachments.Add(new Attachment(file));
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp
                System.Net.NetworkCredential basicCredential1 = new
                System.Net.NetworkCredential("yehtetaung791998@gmail.com", "yourpassword");
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = basicCredential1;
                client.Send(message);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        /// <summary>
        /// send mail event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            da = Services.MovieRenting.MovieRentService.GetSearchData(txtSearch.Text);
            if (Directory.Exists("~/Download"))
            {
                string filename = Path.Combine(Server.MapPath("~/Download"), DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss") + "Movierentlist.xls");
                ExportToExcel(da, filename);
                sendEmail(filename);
                Session["alert"] = "Sending email successful";
                Session["alert-type"] = "success";
            }
            else
            {
                Directory.CreateDirectory(Server.MapPath("~/Download"));
                string filename = Path.Combine(Server.MapPath("~/Download"), DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss") + "Movierentlist.xls");
                ExportToExcel(da, filename);
                sendEmail(filename);
                Session["alert"] = "Sending email successful";
                Session["alert-type"] = "success";
            }
        }
        #endregion
    }
}