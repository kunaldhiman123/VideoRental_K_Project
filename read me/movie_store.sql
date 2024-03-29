USE [master]
GO
/****** Object:  Database [movie_Store]    Script Date: 15/05/2021 1:48:45 AM ******/
CREATE DATABASE [movie_Store]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'movie_Store_Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\movie_Store.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'movie_Store_Log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\movie_Store.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [movie_Store] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [movie_Store].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [movie_Store] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [movie_Store] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [movie_Store] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [movie_Store] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [movie_Store] SET ARITHABORT OFF 
GO
ALTER DATABASE [movie_Store] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [movie_Store] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [movie_Store] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [movie_Store] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [movie_Store] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [movie_Store] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [movie_Store] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [movie_Store] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [movie_Store] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [movie_Store] SET  DISABLE_BROKER 
GO
ALTER DATABASE [movie_Store] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [movie_Store] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [movie_Store] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [movie_Store] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [movie_Store] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [movie_Store] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [movie_Store] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [movie_Store] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [movie_Store] SET  MULTI_USER 
GO
ALTER DATABASE [movie_Store] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [movie_Store] SET DB_CHAINING OFF 
GO
ALTER DATABASE [movie_Store] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [movie_Store] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [movie_Store] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [movie_Store] SET QUERY_STORE = OFF
GO
USE [movie_Store]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 15/05/2021 1:48:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[bookID] [int] IDENTITY(1,1) NOT NULL,
	[userID] [int] NULL,
	[VideoID] [int] NULL,
	[dateIssue] [varchar](50) NULL,
	[dateReturn] [varchar](50) NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[bookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 15/05/2021 1:48:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[userID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[userID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[video]    Script Date: 15/05/2021 1:48:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[video](
	[VideoID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NULL,
	[Stars] [varchar](50) NULL,
	[Year] [varchar](50) NULL,
	[Copies] [varchar](50) NULL,
	[Cost] [int] NULL,
	[Plot] [varchar](50) NULL,
	[Production] [varchar](50) NULL,
 CONSTRAINT [PK_video] PRIMARY KEY CLUSTERED 
(
	[VideoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Booking] ON 

INSERT [dbo].[Booking] ([bookID], [userID], [VideoID], [dateIssue], [dateReturn]) VALUES (1, 1, 1, N'5/14/2021', N'5/14/2021')
SET IDENTITY_INSERT [dbo].[Booking] OFF
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([userID], [Name], [Email], [Address]) VALUES (1, N'ok', N'W@gmail.com', N'nz')
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[video] ON 

INSERT [dbo].[video] ([VideoID], [Title], [Stars], [Year], [Copies], [Cost], [Plot], [Production]) VALUES (1, N'ok', N'5', N'2019', N'5', 5, N'ok', N'ok')
SET IDENTITY_INSERT [dbo].[video] OFF
USE [master]
GO
ALTER DATABASE [movie_Store] SET  READ_WRITE 
GO
