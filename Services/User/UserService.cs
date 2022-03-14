using System;
using System.Data;

namespace Services.User
{
    public class UserService
    {
        #region Get Data

        /// <summary>
        /// Get Data
        /// </summary>
        public static DataTable GetData(string email, string password)
        {
            try
            {
                return DAOs.User.UserDao.GetData(email, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Get Data
    }
}