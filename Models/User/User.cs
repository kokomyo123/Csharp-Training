using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.User
{
    public class User
    {
        #region Local variable and Constant Declaration
        /// <summary>
        /// User Variables
        /// </summary>		
        private int _id;
        private string _name;
        private string _email;
        private string _password;
        #endregion

        #region Constructor and Destructor
        /// <summary>
        ///Constructor and Destructor for User Variables 
        /// </summary>
        public void UserData()
        {
            _id = 0;
            _name = String.Empty;
            _email = String.Empty;
            _password = string.Empty;
        }

        public void UserData(int id, string name,string email,string password)
        {
            _id = id;
            _name= name;
            _email = email;
            _password = password;
        }
        #endregion

        #region Properties Assigning and Retrieving
        /// <summary>
        /// Gets or sets the <b>_ID</b> attribute value.
        /// </summary>
        /// <value>The <b>_ID</b> attribute value.</value>
        public int ID
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>Name</b> attribute value.
        /// </summary>
        /// <value>The <b>Name</b> attribute value.</value>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        /// <summary>
        /// Gets or sets the <b>Email</b> attribute value.
        /// </summary>
        /// <value>The <b>Email</b> attribute value.</value>
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>Password</b> attribute value.
        /// </summary>
        /// <value>The <b>Password</b> attribute value.</value>
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        #endregion
    }
}
