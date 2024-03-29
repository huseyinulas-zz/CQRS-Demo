-------------------------------------------------------------******---------------------------------------------------------------------------------------
-------------------------------------------------------------******---------------------------------------------------------------------------------------
-------------------------------------------------------------******---------------------------------------------------------------------------------------
------------------------------------------------------------DATABASE--------------------------------------------------------------------------------------
-------------------------------------------------------------******---------------------------------------------------------------------------------------
-------------------------------------------------------------******---------------------------------------------------------------------------------------
-------------------------------------------------------------******---------------------------------------------------------------------------------------
USE [master]
GO

/****** Object:  Database [OrderWrite]    Script Date: 25.08.2019 16:53:17 ******/
CREATE DATABASE [OrderWrite]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OrderWrite', FILENAME = N'/var/opt/mssql/data/OrderWrite.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OrderWrite_log', FILENAME = N'/var/opt/mssql/data/OrderWrite_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

ALTER DATABASE [OrderWrite] SET COMPATIBILITY_LEVEL = 140
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OrderWrite].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [OrderWrite] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [OrderWrite] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [OrderWrite] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [OrderWrite] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [OrderWrite] SET ARITHABORT OFF 
GO

ALTER DATABASE [OrderWrite] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [OrderWrite] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [OrderWrite] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [OrderWrite] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [OrderWrite] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [OrderWrite] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [OrderWrite] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [OrderWrite] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [OrderWrite] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [OrderWrite] SET  DISABLE_BROKER 
GO

ALTER DATABASE [OrderWrite] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [OrderWrite] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [OrderWrite] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [OrderWrite] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [OrderWrite] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [OrderWrite] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [OrderWrite] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [OrderWrite] SET RECOVERY FULL 
GO

ALTER DATABASE [OrderWrite] SET  MULTI_USER 
GO

ALTER DATABASE [OrderWrite] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [OrderWrite] SET DB_CHAINING OFF 
GO

ALTER DATABASE [OrderWrite] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [OrderWrite] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [OrderWrite] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [OrderWrite] SET QUERY_STORE = OFF
GO

ALTER DATABASE [OrderWrite] SET  READ_WRITE 
GO

-------------------------------------------------------------******---------------------------------------------------------------------------------------
-------------------------------------------------------------******---------------------------------------------------------------------------------------
-------------------------------------------------------------******---------------------------------------------------------------------------------------
-------------------------------------------------------------TABLES---------------------------------------------------------------------------------------
-------------------------------------------------------------******---------------------------------------------------------------------------------------
-------------------------------------------------------------******---------------------------------------------------------------------------------------
-------------------------------------------------------------******---------------------------------------------------------------------------------------

USE [OrderWrite]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 25.08.2019 16:53:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Adress] [nvarchar](250) NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 25.08.2019 16:53:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Total] [decimal](10, 2) NOT NULL,
	[OrderStatus] [nvarchar](150) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 25.08.2019 16:53:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](250) NOT NULL,
	[Price] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
