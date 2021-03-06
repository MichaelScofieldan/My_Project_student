USE [P_NIHONGO]
GO
/****** Object:  Table [dbo].[C_GRAMMAR]    Script Date: 3/16/2018 8:45:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[C_GRAMMAR](
	[GRAMMARCODE] [nvarchar](10) NOT NULL,
	[TITLE] [nvarchar](250) NULL,
	[INDEX1] [nvarchar](250) NULL,
	[INDEX2] [nvarchar](250) NULL,
	[INDEX3] [nvarchar](250) NULL,
	[DETAIL1] [nvarchar](max) NULL,
	[DETAIL2] [nvarchar](max) NULL,
	[DETAIL3] [nvarchar](max) NULL,
	[USERCODE] [nvarchar](10) NULL,
	[IMAGE] [nvarchar](250) NULL,
	[VOTENUMBER] [nvarchar](10) NULL,
	[TOPPICCODE] [nvarchar](10) NULL,
	[LEVELCODE] [nvarchar](10) NULL,
	[MINACODE] [nvarchar](10) NULL,
	[EXAMPLE1] [nvarchar](250) NULL,
	[MEAN_EX1] [nvarchar](250) NULL,
	[EXAMPLE2] [nvarchar](250) NULL,
	[MEAN_EX2] [nvarchar](250) NULL,
	[EXAMPLE3] [nvarchar](250) NULL,
	[MEAN_EX3] [nvarchar](250) NULL,
	[DESCRIPTION] [nvarchar](max) NULL,
	[STATUS] [nvarchar](1) NULL,
	[ATTRIBUTE1] [nvarchar](50) NULL,
	[ATTRIBUTE2] [nvarchar](50) NULL,
	[CREATE_DATE] [nvarchar](10) NULL,
	[UP_DATE] [nvarchar](10) NULL,
 CONSTRAINT [PK_C_GRAMMAR] PRIMARY KEY CLUSTERED 
(
	[GRAMMARCODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[C_KAIWA]    Script Date: 3/16/2018 8:45:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[C_KAIWA](
	[KAIWACODE] [nvarchar](10) NOT NULL,
	[KAIWANAME] [nvarchar](max) NULL,
	[SUPJP] [nvarchar](max) NULL,
	[SUPEN] [nvarchar](max) NULL,
	[USERCODE] [nvarchar](10) NULL,
	[LINKDOWNMP3] [nvarchar](max) NULL,
	[IMAGE] [nvarchar](250) NULL,
	[VOTENUMBER] [nvarchar](10) NULL,
	[TOPPICCODE] [nvarchar](10) NULL,
	[LEVELCODE] [nvarchar](10) NULL,
	[MINACODE] [nvarchar](10) NULL,
	[DESCRIPTION] [nvarchar](max) NULL,
	[STATUS] [nvarchar](1) NULL,
	[ATTRIBUTE1] [nvarchar](50) NULL,
	[ATTRIBUTE2] [nvarchar](50) NULL,
	[CREATE_DATE] [nvarchar](10) NULL,
	[UP_DATE] [nvarchar](10) NULL,
 CONSTRAINT [PK_C_KAIWA] PRIMARY KEY CLUSTERED 
(
	[KAIWACODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[C_KANJI]    Script Date: 3/16/2018 8:45:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[C_KANJI](
	[KANJICODE] [nvarchar](10) NOT NULL,
	[ONOMI] [nvarchar](50) NULL,
	[KUNYOMI] [nvarchar](50) NULL,
	[HANVIET] [nvarchar](50) NULL,
	[NGHIAVIET] [nvarchar](250) NULL,
	[TOPICCODE] [nvarchar](10) NULL,
	[LEVELCODE] [nvarchar](10) NULL,
	[MINACODE] [nvarchar](10) NULL,
	[EXAMPLE1] [nvarchar](250) NULL,
	[MEAN_EX1] [nvarchar](250) NULL,
	[EXAMPLE2] [nvarchar](250) NULL,
	[MEAN_EX2] [nvarchar](250) NULL,
	[EXAMPLE3] [nvarchar](250) NULL,
	[MEAN_EX3] [nvarchar](250) NULL,
	[HINHVE] [nvarchar](250) NULL,
	[IMAGE] [nvarchar](250) NULL,
	[DESCRIPTION] [nvarchar](max) NULL,
	[STATUS] [nvarchar](1) NULL,
	[ATTRIBUTE1] [nvarchar](50) NULL,
	[ATTRIBUTE2] [nvarchar](50) NULL,
	[CREATE_DATE] [nvarchar](10) NULL,
	[UP_DATE] [nvarchar](10) NULL,
 CONSTRAINT [PK_C_KANJI] PRIMARY KEY CLUSTERED 
(
	[KANJICODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[C_WORD]    Script Date: 3/16/2018 8:45:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[C_WORD](
	[WORDCODE] [nvarchar](10) NOT NULL,
	[KANJI] [nvarchar](50) NULL,
	[HIRAGANA] [nvarchar](50) NULL,
	[KATAKANA] [nvarchar](50) NULL,
	[HANVIET] [nvarchar](50) NULL,
	[NGHIAVIET] [nvarchar](250) NULL,
	[TOPICCODE] [nvarchar](10) NULL,
	[LEVELCODE] [nvarchar](10) NULL,
	[MINACODE] [nvarchar](10) NULL,
	[EXAMPLE1] [nvarchar](250) NULL,
	[MEAN_EX1] [nvarchar](250) NULL,
	[EXAMPLE2] [nvarchar](250) NULL,
	[MEAN_EX2] [nvarchar](250) NULL,
	[EXAMPLE3] [nvarchar](250) NULL,
	[MEAN_EX3] [nvarchar](250) NULL,
	[IMAGE] [nvarchar](250) NULL,
	[DESCRIPTION] [nvarchar](max) NULL,
	[STATUS] [nvarchar](1) NULL,
	[ATTRIBUTE1] [nvarchar](50) NULL,
	[ATTRIBUTE2] [nvarchar](50) NULL,
	[CREATE_DATE] [nvarchar](10) NULL,
	[UP_DATE] [nvarchar](10) NULL,
 CONSTRAINT [PK_C_WORD] PRIMARY KEY CLUSTERED 
(
	[WORDCODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[M_ANSWER]    Script Date: 3/16/2018 8:45:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_ANSWER](
	[ANSWERCODE] [nvarchar](10) NOT NULL,
	[QUESTIONCODE] [nvarchar](10) NULL,
	[USERCODE] [nvarchar](10) NULL,
	[VOTENUMBER] [nvarchar](10) NULL,
	[DESCRIPTION] [nvarchar](max) NULL,
	[STATUS] [nvarchar](1) NULL,
	[ATTRIBUTE1] [nvarchar](50) NULL,
	[ATTRIBUTE2] [nvarchar](50) NULL,
	[CREATE_DATE] [nvarchar](10) NULL,
	[UP_DATE] [nvarchar](10) NULL,
 CONSTRAINT [PK_M_ANSWER] PRIMARY KEY CLUSTERED 
(
	[ANSWERCODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[M_AUTHORITY]    Script Date: 3/16/2018 8:45:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_AUTHORITY](
	[AUTHOCODE] [nvarchar](10) NOT NULL,
	[AUTHONAME] [nvarchar](50) NULL,
	[DESCRIPTION] [nvarchar](max) NULL,
	[STATUS] [nvarchar](1) NULL,
	[ATTRIBUTE1] [nvarchar](50) NULL,
	[ATTRIBUTE2] [nvarchar](50) NULL,
	[CREATE_DATE] [nvarchar](10) NULL,
	[UP_DATE] [nvarchar](10) NULL,
 CONSTRAINT [PK_M_AUTHORITY] PRIMARY KEY CLUSTERED 
(
	[AUTHOCODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[M_NEWS]    Script Date: 3/16/2018 8:45:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_NEWS](
	[NEWSCODE] [nvarchar](10) NOT NULL,
	[USERCODE] [nvarchar](10) NULL,
	[NEWSTITLE] [nvarchar](max) NULL,
	[INDEX1] [nvarchar](250) NULL,
	[INDEX2] [nvarchar](250) NULL,
	[INDEX3] [nvarchar](250) NULL,
	[DETAIL1] [nvarchar](max) NULL,
	[DETAIL2] [nvarchar](max) NULL,
	[DETAIL3] [nvarchar](max) NULL,
	[IMAGE] [nvarchar](250) NULL,
	[VOTENUMBER] [nvarchar](10) NULL,
	[TOPPICCODE] [nvarchar](10) NULL,
	[DESCRIPTION] [nvarchar](max) NULL,
	[STATUS] [nvarchar](1) NULL,
	[ATTRIBUTE1] [nvarchar](50) NULL,
	[ATTRIBUTE2] [nvarchar](50) NULL,
	[CREATE_DATE] [nvarchar](10) NULL,
	[UP_DATE] [nvarchar](10) NULL,
 CONSTRAINT [PK_M_NEWS] PRIMARY KEY CLUSTERED 
(
	[NEWSCODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[M_QUESTION]    Script Date: 3/16/2018 8:45:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_QUESTION](
	[QUESTIONCODE] [nvarchar](10) NOT NULL,
	[USERCODE] [nvarchar](10) NULL,
	[CONTENTQUESTION] [nvarchar](max) NULL,
	[VOTENUMBER] [nvarchar](10) NULL,
	[TOPPICCODE] [nvarchar](10) NULL,
	[DESCRIPTION] [nvarchar](max) NULL,
	[STATUS] [nvarchar](1) NULL,
	[ATTRIBUTE1] [nvarchar](50) NULL,
	[ATTRIBUTE2] [nvarchar](50) NULL,
	[CREATE_DATE] [nvarchar](10) NULL,
	[UP_DATE] [nvarchar](10) NULL,
 CONSTRAINT [PK_M_QUESTION] PRIMARY KEY CLUSTERED 
(
	[QUESTIONCODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[M_TOPPIC]    Script Date: 3/16/2018 8:45:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_TOPPIC](
	[TOPPICCODE] [nvarchar](10) NOT NULL,
	[TOPPICNAME] [nvarchar](50) NULL,
	[TITLE] [nvarchar](250) NULL,
	[INDEX1] [nvarchar](250) NULL,
	[INDEX2] [nvarchar](250) NULL,
	[INDEX3] [nvarchar](250) NULL,
	[DETAIL1] [nvarchar](max) NULL,
	[DETAIL2] [nvarchar](max) NULL,
	[DETAIL3] [nvarchar](max) NULL,
	[IMAGE] [nvarchar](250) NULL,
	[VOTENUMBER] [nvarchar](10) NULL,
	[DESCRIPTION] [nvarchar](max) NULL,
	[STATUS] [nvarchar](1) NULL,
	[ATTRIBUTE1] [nvarchar](50) NULL,
	[ATTRIBUTE2] [nvarchar](50) NULL,
	[CREATE_DATE] [nvarchar](10) NULL,
	[UP_DATE] [nvarchar](10) NULL,
 CONSTRAINT [PK_M_TOPPIC] PRIMARY KEY CLUSTERED 
(
	[TOPPICCODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[M_UNTILTBL]    Script Date: 3/16/2018 8:45:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_UNTILTBL](
	[UNTILCODE] [nvarchar](10) NOT NULL,
	[TBLCODE] [nvarchar](10) NULL,
	[TBLNAME] [nvarchar](50) NULL,
	[DESCRIPTION] [nvarchar](max) NULL,
	[STATUS] [nvarchar](1) NULL,
	[ATTRIBUTE1] [nvarchar](50) NULL,
	[ATTRIBUTE2] [nvarchar](50) NULL,
	[CREATE_DATE] [nvarchar](10) NULL,
	[UP_DATE] [nvarchar](10) NULL,
 CONSTRAINT [PK_M_UNTILTBL] PRIMARY KEY CLUSTERED 
(
	[UNTILCODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[M_USER]    Script Date: 3/16/2018 8:45:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_USER](
	[USERCODE] [nvarchar](10) NOT NULL,
	[AUTHOCODE] [nvarchar](10) NULL,
	[ACCOUNT] [nvarchar](50) NULL,
	[PASSWORD] [nvarchar](50) NULL,
	[EMAIL] [nvarchar](50) NULL,
	[NAME] [nvarchar](50) NULL,
	[AVATAR] [nvarchar](250) NULL,
	[PHONE] [nvarchar](20) NULL,
	[ADDRESS] [nvarchar](250) NULL,
	[SEX] [nvarchar](1) NULL,
	[DESCRIPTION] [nvarchar](max) NULL,
	[STATUS] [nvarchar](1) NULL,
	[ATTRIBUTE1] [nvarchar](50) NULL,
	[ATTRIBUTE2] [nvarchar](50) NULL,
	[CREATE_DATE] [nvarchar](10) NULL,
	[UP_DATE] [nvarchar](10) NULL,
 CONSTRAINT [PK_M_USER] PRIMARY KEY CLUSTERED 
(
	[USERCODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
