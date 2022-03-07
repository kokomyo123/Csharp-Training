USE [MovieRenting]
GO
/****** Object:  Table [dbo].[tbl_customer]    Script Date: 3/2/2022 7:13:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[salutation_id] [int] NULL,
	[full_name] [nvarchar](50) NULL,
	[address] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_movie]    Script Date: 3/2/2022 7:13:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_movie](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[movie] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_movie] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_movierenting]    Script Date: 3/2/2022 7:13:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_movierenting](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[movie_id] [int] NULL,
	[customer_id] [int] NULL,
 CONSTRAINT [PK_tbl_movierenting] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_salutation]    Script Date: 3/2/2022 7:13:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_salutation](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[salutation] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_Salutation] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_user]    Script Date: 3/2/2022 7:13:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_user_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[tbl_customer] ON 

INSERT [dbo].[tbl_customer] ([id], [salutation_id], [full_name], [address]) VALUES (1, 2, N'Sandy', N'First Street Plot No 4')
INSERT [dbo].[tbl_customer] ([id], [salutation_id], [full_name], [address]) VALUES (3, 1, N'Henry', N'Second Street Plot No 35')
INSERT [dbo].[tbl_customer] ([id], [salutation_id], [full_name], [address]) VALUES (4, 2, N'Rosy', N'Sixth Street Plot No 9')
INSERT [dbo].[tbl_customer] ([id], [salutation_id], [full_name], [address]) VALUES (5, 14, N'Bobby', N'Fifth Street Plot No 19')
INSERT [dbo].[tbl_customer] ([id], [salutation_id], [full_name], [address]) VALUES (6, 2, N'Cathy', N'Eleventh Street Plot No 12')
SET IDENTITY_INSERT [dbo].[tbl_customer] OFF
SET IDENTITY_INSERT [dbo].[tbl_movie] ON 

INSERT [dbo].[tbl_movie] ([id], [movie]) VALUES (1, N'Clash of Titans')
INSERT [dbo].[tbl_movie] ([id], [movie]) VALUES (2, N'Iron Man')
INSERT [dbo].[tbl_movie] ([id], [movie]) VALUES (3, N'Hotal trayslayvia')
INSERT [dbo].[tbl_movie] ([id], [movie]) VALUES (5, N'Mission Impossible 3')
INSERT [dbo].[tbl_movie] ([id], [movie]) VALUES (6, N'Pitch perfect')
SET IDENTITY_INSERT [dbo].[tbl_movie] OFF
SET IDENTITY_INSERT [dbo].[tbl_movierenting] ON 

INSERT [dbo].[tbl_movierenting] ([id], [movie_id], [customer_id]) VALUES (1, 2, 3)
INSERT [dbo].[tbl_movierenting] ([id], [movie_id], [customer_id]) VALUES (2, 3, 6)
INSERT [dbo].[tbl_movierenting] ([id], [movie_id], [customer_id]) VALUES (4, 3, 5)
INSERT [dbo].[tbl_movierenting] ([id], [movie_id], [customer_id]) VALUES (5, 6, 1)
INSERT [dbo].[tbl_movierenting] ([id], [movie_id], [customer_id]) VALUES (6, 6, 5)
INSERT [dbo].[tbl_movierenting] ([id], [movie_id], [customer_id]) VALUES (7, 1, 3)
SET IDENTITY_INSERT [dbo].[tbl_movierenting] OFF
SET IDENTITY_INSERT [dbo].[tbl_salutation] ON 

INSERT [dbo].[tbl_salutation] ([id], [salutation]) VALUES (1, N'Mr')
INSERT [dbo].[tbl_salutation] ([id], [salutation]) VALUES (2, N'Ms')
INSERT [dbo].[tbl_salutation] ([id], [salutation]) VALUES (3, N'Dr')
INSERT [dbo].[tbl_salutation] ([id], [salutation]) VALUES (14, N'Jr')
INSERT [dbo].[tbl_salutation] ([id], [salutation]) VALUES (38, N'Sr')
SET IDENTITY_INSERT [dbo].[tbl_salutation] OFF
SET IDENTITY_INSERT [dbo].[tbl_user] ON 

INSERT [dbo].[tbl_user] ([id], [name], [email], [password]) VALUES (1, N'YeHtet', N'yha@gmail.com', N'yha111')
INSERT [dbo].[tbl_user] ([id], [name], [email], [password]) VALUES (2, N'Jonas', N'jn@gmail.com', N'jn222')
SET IDENTITY_INSERT [dbo].[tbl_user] OFF
