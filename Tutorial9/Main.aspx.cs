using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tutorial9
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        #region Read Files From Excel,CSV,TXT and DOC

        /// <summary>
        /// getting data from excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExcel_Click(object sender, EventArgs e)
        {
            string excelfilepath = Server.MapPath("~/Upload/User.xlsx");
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
            gvFile.DataSource = dt;
            gvFile.DataBind();
        }

        /// <summary>
        /// getting data from csv file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCSV_Click(object sender, EventArgs e)
        {
            string csvPath = Server.MapPath("~/Upload/User.csv");
            if (File.Exists(csvPath))
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Id"),
            new DataColumn("Name"),
            new DataColumn("Address"),
            new DataColumn("Email")});
                string csvData = File.ReadAllText(csvPath);
                foreach (string row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        dt.Rows.Add();
                        int i = 0;
                        foreach (string cell in row.Split(','))
                        {
                            dt.Rows[dt.Rows.Count - 1][i] = cell;
                            i++;
                        }
                    }
                }
                gvFile.DataSource = dt;
                gvFile.DataBind();
            }
            else
            {
                Response.Write("There is no file to read");
            }
        }

        /// <summary>
        /// getting data from text file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnText_Click(object sender, EventArgs e)
        {
            string csvPath = Server.MapPath("~/Upload/User.txt");
            if (File.Exists(csvPath))
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Id"),
            new DataColumn("Name"),
            new DataColumn("Address"),
            new DataColumn("Email")});
                string csvData = File.ReadAllText(csvPath);
                foreach (string row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        dt.Rows.Add();
                        int i = 0;
                        foreach (string cell in row.Split(','))
                        {
                            dt.Rows[dt.Rows.Count - 1][i] = cell;
                            i++;
                        }
                    }
                }
                gvFile.DataSource = dt;
                gvFile.DataBind();
            }
            else
            {
                Response.Write("There is no file to read");
            }
        }

        /// <summary>
        /// getting data from document file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDoc_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Word.Application MyWord = new Microsoft.Office.Interop.Word.Application();
            string sFile = Server.MapPath("~/Upload/User.docx"); ;
            if (File.Exists(sFile))
            {
                // create a .net table
                DataTable rstData = new DataTable();
                MyWord.Documents.Open(sFile);
                Microsoft.Office.Interop.Word.Document MyDoc = MyWord.ActiveDocument;
                // get first table
                Microsoft.Office.Interop.Word.Table MyTable = MyDoc.Tables[1];
                // assume first row is headings
                int iCol = 0;
                for (iCol = 1; iCol <= MyTable.Columns.Count; iCol++)
                {
                    rstData.Columns.Add(CleanCellText(MyTable.Rows[1].Cells[iCol].Range.Text), typeof(string));
                }
                // now add all the rows of data to the .net table
                int iRows = 0;
                // word tables start at 1, .net tables start at 0 (zero based)
                for (iRows = 2; iRows <= MyTable.Rows.Count; iRows++)
                {
                    DataRow OneRow = rstData.NewRow();
                    for (iCol = 1; iCol <= MyTable.Columns.Count; iCol++)
                    {
                        OneRow[iCol - 1] = CleanCellText(MyTable.Rows[iRows].Cells[iCol].Range.Text);
                    }
                    rstData.Rows.Add(OneRow);  // add this row to .net table
                }
                MyDoc.Close();
                MyWord.Quit();

                // now bind the resulting table to the grid
                gvFile.DataSource = rstData;
                gvFile.DataBind();
            }
            else
            {
                Response.Write("There is no file to read");
            }
        }

        private string CleanCellText(string s)
        {
            // all word cells have a training cr and a char(7)
            string MyClean = ((char)13).ToString() + ((char)7).ToString();
            return s.Replace(MyClean, "");
        }

        #endregion Read Files From Excel,CSV,TXT and DOC
    }
}