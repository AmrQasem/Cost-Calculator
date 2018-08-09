USE [master]
GO
/****** Object:  Database [CostCalculatorDB]    Script Date: 8/9/2018 1:45:52 PM ******/
CREATE DATABASE [CostCalculatorDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CostCalculatorDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\CostCalculatorDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CostCalculatorDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\CostCalculatorDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CostCalculatorDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CostCalculatorDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CostCalculatorDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CostCalculatorDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CostCalculatorDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CostCalculatorDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CostCalculatorDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CostCalculatorDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CostCalculatorDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CostCalculatorDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CostCalculatorDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CostCalculatorDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CostCalculatorDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CostCalculatorDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CostCalculatorDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CostCalculatorDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CostCalculatorDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CostCalculatorDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CostCalculatorDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CostCalculatorDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CostCalculatorDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CostCalculatorDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CostCalculatorDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CostCalculatorDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CostCalculatorDB] SET RECOVERY FULL 
GO
ALTER DATABASE [CostCalculatorDB] SET  MULTI_USER 
GO
ALTER DATABASE [CostCalculatorDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CostCalculatorDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CostCalculatorDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CostCalculatorDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CostCalculatorDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CostCalculatorDB', N'ON'
GO
USE [CostCalculatorDB]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 8/9/2018 1:45:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](150) NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[WorkRate] [int] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Languages]    Script Date: 8/9/2018 1:45:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_LANGUAGE_LOOKUP] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Quotation]    Script Date: 8/9/2018 1:45:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quotation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FromLangID] [int] NOT NULL,
	[ToLangID] [int] NOT NULL,
	[WordCount] [decimal](18, 2) NOT NULL,
	[IP_Address] [nvarchar](150) NULL,
	[IsRush] [bit] NULL CONSTRAINT [DF_Jobs_IsRush]  DEFAULT ((0)),
	[SubjectID] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
 CONSTRAINT [PK_Jobs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QuotationDetails]    Script Date: 8/9/2018 1:45:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuotationDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[QuotationID] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
	[Price] [decimal](18, 3) NOT NULL,
	[NumberOfDays] [decimal](18, 3) NOT NULL,
 CONSTRAINT [PK_JobDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 8/9/2018 1:45:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectTitle] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Subjects] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([ID], [CategoryName], [UnitPrice], [WorkRate]) VALUES (1, N'Standard', CAST(0.05 AS Decimal(18, 2)), 2000)
INSERT [dbo].[Categories] ([ID], [CategoryName], [UnitPrice], [WorkRate]) VALUES (2, N'Preimum', CAST(0.08 AS Decimal(18, 2)), 1500)
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Languages] ON 

INSERT [dbo].[Languages] ([ID], [Name]) VALUES (1, N'English')
INSERT [dbo].[Languages] ([ID], [Name]) VALUES (2, N'Arabic')
INSERT [dbo].[Languages] ([ID], [Name]) VALUES (3, N'German')
SET IDENTITY_INSERT [dbo].[Languages] OFF
SET IDENTITY_INSERT [dbo].[Quotation] ON 

INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (1, 1, 2, CAST(20000.00 AS Decimal(18, 2)), N'192.168.0.239', 0, 1, CAST(N'2018-08-06' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (2, 1, 2, CAST(20000.00 AS Decimal(18, 2)), N'192.168.0.239', 0, 1, CAST(N'2018-08-06' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (3, 1, 2, CAST(20000.00 AS Decimal(18, 2)), N'192.168.0.239', 0, 1, CAST(N'2018-08-06' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (4, 1, 2, CAST(20000.00 AS Decimal(18, 2)), N'192.168.0.239', 0, 1, CAST(N'2018-08-07' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (5, 2, 1, CAST(20000.00 AS Decimal(18, 2)), N'192.168.0.239', 0, 2, CAST(N'2018-08-07' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (6, 3, 2, CAST(60000.00 AS Decimal(18, 2)), N'192.168.0.239', 0, 2, CAST(N'2018-08-07' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (7, 3, 2, CAST(80000.00 AS Decimal(18, 2)), N'192.168.0.239', 0, 2, CAST(N'2018-08-07' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (8, 1, 2, CAST(50000.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 1, CAST(N'2018-08-07' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (9, 1, 2, CAST(50000.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 1, CAST(N'2018-08-07' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (10, 2, 3, CAST(9000.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 2, CAST(N'2018-08-07' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (11, 2, 3, CAST(9000.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 2, CAST(N'2018-08-07' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (12, 3, 2, CAST(90000.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 2, CAST(N'2018-08-07' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (13, 3, 2, CAST(90000.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 2, CAST(N'2018-08-07' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (14, 1, 2, CAST(10000.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 3, CAST(N'2018-08-07' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (15, 1, 2, CAST(10000.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 3, CAST(N'2018-08-07' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (16, 2, 3, CAST(60500.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 2, CAST(N'2018-08-07' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (17, 2, 3, CAST(60500.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 2, CAST(N'2018-08-07' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (18, 3, 2, CAST(80000.00 AS Decimal(18, 2)), N'192.168.0.239', 0, 2, CAST(N'2018-08-07' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (19, 1, 2, CAST(10000.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 2, CAST(N'2018-08-07' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (20, 1, 2, CAST(10000.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 2, CAST(N'2018-08-07' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (21, 1, 2, CAST(23500.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 2, CAST(N'2018-08-07' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (22, 1, 2, CAST(20000.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 1, CAST(N'2018-08-07' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (23, 3, 2, CAST(200000.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 1, CAST(N'2018-08-07' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (24, 3, 1, CAST(70000.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 1, CAST(N'2018-08-07' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (25, 1, 2, CAST(50000.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 2, CAST(N'2018-08-07' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (26, 1, 2, CAST(99999.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 2, CAST(N'2018-08-07' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (27, 1, 2, CAST(65423.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 1, CAST(N'2018-08-07' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (28, 1, 2, CAST(8597.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 1, CAST(N'2018-08-07' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (29, 2, 1, CAST(54026.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 1, CAST(N'2018-08-07' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (30, 1, 2, CAST(698574.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 2, CAST(N'2018-08-07' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (31, 1, 2, CAST(8888888.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 1, CAST(N'2018-08-07' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (32, 1, 2, CAST(989898.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 1, CAST(N'2018-08-07' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (33, 2, 1, CAST(4546546.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 1, CAST(N'2018-08-07' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (34, 1, 2, CAST(5242.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 1, CAST(N'2018-08-07' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (35, 1, 1, CAST(5242.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 1, CAST(N'2018-08-07' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (36, 1, 2, CAST(99999999.00 AS Decimal(18, 2)), N'fe80::ca8:ad16:d436:1986%4', NULL, 1, CAST(N'2018-08-07' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (1002, 2, 1, CAST(700000.00 AS Decimal(18, 2)), N'192.168.0.239', 1, 1, CAST(N'2018-08-08' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (1003, 1, 2, CAST(56258.00 AS Decimal(18, 2)), N'192.168.0.239', 1, 1, CAST(N'2018-08-08' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (1004, 1, 2, CAST(54026.00 AS Decimal(18, 2)), N'192.168.0.239', 1, 1, CAST(N'2018-08-08' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (1005, 1, 2, CAST(54026.00 AS Decimal(18, 2)), N'192.168.0.239', 1, 1, CAST(N'2018-08-08' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (1006, 2, 1, CAST(54026.00 AS Decimal(18, 2)), N'192.168.0.239', 1, 1, CAST(N'2018-08-08' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (1007, 2, 1, CAST(54026.00 AS Decimal(18, 2)), N'192.168.0.239', 1, 2, CAST(N'2018-08-08' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (1008, 2, 1, CAST(54026.00 AS Decimal(18, 2)), N'192.168.0.239', 1, 2, CAST(N'2018-08-08' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (1009, 1, 2, CAST(5242.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 2, CAST(N'2018-08-08' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (1010, 1, 2, CAST(2000.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 2, CAST(N'2018-08-08' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (1011, 1, 2, CAST(2000.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 2, CAST(N'2018-08-08' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (1012, 1, 2, CAST(689954.00 AS Decimal(18, 2)), N'192.168.0.241', 1, 2, CAST(N'2018-08-08' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (1013, 1, 2, CAST(2000.00 AS Decimal(18, 2)), N'192.168.0.241', 1, 2, CAST(N'2018-08-08' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (1014, 1, 2, CAST(4000.00 AS Decimal(18, 2)), N'192.168.0.241', 1, 1, CAST(N'2018-08-08' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (1015, 2, 1, CAST(4000.00 AS Decimal(18, 2)), N'192.168.0.241', 1, 1, CAST(N'2018-08-08' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (1019, 1, 2, CAST(3500.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 1, CAST(N'2018-08-08' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (1020, 1, 2, CAST(3500.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 1, CAST(N'2018-08-08' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (1021, 1, 2, CAST(3500.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 1, CAST(N'2018-08-08' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (1022, 1, 2, CAST(3500.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 1, CAST(N'2018-08-08' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (1023, 1, 2, CAST(3500.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 1, CAST(N'2018-08-08' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (1024, 1, 2, CAST(3500.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 1, CAST(N'2018-08-08' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (1025, 1, 2, CAST(30000.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 1, CAST(N'2018-08-08' AS Date))
INSERT [dbo].[Quotation] ([ID], [FromLangID], [ToLangID], [WordCount], [IP_Address], [IsRush], [SubjectID], [StartDate]) VALUES (1026, 1, 2, CAST(3500.00 AS Decimal(18, 2)), N'192.168.0.239', NULL, 1, CAST(N'2018-08-08' AS Date))
SET IDENTITY_INSERT [dbo].[Quotation] OFF
SET IDENTITY_INSERT [dbo].[QuotationDetails] ON 

INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (1, 1, 1, CAST(1000.000 AS Decimal(18, 3)), CAST(10.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (2, 1, 2, CAST(1600.000 AS Decimal(18, 3)), CAST(13.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (3, 2, 1, CAST(1000.000 AS Decimal(18, 3)), CAST(10.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (4, 2, 2, CAST(1600.000 AS Decimal(18, 3)), CAST(13.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (5, 3, 1, CAST(1000.000 AS Decimal(18, 3)), CAST(10.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (6, 3, 2, CAST(1600.000 AS Decimal(18, 3)), CAST(13.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (7, 5, 1, CAST(1540.000 AS Decimal(18, 3)), CAST(10.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (8, 5, 2, CAST(2200.000 AS Decimal(18, 3)), CAST(13.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (9, 6, 1, CAST(3300.000 AS Decimal(18, 3)), CAST(30.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (10, 6, 2, CAST(5280.000 AS Decimal(18, 3)), CAST(40.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (11, 7, 1, CAST(4400.000 AS Decimal(18, 3)), CAST(40.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (12, 7, 2, CAST(7040.000 AS Decimal(18, 3)), CAST(53.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (13, 8, 1, CAST(2500.000 AS Decimal(18, 3)), CAST(25.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (14, 8, 2, CAST(4000.000 AS Decimal(18, 3)), CAST(33.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (15, 9, 1, CAST(2500.000 AS Decimal(18, 3)), CAST(25.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (16, 9, 2, CAST(4000.000 AS Decimal(18, 3)), CAST(33.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (17, 11, 1, CAST(495.000 AS Decimal(18, 3)), CAST(5.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (18, 11, 2, CAST(792.000 AS Decimal(18, 3)), CAST(6.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (19, 10, 1, CAST(495.000 AS Decimal(18, 3)), CAST(5.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (20, 10, 2, CAST(792.000 AS Decimal(18, 3)), CAST(6.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (21, 13, 1, CAST(4950.000 AS Decimal(18, 3)), CAST(45.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (22, 13, 2, CAST(7920.000 AS Decimal(18, 3)), CAST(60.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (23, 12, 1, CAST(4950.000 AS Decimal(18, 3)), CAST(45.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (24, 12, 2, CAST(7920.000 AS Decimal(18, 3)), CAST(60.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (25, 14, 1, CAST(550.000 AS Decimal(18, 3)), CAST(5.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (26, 14, 2, CAST(880.000 AS Decimal(18, 3)), CAST(7.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (27, 15, 1, CAST(550.000 AS Decimal(18, 3)), CAST(5.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (28, 15, 2, CAST(880.000 AS Decimal(18, 3)), CAST(7.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (29, 16, 1, CAST(3327.500 AS Decimal(18, 3)), CAST(30.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (30, 16, 2, CAST(5324.000 AS Decimal(18, 3)), CAST(40.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (31, 17, 1, CAST(3327.500 AS Decimal(18, 3)), CAST(30.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (32, 17, 2, CAST(5324.000 AS Decimal(18, 3)), CAST(40.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (33, 18, 1, CAST(4400.000 AS Decimal(18, 3)), CAST(40.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (34, 18, 2, CAST(7040.000 AS Decimal(18, 3)), CAST(53.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (35, 20, 1, CAST(550.000 AS Decimal(18, 3)), CAST(5.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (36, 20, 2, CAST(880.000 AS Decimal(18, 3)), CAST(7.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (37, 19, 1, CAST(550.000 AS Decimal(18, 3)), CAST(5.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (38, 19, 2, CAST(880.000 AS Decimal(18, 3)), CAST(7.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (39, 21, 1, CAST(1292.500 AS Decimal(18, 3)), CAST(12.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (40, 21, 2, CAST(2068.000 AS Decimal(18, 3)), CAST(16.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (42, 23, 1, CAST(10000.000 AS Decimal(18, 3)), CAST(100.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (43, 23, 2, CAST(16000.000 AS Decimal(18, 3)), CAST(133.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (45, 24, 1, CAST(4900.000 AS Decimal(18, 3)), CAST(35.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (46, 24, 2, CAST(7000.000 AS Decimal(18, 3)), CAST(47.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (47, 25, 1, CAST(2750.000 AS Decimal(18, 3)), CAST(25.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (48, 25, 2, CAST(4400.000 AS Decimal(18, 3)), CAST(33.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (49, 26, 1, CAST(5499.945 AS Decimal(18, 3)), CAST(50.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (50, 26, 2, CAST(8799.912 AS Decimal(18, 3)), CAST(67.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (51, 27, 1, CAST(3271.150 AS Decimal(18, 3)), CAST(33.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (52, 27, 2, CAST(5233.840 AS Decimal(18, 3)), CAST(44.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (53, 28, 1, CAST(429.850 AS Decimal(18, 3)), CAST(4.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (54, 28, 2, CAST(687.760 AS Decimal(18, 3)), CAST(6.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (55, 29, 1, CAST(3781.820 AS Decimal(18, 3)), CAST(27.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (56, 29, 2, CAST(5402.600 AS Decimal(18, 3)), CAST(36.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (57, 30, 1, CAST(38421.570 AS Decimal(18, 3)), CAST(349.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (58, 30, 2, CAST(61474.512 AS Decimal(18, 3)), CAST(466.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (59, 31, 1, CAST(444444.400 AS Decimal(18, 3)), CAST(4444.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (60, 31, 2, CAST(711111.040 AS Decimal(18, 3)), CAST(5926.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (61, 32, 1, CAST(49494.900 AS Decimal(18, 3)), CAST(495.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (62, 32, 2, CAST(79191.840 AS Decimal(18, 3)), CAST(660.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (63, 33, 1, CAST(318258.220 AS Decimal(18, 3)), CAST(2273.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (64, 33, 2, CAST(454654.600 AS Decimal(18, 3)), CAST(3031.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (65, 34, 1, CAST(262.100 AS Decimal(18, 3)), CAST(3.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (66, 34, 2, CAST(419.360 AS Decimal(18, 3)), CAST(3.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (67, 35, 1, CAST(366.940 AS Decimal(18, 3)), CAST(3.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (68, 35, 2, CAST(524.200 AS Decimal(18, 3)), CAST(3.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (69, 36, 1, CAST(4999999.950 AS Decimal(18, 3)), CAST(50000.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (70, 36, 2, CAST(7999999.920 AS Decimal(18, 3)), CAST(66667.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (1002, 1002, 1, CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (1003, 1002, 2, CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (1004, 1003, 1, CAST(2812.900 AS Decimal(18, 3)), CAST(28.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (1005, 1006, 1, CAST(1134.546 AS Decimal(18, 3)), CAST(20.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (1006, 1006, 2, CAST(6483.120 AS Decimal(18, 3)), CAST(34.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (1007, 1007, 1, CAST(12863.304 AS Decimal(18, 3)), CAST(3.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (1008, 1007, 2, CAST(23240.744 AS Decimal(18, 3)), CAST(3.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (1009, 1008, 1, CAST(12863.304 AS Decimal(18, 3)), CAST(3.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (1010, 1008, 2, CAST(23240.744 AS Decimal(18, 3)), CAST(3.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (1011, 1009, 1, CAST(288.310 AS Decimal(18, 3)), CAST(3.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (1012, 1009, 2, CAST(461.296 AS Decimal(18, 3)), CAST(3.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (1013, 1010, 1, CAST(110.000 AS Decimal(18, 3)), CAST(1.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (1014, 1010, 2, CAST(176.000 AS Decimal(18, 3)), CAST(1.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (1015, 1011, 1, CAST(110.000 AS Decimal(18, 3)), CAST(1.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (1016, 1011, 2, CAST(176.000 AS Decimal(18, 3)), CAST(1.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (1017, 1012, 1, CAST(1214239.895 AS Decimal(18, 3)), CAST(3.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (1018, 1012, 2, CAST(2577499.075 AS Decimal(18, 3)), CAST(3.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (1019, 1014, 1, CAST(220.000 AS Decimal(18, 3)), CAST(1.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (1020, 1014, 2, CAST(373.333 AS Decimal(18, 3)), CAST(1.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (1021, 1015, 1, CAST(308.000 AS Decimal(18, 3)), CAST(1.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (1022, 1015, 2, CAST(466.666 AS Decimal(18, 3)), CAST(1.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (1023, 1020, 1, CAST(175.000 AS Decimal(18, 3)), CAST(2.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (1024, 1021, 1, CAST(175.000 AS Decimal(18, 3)), CAST(2.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (1025, 1022, 1, CAST(175.000 AS Decimal(18, 3)), CAST(2.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (1026, 1022, 2, CAST(280.000 AS Decimal(18, 3)), CAST(2.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (1027, 1023, 1, CAST(175.000 AS Decimal(18, 3)), CAST(2.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (1028, 1023, 2, CAST(280.000 AS Decimal(18, 3)), CAST(2.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (1029, 1024, 1, CAST(175.000 AS Decimal(18, 3)), CAST(2.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (1030, 1024, 2, CAST(280.000 AS Decimal(18, 3)), CAST(2.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (1031, 1025, 1, CAST(1500.000 AS Decimal(18, 3)), CAST(15.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (1032, 1025, 2, CAST(2400.000 AS Decimal(18, 3)), CAST(20.000 AS Decimal(18, 3)))
GO
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (1033, 1026, 1, CAST(175.000 AS Decimal(18, 3)), CAST(2.000 AS Decimal(18, 3)))
INSERT [dbo].[QuotationDetails] ([ID], [QuotationID], [CategoryID], [Price], [NumberOfDays]) VALUES (1034, 1026, 2, CAST(280.000 AS Decimal(18, 3)), CAST(2.000 AS Decimal(18, 3)))
SET IDENTITY_INSERT [dbo].[QuotationDetails] OFF
SET IDENTITY_INSERT [dbo].[Subjects] ON 

INSERT [dbo].[Subjects] ([ID], [SubjectTitle]) VALUES (1, N'General')
INSERT [dbo].[Subjects] ([ID], [SubjectTitle]) VALUES (2, N'Medical')
INSERT [dbo].[Subjects] ([ID], [SubjectTitle]) VALUES (3, N'Software Development')
SET IDENTITY_INSERT [dbo].[Subjects] OFF
ALTER TABLE [dbo].[Quotation]  WITH CHECK ADD  CONSTRAINT [FK_Quotation_Languages] FOREIGN KEY([FromLangID])
REFERENCES [dbo].[Languages] ([ID])
GO
ALTER TABLE [dbo].[Quotation] CHECK CONSTRAINT [FK_Quotation_Languages]
GO
ALTER TABLE [dbo].[Quotation]  WITH CHECK ADD  CONSTRAINT [FK_Quotation_Languages1] FOREIGN KEY([ToLangID])
REFERENCES [dbo].[Languages] ([ID])
GO
ALTER TABLE [dbo].[Quotation] CHECK CONSTRAINT [FK_Quotation_Languages1]
GO
ALTER TABLE [dbo].[Quotation]  WITH CHECK ADD  CONSTRAINT [FK_Quotation_Subjects] FOREIGN KEY([SubjectID])
REFERENCES [dbo].[Subjects] ([ID])
GO
ALTER TABLE [dbo].[Quotation] CHECK CONSTRAINT [FK_Quotation_Subjects]
GO
ALTER TABLE [dbo].[QuotationDetails]  WITH CHECK ADD  CONSTRAINT [FK_JobDetails_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([ID])
GO
ALTER TABLE [dbo].[QuotationDetails] CHECK CONSTRAINT [FK_JobDetails_Categories]
GO
ALTER TABLE [dbo].[QuotationDetails]  WITH CHECK ADD  CONSTRAINT [FK_QuotationDetails_Quotation] FOREIGN KEY([QuotationID])
REFERENCES [dbo].[Quotation] ([ID])
GO
ALTER TABLE [dbo].[QuotationDetails] CHECK CONSTRAINT [FK_QuotationDetails_Quotation]
GO
/****** Object:  StoredProcedure [dbo].[GetAllLang]    Script Date: 8/9/2018 1:45:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllLang] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	from [dbo].[Languages]
END

GO
/****** Object:  StoredProcedure [dbo].[GetCategoriesDetails]    Script Date: 8/9/2018 1:45:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCategoriesDetails] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	from [dbo].[Categories]
END

GO
/****** Object:  StoredProcedure [dbo].[GetQuotationDetails]    Script Date: 8/9/2018 1:45:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetQuotationDetails] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Q.[ID], Q.[FromLangID], L1.Name as FromLanguage, Q.[ToLangID],L2.Name as ToLanguage,
	Q.[WordCount], Q.[SubjectID], S.[SubjectTitle], QD.[CategoryID], C.[CategoryName]
	,QD.[StartDate], QD.[EndDate], QD.[Price], QD.[NumberOfDays], C.[UnitPrice],
	C.[WorkRate]  
	from [dbo].[Jobs] as Q
	inner join [dbo].[JobDetails] as QD on Q.ID = QD.ID
	inner join [dbo].[Categories] as C on QD.[CategoryID] = C.ID
	inner join [dbo].[Subjects] as S on Q.[SubjectID] = S.ID
	inner join [dbo].[Languages] as L1 on Q.[FromLangID] = L1.ID
	inner join [dbo].[Languages] as L2 on Q.[ToLangID] = L2.ID
END

GO
USE [master]
GO
ALTER DATABASE [CostCalculatorDB] SET  READ_WRITE 
GO
