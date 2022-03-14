using System;
using System.Data;
using System.Data.SqlClient;

namespace SampleTaskList.Views.Customer
{
    public partial class CustomerCreate : System.Web.UI.Page
    {
        private Models.Customer.Customer customermodel = new Models.Customer.Customer();
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
                    lblCustomer.Text = "Add Customer";
                    if (!IsPostBack)
                    {
                        LoadSalutation();
                    }
                }
                else if (label == "update")
                {
                    lblCustomer.Text = "Update Customer";
                    if (!IsPostBack)
                    {
                        LoadSalutation();
                        int id = Convert.ToInt32(Request.QueryString["id"]);
                        SqlDataReader dr = Services.Customer.CustomerService.ReadData(id);
                        while (dr.Read())
                        {
                            string ID = dr["id"].ToString();
                            int salutation_id = Convert.ToInt32(dr["salutation_id"].ToString());
                            string name = dr["full_name"].ToString();
                            string address = dr["address"].ToString();
                            hfCustomer.Value = ID;
                            txtName.Text = name;
                            txtAddress.Text = address;
                            ddlSalutation.SelectedValue = salutation_id.ToString(); ;
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
            customermodel.SalutationID = Convert.ToInt32(ddlSalutation.SelectedValue);
            customermodel.FullName = txtName.Text;
            customermodel.Address = txtAddress.Text;
        }

        #endregion InsertData

        #region UpdateData

        /// <summary>
        /// UpdateData
        /// </summary>
        private void UpdateData()
        {
            customermodel.ID = Convert.ToInt32(hfCustomer.Value);
            customermodel.SalutationID = Convert.ToInt32(ddlSalutation.SelectedValue);
            customermodel.FullName = txtName.Text;
            customermodel.Address = txtAddress.Text;
        }

        #endregion UpdateData

        #region binding salutation

        /// <summary>
        /// binding salutation
        /// </summary>
        public void LoadSalutation()
        {
            da = Services.Salutation.SalutationService.GetAllData();
            if (da.Rows.Count > 0)
            {
                ddlSalutation.DataSource = da;
                ddlSalutation.DataValueField = "id";
                ddlSalutation.DataTextField = "salutation";
                ddlSalutation.DataBind();
            }
        }

        #endregion binding salutation

        #region creating and updating customer

        /// <summary>
        /// creating and updating customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hfCustomer.Value == "")
            {
                da = Services.Customer.CustomerService.GetData(txtName.Text, txtAddress.Text);
                if (da.Rows.Count > 0)
                {
                    Session["alert"] = "Data already exist";
                    Session["alert-type"] = "warning";
                    Response.Redirect("CustomerList.aspx");
                }
                else
                {
                    InsertData();
                    bool success = Services.Customer.CustomerService.Insert(customermodel);
                    if (success)
                    {
                        Session["alert"] = "Created successfully";
                        Session["alert-type"] = "success";
                        Response.Redirect("CustomerList.aspx");
                        txtName.Text = string.Empty;
                        txtAddress.Text = string.Empty;
                    }
                    else
                    {
                        Session["alert"] = "Creating failed";
                        Session["alert-type"] = "danger";
                        Response.Redirect("CustomerList.aspx");
                    }
                }
            }
            else
            {
                da = Services.Customer.CustomerService.GetData(txtName.Text, txtAddress.Text);
                if (da.Rows.Count > 0)
                {
                    Session["alert"] = "Data already exist";
                    Session["alert-type"] = "warning";
                    Response.Redirect("CustomerList.aspx");
                }
                else
                {
                    UpdateData();
                    bool IsUpdate = Services.Customer.CustomerService.Update(customermodel);
                    if (IsUpdate)
                    {
                        Session["alert"] = "Updated successfully";
                        Session["alert-type"] = "success";
                        Response.Redirect("CustomerList.aspx");
                    }
                    else
                    {
                        Session["alert"] = "Updating failed";
                        Session["alert-type"] = "danger";
                        Response.Redirect("CustomerList.aspx");
                    }
                }
            }
        }

        #endregion creating and updating customer

        #region back and clear

        /// <summary>
        /// back to list page
        /// </summary>
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerList.aspx");
        }

        /// <summary>
        /// clear form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            ddlSalutation.SelectedIndex = -1;
            txtAddress.Text = string.Empty;
            txtName.Text = string.Empty;
        }

        #endregion back and clear
    }
}