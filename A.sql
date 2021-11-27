USE [master]
GO
/****** Object:  Database [EcommerceVer2]    Script Date: 11/27/2021 4:01:07 PM ******/
CREATE DATABASE [EcommerceVer2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EcommerceVer2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EcommerceVer2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EcommerceVer2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EcommerceVer2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EcommerceVer2] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EcommerceVer2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EcommerceVer2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EcommerceVer2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EcommerceVer2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EcommerceVer2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EcommerceVer2] SET ARITHABORT OFF 
GO
ALTER DATABASE [EcommerceVer2] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [EcommerceVer2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EcommerceVer2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EcommerceVer2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EcommerceVer2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EcommerceVer2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EcommerceVer2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EcommerceVer2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EcommerceVer2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EcommerceVer2] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EcommerceVer2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EcommerceVer2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EcommerceVer2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EcommerceVer2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EcommerceVer2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EcommerceVer2] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [EcommerceVer2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EcommerceVer2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EcommerceVer2] SET  MULTI_USER 
GO
ALTER DATABASE [EcommerceVer2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EcommerceVer2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EcommerceVer2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EcommerceVer2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EcommerceVer2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EcommerceVer2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [EcommerceVer2] SET QUERY_STORE = OFF
GO
USE [EcommerceVer2]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/27/2021 4:01:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 11/27/2021 4:01:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[FullName] [nvarchar](150) NOT NULL,
	[Phone] [varchar](13) NULL,
	[CreateDate] [datetime] NULL,
	[LastLogin] [datetime] NULL,
	[RoleId] [int] NULL,
	[IsActived] [bit] NOT NULL,
	[Randomkey] [nchar](10) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attribute]    Script Date: 11/27/2021 4:01:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attribute](
	[AttributeID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Attribute] PRIMARY KEY CLUSTERED 
(
	[AttributeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AttributePrices]    Script Date: 11/27/2021 4:01:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttributePrices](
	[AttributePriceID] [int] IDENTITY(1,1) NOT NULL,
	[AttributeID] [int] NULL,
	[ProductID] [int] NULL,
	[Price] [int] NULL,
	[IsActived] [bit] NULL,
 CONSTRAINT [PK_AttributePrices] PRIMARY KEY CLUSTERED 
(
	[AttributePriceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 11/27/2021 4:01:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[BrandID] [int] IDENTITY(1,1) NOT NULL,
	[BrandName] [nvarchar](100) NULL,
	[Logo] [nvarchar](max) NULL,
 CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED 
(
	[BrandID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 11/27/2021 4:01:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[CartID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[ProductID] [int] NULL,
	[Quantity] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
(
	[CartID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 11/27/2021 4:01:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CateID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](200) NOT NULL,
	[Descriptions] [nvarchar](250) NULL,
	[ParentID] [int] NOT NULL,
	[Levels] [int] NULL,
	[Ordering] [int] NULL,
	[IsPublished] [bit] NOT NULL,
	[ThumbImg] [nvarchar](250) NULL,
	[Title] [nvarchar](200) NULL,
	[Alias] [nvarchar](250) NULL,
	[Cover] [nvarchar](255) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 11/27/2021 4:01:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustommerID] [int] IDENTITY(1,1) NOT NULL,
	[Password] [nvarchar](max) NULL,
	[FullName] [nvarchar](max) NULL,
	[BirthDay] [datetime] NULL,
	[Avatar] [nvarchar](250) NULL,
	[Address] [nvarchar](max) NULL,
	[Mail] [nvarchar](max) NULL,
	[Phone] [varchar](13) NULL,
	[District] [nvarchar](max) NULL,
	[Ward] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[LastLogin] [datetime] NULL,
	[IsActived] [bit] NOT NULL,
	[Username] [nvarchar](max) NULL,
	[Province] [nvarchar](max) NULL,
	[Randomkey] [nvarchar](10) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustommerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 11/27/2021 4:01:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[OrderDate] [datetime] NOT NULL,
	[TransactionStatusID] [int] NULL,
	[IsDeleted] [bit] NULL,
	[IsPaid] [bit] NULL,
	[Note] [nvarchar](max) NULL,
	[TotalMoney] [decimal](18, 2) NULL,
	[District] [nvarchar](max) NULL,
	[Province] [nvarchar](max) NULL,
	[Ward] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 11/27/2021 4:01:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderDetailID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NULL,
	[ProductID] [int] NULL,
	[OrderNumber] [int] NULL,
	[Quantity] [int] NULL,
	[Discount] [int] NULL,
	[Total] [decimal](18, 2) NULL,
	[CreateDate] [datetime] NULL,
	[Price] [decimal](18, 2) NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 11/27/2021 4:01:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](255) NOT NULL,
	[ShortDesc] [nvarchar](255) NULL,
	[Descriptions] [nvarchar](255) NULL,
	[CateID] [int] NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Discount] [int] NULL,
	[ThumbImg] [nvarchar](max) NULL,
	[Video] [nvarchar](max) NULL,
	[DateCreated] [datetime] NULL,
	[DateModified] [datetime] NULL,
	[IsBestsellers] [bit] NOT NULL,
	[Homeflag] [bit] NOT NULL,
	[IsActived] [bit] NOT NULL,
	[Tag] [nvarchar](max) NULL,
	[Title] [nvarchar](max) NULL,
	[Alias] [nvarchar](max) NULL,
	[UnitInStock] [int] NULL,
	[BrandID] [int] NULL,
	[SalesPrice] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 11/27/2021 4:01:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
	[Descriptions] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shipper]    Script Date: 11/27/2021 4:01:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shipper](
	[ShipperID] [int] IDENTITY(1,1) NOT NULL,
	[ShipperName] [nvarchar](200) NULL,
	[Phone] [varchar](13) NULL,
	[Company] [nvarchar](255) NULL,
	[Shipdate] [datetime] NULL,
 CONSTRAINT [PK_Shipper] PRIMARY KEY CLUSTERED 
(
	[ShipperID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactStatus]    Script Date: 11/27/2021 4:01:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactStatus](
	[TransactionStatusID] [int] NOT NULL,
	[Status] [nvarchar](50) NULL,
	[Descriptions] [nvarchar](50) NULL,
 CONSTRAINT [PK_TransactStatus] PRIMARY KEY CLUSTERED 
(
	[TransactionStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211113045229_initDb', N'5.0.12')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211115042041_Fix_bool_product', N'5.0.12')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211115141833_AddUserNameForCustomer', N'5.0.12')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211116093741_BigDataUpdate', N'5.0.12')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211118101238_BrandModel', N'5.0.12')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211119153608_salesprice', N'5.0.12')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211119161240_salesprice1', N'5.0.12')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211119173212_salesprice2', N'5.0.12')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211120063312_InitKeyforAccount', N'5.0.12')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211121054454_TotalMoney_ForOrderTable', N'5.0.12')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211122031425_AccountRandomkey', N'5.0.12')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211126033440_Addr', N'5.0.12')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211126033651_Addr_order', N'5.0.12')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211126035719_fix_orderdetail', N'5.0.12')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211126090418_fix_order', N'5.0.12')
