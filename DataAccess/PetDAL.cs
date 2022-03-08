using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
namespace DataAccess
{
    public class PetDAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["userDB"].ConnectionString);
        SqlCommand cmd;
        DataSet ds;
        SqlDataReader dr;
        int result;

        /// <summary>
        /// Inserting Data
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int InsertData(PetBOL obj)
        {
            cmd = new SqlCommand("INSERT INTO tbl_Cat VALUES(@name)", con);
            cmd.Parameters.AddWithValue("@name", obj.Name);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        /// <summary>
        /// Grid binding
        /// </summary>
        /// <returns></returns>
        public DataSet BindGrid()
        {
            cmd = new SqlCommand("SELECT * from tbl_Cat", con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            return ds;
        }

        /// <summary>
        /// Reading Data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SqlDataReader ReadData(int id)
        {
            cmd = new SqlCommand("SELECT * from tbl_Cat WHERE id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            return dr;
        }

        /// <summary>
        /// Updating Data
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdateData(PetBOL obj, int id)
        {
            cmd = new SqlCommand("UPDATE tbl_Cat SET name=@name WHERE id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", obj.Name);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        /// <summary>
        /// Deleting Data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteData(int id)
        {
            cmd = new SqlCommand("DELETE FROM tbl_Cat WHERE id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
