using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace Services.Salutation
{
    public class SalutationService
    {

        #region Insert/Update/Delete
        /// <summary>
        /// Insert Data
        /// </summary>
        public static bool Insert(Models.Salutation.Salutation salutation)
        {
            try
            {
                var mydt = new DAOs.Salutation.SalutationDao();
                return DAOs.Salutation.SalutationDao.Insert(salutation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update Data
        /// </summary>
        public static bool Update(Models.Salutation.Salutation salutation)
        {
            try
            {
                return DAOs.Salutation.SalutationDao.Update(salutation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete Data
        /// </summary>
        public static bool Delete(Models.Salutation.Salutation salutation)
        {
            try
            {
                return DAOs.Salutation.SalutationDao.Delete(salutation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region Get Data      
        /// <summary>
        /// Get Data
        /// </summary>
        public static DataTable GetData(string salutation)
        {
            try
            {
                return DAOs.Salutation.SalutationDao.GetData(salutation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get All Data
        /// </summary>
        public static DataTable GetAllData()
        {
            try
            {
                return DAOs.Salutation.SalutationDao.GetAllData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Search Data
        /// </summary>
        public static DataTable GetSearchData(string str)
        {
            try
            {
                return DAOs.Salutation.SalutationDao.GetSearchData(str);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Read Data
        /// </summary>
        public static SqlDataReader ReadData(int id)
        {
            try
            {
                return DAOs.Salutation.SalutationDao.ReadData(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