GO
SET IDENTITY_INSERT [dbo].[Brand] ON 

INSERT [dbo].[Brand] ([BrandID], [BrandName], [Logo]) VALUES (1, N'Apple', N'apple.png')
INSERT [dbo].[Brand] ([BrandID], [BrandName], [Logo]) VALUES (2, N'Oppo', N'oppo.jpg')
INSERT [dbo].[Brand] ([BrandID], [BrandName], [Logo]) VALUES (3, N'Nokia', N'nokia.jpg')
INSERT [dbo].[Brand] ([BrandID], [BrandName], [Logo]) VALUES (4, N'Dell', N'dell.jpg')
INSERT [dbo].[Brand] ([BrandID], [BrandName], [Logo]) VALUES (5, N'Xiaomi', N'xiaomi.jpg')
INSERT [dbo].[Brand] ([BrandID], [BrandName], [Logo]) VALUES (6, N'HP', N'hp.jpg')
INSERT [dbo].[Brand] ([BrandID], [BrandName], [Logo]) VALUES (7, N'Asus', N'asus.jpeg')
INSERT [dbo].[Brand] ([BrandID], [BrandName], [Logo]) VALUES (8, N'MSI', N'msi.png')
INSERT [dbo].[Brand] ([BrandID], [BrandName], [Logo]) VALUES (9, N'Samsung', N'samsung.jpg')
INSERT [dbo].[Brand] ([BrandID], [BrandName], [Logo]) VALUES (10, N'Logitech', N'logitech.png')
SET IDENTITY_INSERT [dbo].[Brand] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CateID], [CategoryName], [Descriptions], [ParentID], [Levels], [Ordering], [IsPublished], [ThumbImg], [Title], [Alias], [Cover]) VALUES (1, N'Laptop', N'<p>Laptop</p>', 0, NULL, NULL, 1, N'laptop.png', N'Laptop', N'laptop', NULL)
INSERT [dbo].[Category] ([CateID], [CategoryName], [Descriptions], [ParentID], [Levels], [Ordering], [IsPublished], [ThumbImg], [Title], [Alias], [Cover]) VALUES (2, N'Smartphone', N'<p>Smartphone<br></p>', 0, NULL, NULL, 1, N'smartphone.jpg', N'Smartphone', N'smartphone', NULL)
INSERT [dbo].[Category] ([CateID], [CategoryName], [Descriptions], [ParentID], [Levels], [Ordering], [IsPublished], [ThumbImg], [Title], [Alias], [Cover]) VALUES (3, N'Phukien', N'<p>Phụ kiện</p>', 0, NULL, NULL, 1, N'phkin.jpg', N'Phụ kiện', N'phukien', NULL)
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductID], [ProductName], [ShortDesc], [Descriptions], [CateID], [Price], [Discount], [ThumbImg], [Video], [DateCreated], [DateModified], [IsBestsellers], [Homeflag], [IsActived], [Tag], [Title], [Alias], [UnitInStock], [BrandID], [SalesPrice]) VALUES (1, N'Iphone13 Pro Max', NULL, N'<p>Iphone 13 Pro max màu xanh</p>', 2, CAST(27000000.00 AS Decimal(18, 2)), 1, N'iphone13promax.jpg', NULL, CAST(N'2021-11-27T13:58:00.000' AS DateTime), CAST(N'2021-11-27T14:00:01.213' AS DateTime), 1, 1, 1, N'IP13', N'Smartphone', N'iphone13promax', 50, 1, CAST(26730000.00 AS Decimal(18, 2)))
INSERT [dbo].[Product] ([ProductID], [ProductName], [ShortDesc], [Descriptions], [CateID], [Price], [Discount], [ThumbImg], [Video], [DateCreated], [DateModified], [IsBestsellers], [Homeflag], [IsActived], [Tag], [Title], [Alias], [UnitInStock], [BrandID], [SalesPrice]) VALUES (2, N'Nokia51 4GB', NULL, N'<p>Nokia 51 4GB</p>', 2, CAST(7000000.00 AS Decimal(18, 2)), 0, N'nokia514gb.jpg', NULL, CAST(N'2021-11-27T13:59:50.000' AS DateTime), CAST(N'2021-11-27T15:31:50.330' AS DateTime), 1, 1, 1, N'Nokia', N'Smartphone', N'nokia514gb', 50, 3, CAST(7000000.00 AS Decimal(18, 2)))
INSERT [dbo].[Product] ([ProductID], [ProductName], [ShortDesc], [Descriptions], [CateID], [Price], [Discount], [ThumbImg], [Video], [DateCreated], [DateModified], [IsBestsellers], [Homeflag], [IsActived], [Tag], [Title], [Alias], [UnitInStock], [BrandID], [SalesPrice]) VALUES (3, N'Oppo Reno6 5G', NULL, N'<p>OppoReno6_5G<br></p>', 2, CAST(7500000.00 AS Decimal(18, 2)), 0, N'opporeno65g.jpg', NULL, CAST(N'2021-11-27T14:02:01.000' AS DateTime), CAST(N'2021-11-27T14:02:27.157' AS DateTime), 1, 1, 1, N'Oppo reno6', N'Smartphone', N'opporeno65g', 50, 2, CAST(7500000.00 AS Decimal(18, 2)))
INSERT [dbo].[Product] ([ProductID], [ProductName], [ShortDesc], [Descriptions], [CateID], [Price], [Discount], [ThumbImg], [Video], [DateCreated], [DateModified], [IsBestsellers], [Homeflag], [IsActived], [Tag], [Title], [Alias], [UnitInStock], [BrandID], [SalesPrice]) VALUES (4, N'Samsung Galaxy Z Flod3 5G', NULL, N'<p>Samsung GalaxyZ Flod3 5G<br></p>', 2, CAST(17000000.00 AS Decimal(18, 2)), 0, N'samsunggalaxyzflod35g.jpg', NULL, CAST(N'2021-11-27T14:04:25.000' AS DateTime), CAST(N'2021-11-27T15:39:08.737' AS DateTime), 1, 1, 1, N'samsung galaxy z Flod3', N'Smartphone', N'samsunggalaxyzflod35g', 50, 9, CAST(17000000.00 AS Decimal(18, 2)))
INSERT [dbo].[Product] ([ProductID], [ProductName], [ShortDesc], [Descriptions], [CateID], [Price], [Discount], [ThumbImg], [Video], [DateCreated], [DateModified], [IsBestsellers], [Homeflag], [IsActived], [Tag], [Title], [Alias], [UnitInStock], [BrandID], [SalesPrice]) VALUES (5, N'Xiaomi Redmi Note10', NULL, N'<p>xiaomi redmi note-10<br></p>', 2, CAST(9000000.00 AS Decimal(18, 2)), 1, N'xiaomiredminote10.png', NULL, CAST(N'2021-11-27T14:05:58.800' AS DateTime), CAST(N'2021-11-27T14:05:58.800' AS DateTime), 1, 1, 1, N'Xiaomi', N'Smartphone', N'xiaomiredminote10', 50, 5, CAST(8910000.00 AS Decimal(18, 2)))
INSERT [dbo].[Product] ([ProductID], [ProductName], [ShortDesc], [Descriptions], [CateID], [Price], [Discount], [ThumbImg], [Video], [DateCreated], [DateModified], [IsBestsellers], [Homeflag], [IsActived], [Tag], [Title], [Alias], [UnitInStock], [BrandID], [SalesPrice]) VALUES (6, N'Asus E420S', NULL, N'<p>Asus E420S</p>', 1, CAST(25000000.00 AS Decimal(18, 2)), 1, N'asuse420s.jpg', NULL, CAST(N'2021-11-27T14:07:26.303' AS DateTime), CAST(N'2021-11-27T14:07:26.303' AS DateTime), 1, 1, 1, N'Asus', N'Laptop', N'asuse420s', 50, 7, CAST(24750000.00 AS Decimal(18, 2)))
INSERT [dbo].[Product] ([ProductID], [ProductName], [ShortDesc], [Descriptions], [CateID], [Price], [Discount], [ThumbImg], [Video], [DateCreated], [DateModified], [IsBestsellers], [Homeflag], [IsActived], [Tag], [Title], [Alias], [UnitInStock], [BrandID], [SalesPrice]) VALUES (7, N'Dell Gaming G5', NULL, N'<p>Dell Gaming G5</p>', 1, CAST(21000000.00 AS Decimal(18, 2)), 0, N'dellgamingg5.jpg', NULL, CAST(N'2021-11-27T14:08:38.000' AS DateTime), CAST(N'2021-11-27T15:32:56.507' AS DateTime), 1, 1, 1, N'Dell Gaming', N'Laptop', N'dellgamingg5', 50, 4, CAST(21000000.00 AS Decimal(18, 2)))
INSERT [dbo].[Product] ([ProductID], [ProductName], [ShortDesc], [Descriptions], [CateID], [Price], [Discount], [ThumbImg], [Video], [DateCreated], [DateModified], [IsBestsellers], [Homeflag], [IsActived], [Tag], [Title], [Alias], [UnitInStock], [BrandID], [SalesPrice]) VALUES (8, N'HP Pavilion Gaming 15', NULL, N'<p>HP Pavilion Gaming 15<br></p>', 1, CAST(21000000.00 AS Decimal(18, 2)), 2, N'hppaviliongaming15.jpg', NULL, CAST(N'2021-11-27T14:09:56.000' AS DateTime), CAST(N'2021-11-27T15:33:30.173' AS DateTime), 1, 1, 1, N'HP Gaming', N'Laptop', N'hppaviliongaming15', 50, 6, CAST(20580000.00 AS Decimal(18, 2)))
INSERT [dbo].[Product] ([ProductID], [ProductName], [ShortDesc], [Descriptions], [CateID], [Price], [Discount], [ThumbImg], [Video], [DateCreated], [DateModified], [IsBestsellers], [Homeflag], [IsActived], [Tag], [Title], [Alias], [UnitInStock], [BrandID], [SalesPrice]) VALUES (9, N'Macbook M1 2019', NULL, N'<p>Macbook M1 2019 256Gb</p>', 1, CAST(51000000.00 AS Decimal(18, 2)), 1, N'macbookm12019.png', NULL, CAST(N'2021-11-27T14:11:12.210' AS DateTime), CAST(N'2021-11-27T14:11:12.210' AS DateTime), 1, 1, 1, N'Macbook M1', N'Laptop', N'macbookm12019', 50, 1, CAST(50490000.00 AS Decimal(18, 2)))
INSERT [dbo].[Product] ([ProductID], [ProductName], [ShortDesc], [Descriptions], [CateID], [Price], [Discount], [ThumbImg], [Video], [DateCreated], [DateModified], [IsBestsellers], [Homeflag], [IsActived], [Tag], [Title], [Alias], [UnitInStock], [BrandID], [SalesPrice]) VALUES (10, N'MSI Gaming GF65', NULL, N'<p>MSI Gaming GF65<br></p>', 1, CAST(21000000.00 AS Decimal(18, 2)), 1, N'msigaminggf65.jpg', NULL, CAST(N'2021-11-27T14:11:57.000' AS DateTime), CAST(N'2021-11-27T15:33:43.427' AS DateTime), 1, 1, 1, N'MSI Gaming', N'Laptop', N'msigaminggf65', 50, 8, CAST(20790000.00 AS Decimal(18, 2)))
INSERT [dbo].[Product] ([ProductID], [ProductName], [ShortDesc], [Descriptions], [CateID], [Price], [Discount], [ThumbImg], [Video], [DateCreated], [DateModified], [IsBestsellers], [Homeflag], [IsActived], [Tag], [Title], [Alias], [UnitInStock], [BrandID], [SalesPrice]) VALUES (11, N'Airpod Pro', NULL, N'<p>Apple Airpod Pro<br></p>', 3, CAST(5000000.00 AS Decimal(18, 2)), 1, N'airpodpro.jpg', NULL, CAST(N'2021-11-27T14:13:34.000' AS DateTime), CAST(N'2021-11-27T14:13:51.900' AS DateTime), 1, 1, 1, N'AirPod Pro', N'PhuKien', N'airpodpro', 50, 1, CAST(4950000.00 AS Decimal(18, 2)))
INSERT [dbo].[Product] ([ProductID], [ProductName], [ShortDesc], [Descriptions], [CateID], [Price], [Discount], [ThumbImg], [Video], [DateCreated], [DateModified], [IsBestsellers], [Homeflag], [IsActived], [Tag], [Title], [Alias], [UnitInStock], [BrandID], [SalesPrice]) VALUES (12, N'Magic Keyboard', NULL, N'<p>Apple Magic Keyboard<br></p>', 3, CAST(2700000.00 AS Decimal(18, 2)), 0, N'magickeyboard.jpg', NULL, CAST(N'2021-11-27T14:16:01.473' AS DateTime), CAST(N'2021-11-27T14:16:01.473' AS DateTime), 1, 1, 1, N'Magic keyboard', N'PhuKien', N'magickeyboard', 50, 1, CAST(2700000.00 AS Decimal(18, 2)))
INSERT [dbo].[Product] ([ProductID], [ProductName], [ShortDesc], [Descriptions], [CateID], [Price], [Discount], [ThumbImg], [Video], [DateCreated], [DateModified], [IsBestsellers], [Homeflag], [IsActived], [Tag], [Title], [Alias], [UnitInStock], [BrandID], [SalesPrice]) VALUES (13, N'Bàn Phím Cơ MSI', NULL, N'<p>Bàn phím cơ MSI</p>', 3, CAST(1100000.00 AS Decimal(18, 2)), 0, N'bnphmcmsi.png', NULL, CAST(N'2021-11-27T14:17:25.833' AS DateTime), CAST(N'2021-11-27T14:17:25.833' AS DateTime), 1, 1, 1, N'Bàn phím cơ MSI', N'PhuKien', N'bnphmcmsi', 50, 8, CAST(1100000.00 AS Decimal(18, 2)))
INSERT [dbo].[Product] ([ProductID], [ProductName], [ShortDesc], [Descriptions], [CateID], [Price], [Discount], [ThumbImg], [Video], [DateCreated], [DateModified], [IsBestsellers], [Homeflag], [IsActived], [Tag], [Title], [Alias], [UnitInStock], [BrandID], [SalesPrice]) VALUES (14, N'Bàn Phím Logitech', NULL, N'<p>Bàn phím logitech</p>', 3, CAST(7000000.00 AS Decimal(18, 2)), 0, N'bnphmlogitech.png', NULL, CAST(N'2021-11-27T14:18:31.697' AS DateTime), CAST(N'2021-11-27T14:18:31.697' AS DateTime), 1, 1, 1, N'bàn phím logitech', N'PhuKien', N'bnphmlogitech', 50, 10, CAST(7000000.00 AS Decimal(18, 2)))
INSERT [dbo].[Product] ([ProductID], [ProductName], [ShortDesc], [Descriptions], [CateID], [Price], [Discount], [ThumbImg], [Video], [DateCreated], [DateModified], [IsBestsellers], [Homeflag], [IsActived], [Tag], [Title], [Alias], [UnitInStock], [BrandID], [SalesPrice]) VALUES (15, N'Chuột Apple Magic ', NULL, N'<p>Chuột Apple Magic&nbsp;<br></p>', 3, CAST(2000000.00 AS Decimal(18, 2)), 1, N'chutapplemagic.jpg', NULL, CAST(N'2021-11-27T14:20:08.720' AS DateTime), CAST(N'2021-11-27T14:20:08.720' AS DateTime), 1, 1, 1, N'Chuột apple ', N'PhuKien', N'chutapplemagic', 50, 1, CAST(1980000.00 AS Decimal(18, 2)))
INSERT [dbo].[Product] ([ProductID], [ProductName], [ShortDesc], [Descriptions], [CateID], [Price], [Discount], [ThumbImg], [Video], [DateCreated], [DateModified], [IsBestsellers], [Homeflag], [IsActived], [Tag], [Title], [Alias], [UnitInStock], [BrandID], [SalesPrice]) VALUES (16, N'Chuột Gaming MSI', NULL, N'<p>Chuột Gaming MSI</p>', 3, CAST(450000.00 AS Decimal(18, 2)), 1, N'chutgamingmsi.jpg', NULL, CAST(N'2021-11-27T14:21:06.210' AS DateTime), CAST(N'2021-11-27T14:21:06.210' AS DateTime), 1, 1, 1, N'Chuột gaming MSI', N'PhuKien', N'chutgamingmsi', 40, 8, CAST(445500.00 AS Decimal(18, 2)))
INSERT [dbo].[Product] ([ProductID], [ProductName], [ShortDesc], [Descriptions], [CateID], [Price], [Discount], [ThumbImg], [Video], [DateCreated], [DateModified], [IsBestsellers], [Homeflag], [IsActived], [Tag], [Title], [Alias], [UnitInStock], [BrandID], [SalesPrice]) VALUES (17, N'Chuột Logitech', NULL, N'<p>chuột không dây logitech</p>', 3, CAST(210000.00 AS Decimal(18, 2)), 0, N'chutlogitech.jpg', NULL, CAST(N'2021-11-27T14:22:21.000' AS DateTime), CAST(N'2021-11-27T15:56:44.673' AS DateTime), 1, 1, 1, N'Chuột logitech', N'PhuKien', N'chutlogitech', 40, 10, CAST(210000.00 AS Decimal(18, 2)))
INSERT [dbo].[Product] ([ProductID], [ProductName], [ShortDesc], [Descriptions], [CateID], [Price], [Discount], [ThumbImg], [Video], [DateCreated], [DateModified], [IsBestsellers], [Homeflag], [IsActived], [Tag], [Title], [Alias], [UnitInStock], [BrandID], [SalesPrice]) VALUES (18, N'Lót Chuột MSI', NULL, N'<p>Lót chuột MSI</p>', 3, CAST(100000.00 AS Decimal(18, 2)), 0, N'ltchutmsi.png', NULL, CAST(N'2021-11-27T14:23:13.000' AS DateTime), CAST(N'2021-11-27T15:56:29.030' AS DateTime), 1, 1, 1, N'Lót chuột MSI', N'PhuKien', N'ltchutmsi', 40, 8, CAST(100000.00 AS Decimal(18, 2)))
INSERT [dbo].[Product] ([ProductID], [ProductName], [ShortDesc], [Descriptions], [CateID], [Price], [Discount], [ThumbImg], [Video], [DateCreated], [DateModified], [IsBestsellers], [Homeflag], [IsActived], [Tag], [Title], [Alias], [UnitInStock], [BrandID], [SalesPrice]) VALUES (19, N'Tai Nghe Oppo', NULL, N'<p>tai nghe oppo</p>', 3, CAST(270000.00 AS Decimal(18, 2)), 1, N'taingheoppo.jpg', NULL, CAST(N'2021-11-27T14:24:05.000' AS DateTime), CAST(N'2021-11-27T15:56:17.330' AS DateTime), 1, 1, 1, N'tai nghe oppo', N'PhuKien', N'taingheoppo', 50, 2, CAST(267300.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
/****** Object:  Index [IX_Account_RoleId]    Script Date: 11/27/2021 4:01:08 PM ******/
CREATE NONCLUSTERED INDEX [IX_Account_RoleId] ON [dbo].[Account]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AttributePrices_AttributeID]    Script Date: 11/27/2021 4:01:08 PM ******/
CREATE NONCLUSTERED INDEX [IX_AttributePrices_AttributeID] ON [dbo].[AttributePrices]
(
	[AttributeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AttributePrices_ProductID]    Script Date: 11/27/2021 4:01:08 PM ******/
CREATE NONCLUSTERED INDEX [IX_AttributePrices_ProductID] ON [dbo].[AttributePrices]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Order_CustomerID]    Script Date: 11/27/2021 4:01:08 PM ******/
CREATE NONCLUSTERED INDEX [IX_Order_CustomerID] ON [dbo].[Order]
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Order_TransactionStatusID]    Script Date: 11/27/2021 4:01:08 PM ******/
CREATE NONCLUSTERED INDEX [IX_Order_TransactionStatusID] ON [dbo].[Order]
(
	[TransactionStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderDetails_OrderID]    Script Date: 11/27/2021 4:01:08 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetails_OrderID] ON [dbo].[OrderDetails]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderDetails_ProductID]    Script Date: 11/27/2021 4:01:08 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetails_ProductID] ON [dbo].[OrderDetails]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Product_BrandID]    Script Date: 11/27/2021 4:01:08 PM ******/
