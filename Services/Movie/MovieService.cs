using System;
using System.Data;
using System.Data.SqlClient;

namespace Services.Movie
{
    public class MovieService
    {
        #region Insert/Update/Delete

        /// <summary>
        /// Insert Data
        /// </summary>
        public static bool Insert(Models.Movie.Movie movie)
        {
            try
            {
                var mydt = new DAOs.Movie.MovieDao();
                return DAOs.Movie.MovieDao.Insert(movie);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update Data
        /// </summary>
        public static bool Update(Models.Movie.Movie movie)
        {
            try
            {
                return DAOs.Movie.MovieDao.Update(movie);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete Data
        /// </summary>
        public static bool Delete(Models.Movie.Movie movie)
        {
            try
            {
                return DAOs.Movie.MovieDao.Delete(movie);
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
        public static DataTable GetData(string movie)
        {
            try
            {
                return DAOs.Movie.MovieDao.GetData(movie);
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
                return DAOs.Movie.MovieDao.GetAllData();
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
                return DAOs.Movie.MovieDao.GetSearchData(str);
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
                return DAOs.Movie.MovieDao.ReadData(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Get Data
    }
}