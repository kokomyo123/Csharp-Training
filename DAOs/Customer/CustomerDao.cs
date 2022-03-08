using System;
using System.Data;
using System.Data.SqlClient;

namespace DAOs.Customer
{
    public class CustomerDao
    {
        #region Insert/Update/Delete

        /// <summary>
        /// Insert Data
        /// </summary>
        ///<returns></returns>
        public static bool Insert(Models.Customer.Customer customer)
        {
            try
            {
                var arr = new object[4];
                arr[0] = customer.SalutationID;
                arr[1] = customer.FullName;
                arr[2] = customer.Address;
                bool num = Common.HelperDao.Insert(arr, "salutation_id,full_name,address", "tbl_customer");
                if (num)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        /// <summary>
        /// Update Data
        /// </summary>
        /// <returns></returns>
        public static bool Update(Models.Customer.Customer customer)
        {
            try
            {
                var arr = new object[5];
                arr[0] = customer.SalutationID;
                arr[1] = customer.FullName;
                arr[2] = customer.Address;
                arr[3] = customer.ID;
                Common.HelperDao.Update("Update tbl_customer set salutation_id=@1,full_name=@2,address=@3 where ID=@4", arr);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete Data
        /// </summary>
        /// <returns></returns>
        public static bool Delete(Models.Customer.Customer customer)
        {
            try
            {
                var arr = new object[2];
                arr[0] = customer.ID;
                Common.HelperDao.Delete("Delete from tbl_customer where id=@1", arr);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Insert/Update/Delete

        #region Get Data

        /// <summary>
        /// Get Data
        /// </summary>
        /// <returns></returns>
        public static DataTable GetData(string name, string address)
        {
            try
            {
                return Common.HelperDao.GetData("Select full_name,address from tbl_customer where full_name='" + name + "' and address='" + address + "'", CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get All Data
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllData()
        {
            try
            {
                return Common.HelperDao.GetData("Select tbl_customer.id,tbl_customer.salutation_id,tbl_customer.full_name,tbl_customer.address,tbl_salutation.id,tbl_salutation.salutation  from tbl_customer  join tbl_salutation  on tbl_customer.salutation_id=tbl_salutation.id", CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Search Data
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSearchData(string str)
        {
            try
            {
                if (str == "")
                {
                    return Common.HelperDao.GetData("Select tbl_customer.id,tbl_customer.salutation_id,tbl_customer.full_name,tbl_customer.address,tbl_salutation.id,tbl_salutation.salutation  from tbl_customer  join tbl_salutation  on tbl_customer.salutation_id=tbl_salutation.id", CommandType.Text);
                }
                else
                {
                    return Common.HelperDao.GetData("Select tbl_customer.id,tbl_customer.salutation_id,tbl_customer.full_name,tbl_customer.address,tbl_salutation.id,tbl_salutation.salutation  from tbl_customer  join tbl_salutation  on tbl_customer.salutation_id=tbl_salutation.id where full_name ='" + str + "'", CommandType.Text);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///Read Data
        /// </summary>
        /// <returns></returns>
        public static SqlDataReader ReadData(int id)
        {
            try
            {
                return Common.HelperDao.ReadData("Select id,salutation_id,full_name,address from tbl_customer where id='" + id + "'", CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Get Data
    }
}