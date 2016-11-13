USE [master]
GO
/****** Object:  Database [DbDotNetStudio]    Script Date: 2016-11-09 18:15:20 ******/
CREATE DATABASE [DbDotNetStudio]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DbDotNetStudio', FILENAME = N'C:\DbDotNetStudio.mdf' , SIZE = 25600KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DbDotNetStudio_log', FILENAME = N'C:\DbDotNetStudio_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DbDotNetStudio] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DbDotNetStudio].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DbDotNetStudio] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DbDotNetStudio] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DbDotNetStudio] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DbDotNetStudio] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DbDotNetStudio] SET ARITHABORT OFF 
GO
ALTER DATABASE [DbDotNetStudio] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DbDotNetStudio] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DbDotNetStudio] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DbDotNetStudio] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DbDotNetStudio] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DbDotNetStudio] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DbDotNetStudio] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DbDotNetStudio] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DbDotNetStudio] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DbDotNetStudio] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DbDotNetStudio] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DbDotNetStudio] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DbDotNetStudio] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DbDotNetStudio] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DbDotNetStudio] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DbDotNetStudio] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DbDotNetStudio] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DbDotNetStudio] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DbDotNetStudio] SET  MULTI_USER 
GO
ALTER DATABASE [DbDotNetStudio] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DbDotNetStudio] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DbDotNetStudio] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DbDotNetStudio] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DbDotNetStudio] SET DELAYED_DURABILITY = DISABLED 
GO
USE [DbDotNetStudio]
GO
/****** Object:  Table [dbo].[TblArticle]    Script Date: 2016-11-09 18:15:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblArticle](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](128) NOT NULL,
	[Description] [nvarchar](256) NULL,
	[ContentUrl] [nvarchar](512) NOT NULL,
	[CreateTime] [datetime] NOT NULL CONSTRAINT [DF_TblArticle_CreateTime]  DEFAULT (getdate()),
	[UpdateTime] [datetime] NULL,
	[IsDelete] [bit] NOT NULL CONSTRAINT [DF_TblArticle_IsDelete]  DEFAULT ((0)),
	[LikeCount] [int] NOT NULL CONSTRAINT [DF_TblArticle_LikeCount]  DEFAULT ((0)),
	[DislikeCount] [int] NOT NULL CONSTRAINT [DF_TblArticle_DislikeCount]  DEFAULT ((0)),
 CONSTRAINT [PK_TblArticle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblArticleTblTag]    Script Date: 2016-11-09 18:15:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblArticleTblTag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ArticleId] [int] NOT NULL,
	[TagId] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL CONSTRAINT [DF_TblArticleTblTag_CreateTime]  DEFAULT (getdate()),
	[IsDelete] [bit] NOT NULL CONSTRAINT [DF_TblArticleTblTag_IsDelete]  DEFAULT ((0)),
 CONSTRAINT [PK_TblArticleTblTag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblTag]    Script Date: 2016-11-09 18:15:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblTag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](32) NOT NULL,
	[CreateTime] [datetime] NOT NULL CONSTRAINT [DF_TblTag_CreateTime]  DEFAULT (getdate()),
	[IsDelete] [bit] NOT NULL CONSTRAINT [DF_TblTag_IsDelete]  DEFAULT ((0)),
	[Remark] [nvarchar](50) NULL,
 CONSTRAINT [PK_TblTag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblUser]    Script Date: 2016-11-09 18:15:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](16) NULL,
	[Email] [nvarchar](32) NOT NULL,
	[Password] [nvarchar](32) NOT NULL,
	[IsEmailChecked] [bit] NOT NULL CONSTRAINT [DF_TblUser_IsEmailChecked]  DEFAULT ((0)),
	[CreateTime] [datetime] NOT NULL CONSTRAINT [DF_TblUser_CreateTime]  DEFAULT (getdate()),
	[IsDelete] [bit] NOT NULL CONSTRAINT [DF_TblUser_IsDelete]  DEFAULT ((0)),
 CONSTRAINT [PK_TblUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblUserTblArticle]    Script Date: 2016-11-09 18:15:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblUserTblArticle](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AuthorId] [int] NOT NULL,
	[ArticleId] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL CONSTRAINT [DF_TblUserTblArticle_CreateTime]  DEFAULT (getdate()),
	[Remark] [nvarchar](256) NULL,
	[IsDelete] [bit] NOT NULL CONSTRAINT [DF_TblUserTblArticle_IsDelete]  DEFAULT ((0)),
 CONSTRAINT [PK_TblUserTblArticle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Test1]    Script Date: 2016-11-09 18:15:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test1](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[A] [int] NOT NULL,
	[B] [nvarchar](8) NOT NULL,
	[C] [nvarchar](16) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Test2]    Script Date: 2016-11-09 18:15:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test2](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[A] [int] NOT NULL,
	[B] [int] NOT NULL,
	[C] [int] NOT NULL
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TblArticleTblTag]  WITH CHECK ADD  CONSTRAINT [FK_TblArticleTblTag_TblArticle] FOREIGN KEY([ArticleId])
REFERENCES [dbo].[TblArticle] ([Id])
GO
ALTER TABLE [dbo].[TblArticleTblTag] CHECK CONSTRAINT [FK_TblArticleTblTag_TblArticle]
GO
ALTER TABLE [dbo].[TblArticleTblTag]  WITH CHECK ADD  CONSTRAINT [FK_TblArticleTblTag_TblTag] FOREIGN KEY([TagId])
REFERENCES [dbo].[TblTag] ([Id])
GO
ALTER TABLE [dbo].[TblArticleTblTag] CHECK CONSTRAINT [FK_TblArticleTblTag_TblTag]
GO
ALTER TABLE [dbo].[TblUserTblArticle]  WITH CHECK ADD  CONSTRAINT [FK_TblUserTblArticle_TblArticle] FOREIGN KEY([ArticleId])
REFERENCES [dbo].[TblArticle] ([Id])
GO
ALTER TABLE [dbo].[TblUserTblArticle] CHECK CONSTRAINT [FK_TblUserTblArticle_TblArticle]
GO
ALTER TABLE [dbo].[TblUserTblArticle]  WITH CHECK ADD  CONSTRAINT [FK_TblUserTblArticle_TblUser] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[TblUser] ([Id])
GO
ALTER TABLE [dbo].[TblUserTblArticle] CHECK CONSTRAINT [FK_TblUserTblArticle_TblUser]
GO
USE [master]
GO
ALTER DATABASE [DbDotNetStudio] SET  READ_WRITE 
GO
