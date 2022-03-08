using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccess;
namespace BusinessLogic
{
    public class PetBLL
    {
        PetDAL objDAL = new PetDAL();

        public int Insert(PetBOL obj)
        {
            return objDAL.InsertData(obj);
        }

        public DataSet BindGrid()
        {
            return objDAL.BindGrid();
        }

        public SqlDataReader Read(int id)
        {
            return objDAL.ReadData(id);
        }

        public int Update(PetBOL obj, int id)
        {
            return objDAL.UpdateData(obj, id);
        }

        public int Delete(int id)
        {
            return objDAL.DeleteData(id);
        }
    }
}
