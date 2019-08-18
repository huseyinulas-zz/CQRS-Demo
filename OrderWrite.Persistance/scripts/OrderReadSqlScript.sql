USE [master]
GO

/****** Object:  Database [OrderRead]    Script Date: 18.08.2019 15:08:18 ******/
CREATE DATABASE [OrderRead]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OrderRead', FILENAME = N'/var/opt/mssql/data/OrderRead.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OrderRead_log', FILENAME = N'/var/opt/mssql/data/OrderRead_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

ALTER DATABASE [OrderRead] SET COMPATIBILITY_LEVEL = 140
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OrderRead].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [OrderRead] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [OrderRead] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [OrderRead] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [OrderRead] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [OrderRead] SET ARITHABORT OFF 
GO

ALTER DATABASE [OrderRead] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [OrderRead] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [OrderRead] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [OrderRead] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [OrderRead] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [OrderRead] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [OrderRead] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [OrderRead] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [OrderRead] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [OrderRead] SET  DISABLE_BROKER 
GO

ALTER DATABASE [OrderRead] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [OrderRead] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [OrderRead] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [OrderRead] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [OrderRead] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [OrderRead] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [OrderRead] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [OrderRead] SET RECOVERY FULL 
GO

ALTER DATABASE [OrderRead] SET  MULTI_USER 
GO

ALTER DATABASE [OrderRead] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [OrderRead] SET DB_CHAINING OFF 
GO

ALTER DATABASE [OrderRead] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [OrderRead] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [OrderRead] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [OrderRead] SET QUERY_STORE = OFF
GO

ALTER DATABASE [OrderRead] SET  READ_WRITE 
GO


---------------------------------TABLE CREATE----------------------------------------------------------------------

USE [OrderRead]
GO
/****** Object:  Table [dbo].[OrderPreviews]    Script Date: 18.08.2019 15:08:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderPreviews](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[CustomerName] [nvarchar](250) NOT NULL,
	[CustomerAddress] [nvarchar](250) NOT NULL,
	[ProductName] [nvarchar](250) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Total] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_OrderPreview] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO