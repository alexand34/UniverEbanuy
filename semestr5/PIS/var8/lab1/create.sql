USE [master]
GO
/****** Object:  Database [lab8]    Script Date: 17.11.2019 15:11:34 ******/
CREATE DATABASE [lab8]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'lab8', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\lab8.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'lab8_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\lab8_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [lab8] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [lab8].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [lab8] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [lab8] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [lab8] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [lab8] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [lab8] SET ARITHABORT OFF 
GO
ALTER DATABASE [lab8] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [lab8] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [lab8] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [lab8] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [lab8] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [lab8] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [lab8] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [lab8] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [lab8] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [lab8] SET  DISABLE_BROKER 
GO
ALTER DATABASE [lab8] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [lab8] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [lab8] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [lab8] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [lab8] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [lab8] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [lab8] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [lab8] SET RECOVERY FULL 
GO
ALTER DATABASE [lab8] SET  MULTI_USER 
GO
ALTER DATABASE [lab8] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [lab8] SET DB_CHAINING OFF 
GO
ALTER DATABASE [lab8] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [lab8] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [lab8] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'lab8', N'ON'
GO
ALTER DATABASE [lab8] SET QUERY_STORE = OFF
GO
USE [lab8]
GO
/****** Object:  Table [dbo].[Cinemas]    Script Date: 17.11.2019 15:11:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cinemas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[CityId] [int] NOT NULL,
 CONSTRAINT [PK_Cinemas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 17.11.2019 15:11:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[CountryId] [int] NOT NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 17.11.2019 15:11:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cinemas]  WITH CHECK ADD  CONSTRAINT [FK_Cinemas_Cities] FOREIGN KEY([CityId])
REFERENCES [dbo].[Cities] ([Id])
GO
ALTER TABLE [dbo].[Cinemas] CHECK CONSTRAINT [FK_Cinemas_Cities]
GO
ALTER TABLE [dbo].[Cities]  WITH CHECK ADD  CONSTRAINT [FK_Cities_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([Id])
GO
ALTER TABLE [dbo].[Cities] CHECK CONSTRAINT [FK_Cities_Countries]
GO
USE [master]
GO
ALTER DATABASE [lab8] SET  READ_WRITE 
GO
