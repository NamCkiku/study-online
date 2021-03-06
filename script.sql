USE [master]
GO
/****** Object:  Database [StudyOnline]    Script Date: 3/5/2016 2:46:44 PM ******/
CREATE DATABASE [StudyOnline]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StudyOnline', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\StudyOnline.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'StudyOnline_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\StudyOnline_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [StudyOnline] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StudyOnline].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StudyOnline] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StudyOnline] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StudyOnline] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StudyOnline] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StudyOnline] SET ARITHABORT OFF 
GO
ALTER DATABASE [StudyOnline] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StudyOnline] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StudyOnline] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StudyOnline] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StudyOnline] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StudyOnline] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StudyOnline] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StudyOnline] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StudyOnline] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StudyOnline] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StudyOnline] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StudyOnline] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StudyOnline] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StudyOnline] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StudyOnline] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StudyOnline] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StudyOnline] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StudyOnline] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StudyOnline] SET  MULTI_USER 
GO
ALTER DATABASE [StudyOnline] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StudyOnline] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StudyOnline] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StudyOnline] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [StudyOnline] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'StudyOnline', N'ON'
GO
USE [StudyOnline]
GO
/****** Object:  Table [dbo].[AttachMent]    Script Date: 3/5/2016 2:46:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttachMent](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](500) NULL,
	[Path] [nvarchar](500) NULL,
	[Type] [int] NULL,
	[CreateDate] [datetime] NULL,
	[Status] [bit] NULL,
	[LessonID] [bigint] NULL,
 CONSTRAINT [PK_AttachMent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Comment]    Script Date: 3/5/2016 2:46:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[ID] [bigint] NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Content] [ntext] NULL,
	[CreateDate] [datetime] NULL,
	[Avatar] [nvarchar](500) NULL,
	[Status] [bit] NULL,
	[UserID] [bigint] NULL,
	[LessonID] [bigint] NULL,
	[ParentID] [int] NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Course]    Script Date: 3/5/2016 2:46:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CourseName] [nvarchar](250) NULL,
	[Avatar] [nvarchar](250) NULL,
	[VideoIntroduce] [nvarchar](500) NULL,
	[Description] [nvarchar](500) NULL,
	[Content] [ntext] NULL,
	[PriceSale] [float] NULL,
	[Price] [float] NULL,
	[ViewCount] [int] NULL,
	[CreateDate] [datetime] NULL,
	[Tags] [nvarchar](max) NULL,
	[Status] [bit] NULL,
	[TopHot] [bit] NULL,
	[MetaTitle] [nvarchar](250) NULL,
	[CourseCategoryID] [bigint] NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CourseCategory]    Script Date: 3/5/2016 2:46:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseCategory](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Descrpition] [nvarchar](500) NULL,
	[ParentID] [int] NULL,
	[Link] [nvarchar](250) NULL,
	[Tags] [nvarchar](500) NULL,
	[MetaTittle] [nvarchar](250) NULL,
	[CreateDate] [datetime] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_CourseCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FriendUser]    Script Date: 3/5/2016 2:46:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FriendUser](
	[FriendID] [bigint] NOT NULL,
	[UserID] [bigint] NOT NULL,
	[AddFriendDate] [datetime] NULL,
	[Status] [bit] NULL,
	[Follow] [bit] NULL,
 CONSTRAINT [PK_FriendUser_1] PRIMARY KEY CLUSTERED 
(
	[FriendID] ASC,
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GroupUser]    Script Date: 3/5/2016 2:46:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupUser](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[UserID] [bigint] NULL,
	[RolesID] [int] NULL,
 CONSTRAINT [PK_GroupUser] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lesson]    Script Date: 3/5/2016 2:46:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lesson](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[LessonName] [nvarchar](250) NULL,
	[Description] [nvarchar](500) NULL,
	[CreateDate] [datetime] NULL,
	[Status] [bit] NULL,
	[SectionID] [bigint] NULL,
 CONSTRAINT [PK_Lesson] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PayMent]    Script Date: 3/5/2016 2:46:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PayMent](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[QuantityCoin] [int] NULL,
	[HistoryTrade] [datetime] NULL,
	[Status] [bit] NULL,
	[UserID] [bigint] NULL,
 CONSTRAINT [PK_PayMent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Section]    Script Date: 3/5/2016 2:46:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Section](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SectionName] [nvarchar](250) NULL,
	[Title] [nvarchar](250) NULL,
	[Description] [nvarchar](500) NULL,
	[CreateDate] [datetime] NULL,
	[Status] [bit] NULL,
	[CourseID] [bigint] NULL,
 CONSTRAINT [PK_Section] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Test]    Script Date: 3/5/2016 2:46:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[TimeTest] [int] NULL,
	[SectionID] [bigint] NULL,
	[Point] [int] NULL,
	[Rank] [int] NULL,
 CONSTRAINT [PK_Test] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TestAnswer]    Script Date: 3/5/2016 2:46:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestAnswer](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[TittleAnswer] [ntext] NULL,
	[TestQuestionID] [bigint] NULL,
 CONSTRAINT [PK_TestAnswer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TestQuestion]    Script Date: 3/5/2016 2:46:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestQuestion](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[TittleQuestion] [ntext] NULL,
	[TestID] [bigint] NULL,
 CONSTRAINT [PK_TestQuestion] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 3/5/2016 2:46:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](250) NULL,
	[Password] [nvarchar](250) NULL,
	[Name] [nvarchar](250) NULL,
	[Address] [nvarchar](500) NULL,
	[Email] [nvarchar](250) NULL,
	[Phone] [nvarchar](50) NULL,
	[Avatar] [nvarchar](500) NULL,
	[Status] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[GroupID] [varchar](20) NULL,
	[PayID] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User_Course]    Script Date: 3/5/2016 2:46:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Course](
	[UserID] [bigint] NOT NULL,
	[CourseID] [bigint] NOT NULL,
 CONSTRAINT [PK_User_Course] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User_Study_Course]    Script Date: 3/5/2016 2:46:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Study_Course](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NULL,
	[CourseID] [bigint] NULL,
	[Status] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_User_Study_Course] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User_Teacher_Course]    Script Date: 3/5/2016 2:46:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Teacher_Course](
	[UserID] [bigint] NOT NULL,
	[CourseID] [bigint] NOT NULL,
	[CreateDate] [datetime] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_User_Teacher_Course] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Video]    Script Date: 3/5/2016 2:46:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Video](
	[ID] [bigint] NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Link] [nvarchar](250) NULL,
	[Length] [time](7) NULL,
	[CreateDate] [datetime] NULL,
	[Description] [nvarchar](500) NULL,
	[Status] [bit] NULL,
	[LessonID] [bigint] NULL,
 CONSTRAINT [PK_Video] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_GroupID]  DEFAULT ('MEMBER') FOR [GroupID]
GO
ALTER TABLE [dbo].[AttachMent]  WITH CHECK ADD  CONSTRAINT [FK_AttachMent_Lesson] FOREIGN KEY([LessonID])
REFERENCES [dbo].[Lesson] ([ID])
GO
ALTER TABLE [dbo].[AttachMent] CHECK CONSTRAINT [FK_AttachMent_Lesson]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Lesson1] FOREIGN KEY([LessonID])
REFERENCES [dbo].[Lesson] ([ID])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Lesson1]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_CourseCategory1] FOREIGN KEY([CourseCategoryID])
REFERENCES [dbo].[CourseCategory] ([ID])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_CourseCategory1]
GO
ALTER TABLE [dbo].[FriendUser]  WITH CHECK ADD  CONSTRAINT [FK_FriendUser_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[FriendUser] CHECK CONSTRAINT [FK_FriendUser_User]
GO
ALTER TABLE [dbo].[Lesson]  WITH CHECK ADD  CONSTRAINT [FK_Lesson_Section1] FOREIGN KEY([SectionID])
REFERENCES [dbo].[Section] ([ID])
GO
ALTER TABLE [dbo].[Lesson] CHECK CONSTRAINT [FK_Lesson_Section1]
GO
ALTER TABLE [dbo].[PayMent]  WITH CHECK ADD  CONSTRAINT [FK_PayMent_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[PayMent] CHECK CONSTRAINT [FK_PayMent_User]
GO
ALTER TABLE [dbo].[Section]  WITH CHECK ADD  CONSTRAINT [FK_Section_Course] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([ID])
GO
ALTER TABLE [dbo].[Section] CHECK CONSTRAINT [FK_Section_Course]
GO
ALTER TABLE [dbo].[Test]  WITH CHECK ADD  CONSTRAINT [FK_Test_Section] FOREIGN KEY([SectionID])
REFERENCES [dbo].[Section] ([ID])
GO
ALTER TABLE [dbo].[Test] CHECK CONSTRAINT [FK_Test_Section]
GO
ALTER TABLE [dbo].[TestAnswer]  WITH CHECK ADD  CONSTRAINT [FK_TestAnswer_TestQuestion] FOREIGN KEY([TestQuestionID])
REFERENCES [dbo].[TestQuestion] ([ID])
GO
ALTER TABLE [dbo].[TestAnswer] CHECK CONSTRAINT [FK_TestAnswer_TestQuestion]
GO
ALTER TABLE [dbo].[TestQuestion]  WITH CHECK ADD  CONSTRAINT [FK_TestQuestion_Test] FOREIGN KEY([TestID])
REFERENCES [dbo].[Test] ([ID])
GO
ALTER TABLE [dbo].[TestQuestion] CHECK CONSTRAINT [FK_TestQuestion_Test]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_GroupUser] FOREIGN KEY([ID])
REFERENCES [dbo].[GroupUser] ([ID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_GroupUser]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_User_Study_Course] FOREIGN KEY([ID])
REFERENCES [dbo].[User_Study_Course] ([ID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_User_Study_Course]
GO
ALTER TABLE [dbo].[User_Course]  WITH CHECK ADD  CONSTRAINT [FK_User_Course_Course] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([ID])
GO
ALTER TABLE [dbo].[User_Course] CHECK CONSTRAINT [FK_User_Course_Course]
GO
ALTER TABLE [dbo].[User_Course]  WITH CHECK ADD  CONSTRAINT [FK_User_Course_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[User_Course] CHECK CONSTRAINT [FK_User_Course_User]
GO
ALTER TABLE [dbo].[User_Study_Course]  WITH CHECK ADD  CONSTRAINT [FK_User_Study_Course_Course] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([ID])
GO
ALTER TABLE [dbo].[User_Study_Course] CHECK CONSTRAINT [FK_User_Study_Course_Course]
GO
ALTER TABLE [dbo].[User_Teacher_Course]  WITH CHECK ADD  CONSTRAINT [FK_User_Teacher_Course_Course] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([ID])
GO
ALTER TABLE [dbo].[User_Teacher_Course] CHECK CONSTRAINT [FK_User_Teacher_Course_Course]
GO
ALTER TABLE [dbo].[User_Teacher_Course]  WITH CHECK ADD  CONSTRAINT [FK_User_Teacher_Course_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[User_Teacher_Course] CHECK CONSTRAINT [FK_User_Teacher_Course_User]
GO
ALTER TABLE [dbo].[Video]  WITH CHECK ADD  CONSTRAINT [FK_Video_Lesson1] FOREIGN KEY([LessonID])
REFERENCES [dbo].[Lesson] ([ID])
GO
ALTER TABLE [dbo].[Video] CHECK CONSTRAINT [FK_Video_Lesson1]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Các loại file đính kèm của 1 đối tượng' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AttachMent', @level2type=N'COLUMN',@level2name=N'Type'
GO
USE [master]
GO
ALTER DATABASE [StudyOnline] SET  READ_WRITE 
GO