CREATE NONCLUSTERED INDEX [IX_Product_BrandID] ON [dbo].[Product]
(
	[BrandID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Product_CateID]    Script Date: 11/27/2021 4:01:08 PM ******/
CREATE NONCLUSTERED INDEX [IX_Product_CateID] ON [dbo].[Product]
(
	[CateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT (N'') FOR [FullName]
GO
ALTER TABLE [dbo].[Cart] ADD  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[Cart] ADD  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[Category] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsPublished]
GO
ALTER TABLE [dbo].[Order] ADD  DEFAULT ('0001-01-01T00:00:00.000') FOR [OrderDate]
GO
ALTER TABLE [dbo].[Product] ADD  DEFAULT (CONVERT([bit],(0))) FOR [Homeflag]
GO
ALTER TABLE [dbo].[Roles] ADD  DEFAULT (N'') FOR [Descriptions]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Roles]
GO
ALTER TABLE [dbo].[AttributePrices]  WITH CHECK ADD  CONSTRAINT [FK_AttributePrices_Attribute] FOREIGN KEY([AttributeID])
REFERENCES [dbo].[Attribute] ([AttributeID])
GO
ALTER TABLE [dbo].[AttributePrices] CHECK CONSTRAINT [FK_AttributePrices_Attribute]
GO
ALTER TABLE [dbo].[AttributePrices]  WITH CHECK ADD  CONSTRAINT [FK_AttributePrices_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[AttributePrices] CHECK CONSTRAINT [FK_AttributePrices_Product]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([CustommerID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customers]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_TransactStatus] FOREIGN KEY([TransactionStatusID])
REFERENCES [dbo].[TransactStatus] ([TransactionStatusID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_TransactStatus]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Order]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Brand] FOREIGN KEY([BrandID])
REFERENCES [dbo].[Brand] ([BrandID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Brand]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CateID])
REFERENCES [dbo].[Category] ([CateID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
USE [master]
GO
ALTER DATABASE [EcommerceVer2] SET  READ_WRITE 
GO
