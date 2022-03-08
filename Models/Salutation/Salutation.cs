using System;

namespace Models.Salutation
{
    public class Salutation
    {
        #region Local and Constant variable Declaration

        /// <summary>
        /// Salutation Variables
        /// </summary>
        private int _id;

        private string _salutation;

        #endregion Local and Constant variable Declaration

        #region Constructor and Destructor

        /// <summary>
        ///Constructor and Destructor for Salutation Variables
        /// </summary>
        public void PostData()
        {
            _id = 0;
            _salutation = String.Empty;
        }

        public void PostData(int id, string salutation)
        {
            _id = id;
            _salutation = salutation;
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
        /// Gets or sets the <b>_Salutation</b> attribute value.
        /// </summary>
        /// <value>The <b>_Salutation</b> attribute value.</value>
        public string SALUTATION
        {
            get
            {
                return _salutation;
            }
            set
            {
                _salutation = value;
            }
        }

        #endregion Properties Assigning and Retrieving
    }
}