using System;
using System.Data;
using System.Data.SqlClient;

namespace DAOs.MovieRenting
{
    public class MovieRentDao
    {
        #region Insert/Update/Delete

        /// <summary>
        /// Insert Data
        /// </summary>
        ///<returns></returns>
        public static bool Insert(Models.MovieRenting.MovieRent movierent)
        {
            try
            {
                var arr = new object[3];
                arr[0] = movierent.MovieID;
                arr[1] = movierent.CustomerID;
                bool num = Common.HelperDao.Insert(arr, "movie_id,customer_id", "tbl_movierenting");
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
        public static bool Update(Models.MovieRenting.MovieRent movierent)
        {
            try
            {
                var arr = new object[4];
                arr[0] = movierent.MovieID;
                arr[1] = movierent.CustomerID;
                arr[2] = movierent.ID;
                Common.HelperDao.Update("Update tbl_movierenting set movie_id=@1,customer_id=@2 where ID=@3", arr);
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
        public static bool Delete(Models.MovieRenting.MovieRent movierent)
        {
            try
            {
                var arr = new object[2];
                arr[0] = movierent.ID;
                Common.HelperDao.Delete("Delete from tbl_movierenting where id=@1", arr);
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
        public static DataTable GetData(int movieid, int customerid)
        {
            try
            {
                return Common.HelperDao.GetData("Select movie_id,customer_id from tbl_movierenting  where movie_id='" + movieid + "' and customer_id='" + customerid + "'", CommandType.Text);
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
                //return Common.HelperDao.GetData("Select tbl_movierenting.id,tbl_salutation.salutation,tbl_customer.full_name,tbl_customer.address,tbl_movie.movie from tbl_customer,tbl_movierenting,tbl_salutation,tbl_movie Where  tbl_salutation.id = tbl_customer.salutation_id AND tbl_movie.id = tbl_movierenting.movie_id AND tbl_customer.id = tbl_movierenting.customer_id", CommandType.Text);
                //return Common.HelperDao.GetData("Select * from GetMovieRentingData", CommandType.Text);
                return Common.HelperDao.GetData("Select * from GetMovieRentingData", CommandType.Text);
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
                    //return Common.HelperDao.GetData("Select tbl_movierenting.id,ROW_NUMBER() OVER (ORDER BY tbl_movierenting.id) No,tbl_salutation.salutation,tbl_customer.full_name AS Name,tbl_customer.address,tbl_movie.movie from tbl_customer,tbl_movierenting,tbl_salutation,tbl_movie Where  tbl_salutation.id = tbl_customer.salutation_id AND tbl_movie.id = tbl_movierenting.movie_id AND tbl_customer.id = tbl_movierenting.customer_id", CommandType.Text);
                    return Common.HelperDao.GetData("Select * from GetMovieRentingData", CommandType.Text);
                }
                else
                {
                    //    return Common.HelperDao.GetData("Select tbl_movierenting.id,tbl_salutation.salutation,tbl_customer.full_name,tbl_customer.address,tbl_movie.movie from tbl_customer,tbl_movierenting,tbl_salutation,tbl_movie Where  tbl_salutation.id = tbl_customer.salutation_id AND tbl_movie.id = tbl_movierenting.movie_id AND tbl_customer.id = tbl_movierenting.customer_id AND tbl_customer.full_name ='" + str + "' ", CommandType.Text);
                    return Common.HelperDao.GetData("Select * from GetMovieRentingData Where Name LIKE'%" + str + "%' ", CommandType.Text);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Read Data
        /// </summary>
        /// <returns></returns>
        public static SqlDataReader ReadData(int id)
        {
            try
            {
                return Common.HelperDao.ReadData("Select id,movie_id,customer_id from tbl_movierenting where id='" + id + "'", CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Get Data
    }
}