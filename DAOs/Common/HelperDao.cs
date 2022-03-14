using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAOs.Common
{
    public class HelperDao
    {
        #region DB Connection

        /// <summary>
        /// Database Connection
        /// </summary>
        private static string dbConnectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        public static DataTable tblResult;
        public static string sInsertItem = String.Empty;

        #endregion DB Connection

        #region Insert/Delete/Update(Common)

        /// <summary>
        /// Insert Data
        /// <paramref name="arr"/>
        /// <paramref name="sFieldName"/>
        /// <paramref name="sTableName"/>
        /// </summary>
        public static bool Insert(object[] arr, string sFieldName, string sTableName)
        {
            sInsertItem = String.Empty;
            SqlTransaction tran;
            var cn = new SqlConnection();
            cn.ConnectionString = dbConnectionString;
            cn.Open();
            tran = cn.BeginTransaction(IsolationLevel.ReadCommitted);
            var cmd = new SqlCommand();
            cmd.Connection = cn;
            if (arr is object)
            {
                for (int index = 1, loopTo = arr.Length - 1; index <= loopTo; index++)
                {
                    cmd.Parameters.AddWithValue("@" + index, arr[index - 1]);
                    if (index != arr.Length - 1)
                    {
                        sInsertItem += "@" + index + ",";
                    }
                    else
                    {
                        sInsertItem += "@" + index;
                    }
                }
            }

            try
            {
                cmd.CommandText = "INSERT INTO " + sTableName + "(" + sFieldName + ")" + " VALUES(" + sInsertItem + ")";
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
                cn.Close();
                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                tblResult = null;
                throw ex;
            }
        }

        /// <summary>
        /// Update Data
        /// <paramref name="sUpdateQuery"/>
        /// <paramref name="arr"/>
        /// </summary>
        public static bool Update(string sUpdateQuery, object[] arr)
        {
            SqlTransaction tran;
            var conn = new SqlConnection(dbConnectionString);
            conn.Open();
            tran = conn.BeginTransaction(IsolationLevel.ReadCommitted);
            var cmd = new SqlCommand();
            cmd.Connection = conn;
            if (arr is object)
            {
                for (int index = 1, loopTo = arr.Length - 1; index <= loopTo; index++)
                {
                    cmd.Parameters.AddWithValue("@" + index, arr[index - 1]);
                    if (index != arr.Length - 1)
                    {
                        sInsertItem += "@" + index + ",";
                    }
                    else
                    {
                        sInsertItem += "@" + index;
                    }
                }
            }

            try
            {
                cmd.CommandText = sUpdateQuery;
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        /// <summary>
        /// Delete Data
        /// <paramref name="sUpdateQuery"/>
        /// <paramref name="arr"/>
        /// </summary>
        public static bool Delete(string sUpdateQuery, object[] arr)
        {
            SqlTransaction tran;
            var conn = new SqlConnection(dbConnectionString);
            conn.Open();
            tran = conn.BeginTransaction(IsolationLevel.ReadCommitted);
            var cmd = new SqlCommand();
            cmd.Connection = conn;
            if (arr is object)
            {
                for (int index = 1, loopTo = arr.Length - 1; index <= loopTo; index++)
                {
                    cmd.Parameters.AddWithValue("@" + index, arr[index - 1]);
                    if (index != arr.Length - 1)
                    {
                        sInsertItem += "@" + index + ",";
                    }
                    else
                    {
                        sInsertItem += "@" + index;
                    }
                }
            }

            try
            {
                cmd.CommandText = sUpdateQuery;
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        #endregion Insert/Delete/Update(Common)

        #region Get Data

        /// <summary>
        /// Get Data
        /// <paramref name="commandText"/>
        /// <paramref name="commandType"/>
        /// </summary>
        public static DataTable GetData(string commandText, CommandType commandType)
        {
            var cn = new SqlConnection();
            cn.ConnectionString = dbConnectionString;
            cn.Open();
            var cmd = new SqlCommand(commandText, cn);
            cmd.CommandTimeout = 0;
            cmd.CommandType = commandType;
            try
            {
                var adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                var ds = new DataSet();
                adapter.Fill(ds);
                tblResult = ds.Tables[0];
            }
            catch (Exception ex)
            {
                tblResult = null;
                throw ex;
            }

            return tblResult;
        }

        public static SqlDataReader ReadData(string commandText, CommandType commandType)
        {
            var cn = new SqlConnection();
            cn.ConnectionString = dbConnectionString;
            cn.Open();
            var cmd = new SqlCommand(commandText, cn);
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                tblResult = null;
                throw ex;
            }
        }

        #endregion Get Data
    }
}