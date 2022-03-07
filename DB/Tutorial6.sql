Select tbl_User.FULL_NAME,tbl_User.ADDRESS,tbl_Movie.MOVIES_RENTED,tbl_Salutation.SALUTATION from tbl_User
  INNER JOIN tbl_Salutation ON tbl_Salutation.id = tbl_User.SALUTATION
  INNER JOIN tbl_Movie ON tbl_Movie.USER_ID = tbl_User.id;