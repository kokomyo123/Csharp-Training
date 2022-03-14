namespace Models.MovieRenting
{
    public class MovieRent
    {
        #region Local variable and Constant Declaration

        /// <summary>
        /// Movie Renting Variables
        /// </summary>
        private int _id;

        private int _movieId;
        private int _customerId;

        #endregion Local variable and Constant Declaration

        #region Constructor and Destructor

        /// <summary>
        ///Constructor and Destructor for MovieRenting Variables
        /// </summary>
        public void PostData()
        {
            _id = 0;
            _movieId = 0;
            _customerId = 0;
        }

        public void PostData(int id, int movieId, int customerId)
        {
            _id = id;
            _movieId = movieId;
            _customerId = customerId;
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
        /// Gets or sets the <b>MovieID</b> attribute value.
        /// </summary>
        /// <value>The <b>MovieID</b> attribute value.</value>
        public int MovieID
        {
            get
            {
                return _movieId;
            }
            set
            {
                _movieId = value;
            }
        }

        /// <summary>
        /// Gets or sets the <b>CustomerID</b> attribute value.
        /// </summary>
        /// <value>The <b>CustomerID</b> attribute value.</value>
        public int CustomerID
        {
            get
            {
                return _customerId;
            }
            set
            {
                _customerId = value;
            }
        }

        #endregion Properties Assigning and Retrieving
    }
}