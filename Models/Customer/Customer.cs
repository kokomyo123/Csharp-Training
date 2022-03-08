using System;

namespace Models.Customer
{
    public class Customer
    {
        #region Local and Constant  variable Declaration

        /// <summary>
        /// Customer Variables
        /// </summary>
        private int _id;

        private int _salutationId;
        private string _fullname;
        private string _address;

        #endregion Local and Constant  variable Declaration

        #region Constructor and Destructor

        /// <summary>
        ///Constructor and Destructor for Customer Variables
        /// </summary>
        public void PostData()
        {
            _id = 0;
            _salutationId = 0;
            _fullname = String.Empty;
            _address = String.Empty;
        }

        public void PostData(int id, int salutationId, string fullname, string address)
        {
            _id = id;
            _salutationId = salutationId;
            _fullname = fullname;
            _address = address;
        }

        #endregion Constructor and Destructor

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
        /// Gets or sets the <b>_SalutationID</b> attribute value.
        /// </summary>
        /// <value>The <b>_SalutationID</b> attribute value.</value>
        public int SalutationID
        {
            get
            {
                return _salutationId;
            }
            set
            {
                _salutationId = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>FullName</b> attribute value.
        /// </summary>
        /// <value>The <b>FullName</b> attribute value.</value>
        public string FullName
        {
            get
            {
                return _fullname;
            }
            set
            {
                _fullname = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>Address</b> attribute value.
        /// </summary>
        /// <value>The <b>Address</b> attribute value.</value>
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        }

        #endregion Properties Assigning and Retrieving
    }
}