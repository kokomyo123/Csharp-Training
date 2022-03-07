USE [pets]
GO
/****** Object:  Table [dbo].[tbl_Cat]    Script Date: 2/18/2022 4:40:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Cat](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_Cat] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Dog]    Script Date: 2/18/2022 4:40:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Dog](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_Dog] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Cat] ON 

INSERT [dbo].[tbl_Cat] ([id], [name]) VALUES (1, N'Kitty')
INSERT [dbo].[tbl_Cat] ([id], [name]) VALUES (2, N'Sweety')
INSERT [dbo].[tbl_Cat] ([id], [name]) VALUES (3, N'Pinky')
INSERT [dbo].[tbl_Cat] ([id], [name]) VALUES (4, N'Teddy')
SET IDENTITY_INSERT [dbo].[tbl_Cat] OFF
SET IDENTITY_INSERT [dbo].[tbl_Dog] ON 

INSERT [dbo].[tbl_Dog] ([id], [name]) VALUES (1, N'Jacky')
INSERT [dbo].[tbl_Dog] ([id], [name]) VALUES (2, N'Lucky')
INSERT [dbo].[tbl_Dog] ([id], [name]) VALUES (3, N'Tommy')
INSERT [dbo].[tbl_Dog] ([id], [name]) VALUES (4, N'Bobby')
SET IDENTITY_INSERT [dbo].[tbl_Dog] OFF
