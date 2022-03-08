using System;

namespace Models.Movie
{
    public class Movie
    {
        #region Local variable and Constant Declaration

        /// <summary>
        /// Movie Variables
        /// </summary>
        private int _id;

        private string _movie;

        #endregion Local variable and Constant Declaration

        #region Constructor and Destructor

        /// <summary>
        ///Constructor and Destructor for Movie Variables
        /// </summary>
        public void PostData()
        {
            _id = 0;
            _movie = String.Empty;
        }

        public void PostData(int id, string movie)
        {
            _id = id;
            _movie = movie;
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
        /// Gets or sets the <b>_movie</b> attribute value.
        /// </summary>
        /// <value>The <b>_movie</b> attribute value.</value>
        public string MOVIE
        {
            get
            {
                return _movie;
            }
            set
            {
                _movie = value;
            }
        }

        #endregion Properties Assigning and Retrieving
    }
}