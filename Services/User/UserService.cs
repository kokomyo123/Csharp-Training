using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.User
{
    public class UserService
    {
        #region Get Data      
        /// <summary>
        /// Get Data
        /// </summary>
        public static DataTable GetData(string email,string password)
        {
            try
            {
                return DAOs.User.UserDao.GetData(email,password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
