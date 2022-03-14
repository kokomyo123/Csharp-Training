using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs.User
{
    public class UserDao
    {
        #region Get Data
        /// <summary>
        /// Get Data
        /// </summary>
        /// <returns></returns>
        public static DataTable GetData(string email,string password)
        {
            try
            {
                return Common.HelperDao.GetData("Select id,name,email,password from tbl_user where  email='" + email + "' and password ='"+password+"'", CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     #endregion
    }
}
