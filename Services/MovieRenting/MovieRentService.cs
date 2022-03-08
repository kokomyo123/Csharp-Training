using System;
using System.Data;
using System.Data.SqlClient;

namespace Services.MovieRenting
{
    public class MovieRentService
    {
        #region Insert/Update/Delete

        /// <summary>
        /// Insert Data
        /// </summary>
        public static bool Insert(Models.MovieRenting.MovieRent movierent)
        {
            try
            {
                var mydt = new DAOs.MovieRenting.MovieRentDao();
                return DAOs.MovieRenting.MovieRentDao.Insert(movierent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update Data
        /// </summary>
        public static bool Update(Models.MovieRenting.MovieRent movierent)
        {
            try
            {
                return DAOs.MovieRenting.MovieRentDao.Update(movierent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete Data
        /// </summary>
        public static bool Delete(Models.MovieRenting.MovieRent movierent)
        {
            try
            {
                return DAOs.MovieRenting.MovieRentDao.Delete(movierent);
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
        public static DataTable GetData(int movieid, int customerid)
        {
            try
            {
                return DAOs.MovieRenting.MovieRentDao.GetData(movieid, customerid);
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
                return DAOs.MovieRenting.MovieRentDao.GetAllData();
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
                return DAOs.MovieRenting.MovieRentDao.GetSearchData(str);
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
                return DAOs.MovieRenting.MovieRentDao.ReadData(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Get Data
    }
}