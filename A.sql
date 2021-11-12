USE [master]
GO
/****** Object:  Database [EcommerceVer2]    Script Date: 11/12/2021 5:20:18 PM ******/
CREATE DATABASE [EcommerceVer2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EcommerceVer2', FILENAME = N'D:\SQL Express 2019\MSSQL15.SQLEXPRESS\MSSQL\DATA\EcommerceVer2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EcommerceVer2_log', FILENAME = N'D:\SQL Express 2019\MSSQL15.SQLEXPRESS\MSSQL\DATA\EcommerceVer2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
ALTER DATABASE [EcommerceVer2] SET AUTO_CLOSE OFF 
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
ALTER DATABASE [EcommerceVer2] SET  DISABLE_BROKER 
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
ALTER DATABASE [EcommerceVer2] SET READ_COMMITTED_SNAPSHOT OFF 
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
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/12/2021 5:20:18 PM ******/
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
/****** Object:  Table [dbo].[Account]    Script Date: 11/12/2021 5:20:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[FullName] [nvarchar](150) NULL,
	[Phone] [varchar](13) NULL,
	[CreateDate] [datetime] NULL,
	[LastLogin] [datetime] NULL,
	[RoleId] [int] NULL,
	[IsActived] [bit] NOT NULL,
	[CartID] [int] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attribute]    Script Date: 11/12/2021 5:20:18 PM ******/
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
/****** Object:  Table [dbo].[AttributePrices]    Script Date: 11/12/2021 5:20:18 PM ******/
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
/****** Object:  Table [dbo].[Cart]    Script Date: 11/12/2021 5:20:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[CartID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[ProductID] [int] NULL,
	[Quantity] [int] NULL,
	[Price] [int] NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
(
	[CartID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 11/12/2021 5:20:18 PM ******/
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
	[IsPublished] [bit] NULL,
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
/****** Object:  Table [dbo].[Customers]    Script Date: 11/12/2021 5:20:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustommerID] [int] IDENTITY(1,1) NOT NULL,
	[Password] [nvarchar](150) NULL,
	[FullName] [nvarchar](max) NULL,
	[BirthDay] [datetime] NULL,
	[Avatar] [nvarchar](250) NULL,
	[Address] [nvarchar](250) NULL,
	[Mail] [nvarchar](250) NULL,
	[Phone] [varchar](13) NULL,
	[LocationID] [int] NULL,
	[District] [int] NULL,
	[Ward] [int] NULL,
	[CreateDate] [datetime] NULL,
	[LastLogin] [datetime] NULL,
	[IsActived] [bit] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustommerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 11/12/2021 5:20:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[LocationID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL,
	[Slug] [nvarchar](100) NULL,
	[NameWithType] [nvarchar](255) NULL,
	[PathWithType] [nvarchar](255) NULL,
	[ParentCode] [int] NULL,
	[Levels] [int] NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[LocationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 11/12/2021 5:20:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[OrderDate] [datetime] NULL,
	[ShipDate] [datetime] NULL,
	[TransactionStatusID] [int] NULL,
	[IsDeleted] [bit] NULL,
	[IsPaid] [bit] NULL,
	[PaymentDate] [datetime] NULL,
	[PaymentID] [int] NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 11/12/2021 5:20:18 PM ******/
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
	[Total] [int] NULL,
	[Shipdate] [datetime] NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 11/12/2021 5:20:18 PM ******/
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
	[Price] [int] NULL,
	[Discount] [int] NULL,
	[ThumbImg] [nvarchar](max) NULL,
	[Video] [nvarchar](max) NULL,
	[DateCreated] [datetime] NULL,
	[DateModified] [datetime] NULL,
	[IsBestsellers] [bit] NULL,
	[Homeflag] [bit] NULL,
	[IsActived] [bit] NOT NULL,
	[Tag] [nvarchar](max) NULL,
	[Title] [nvarchar](max) NULL,
	[Alias] [nvarchar](max) NULL,
	[UnitInStock] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 11/12/2021 5:20:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
	[Descriptions] [nvarchar](200) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shipper]    Script Date: 11/12/2021 5:20:18 PM ******/
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
 CONSTRAINT [PK_Shipper1] PRIMARY KEY CLUSTERED 
(
	[ShipperID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactStatus]    Script Date: 11/12/2021 5:20:18 PM ******/
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
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([UserID], [Username], [Password], [Email], [FullName], [Phone], [CreateDate], [LastLogin], [RoleId], [IsActived], [CartID]) VALUES (1, N'AdministratorAx99', N'123456', N'laihuyha@gmail.com', N'Lại Huy Hà', N'0968454617', CAST(N'2021-11-10T20:51:00.000' AS DateTime), CAST(N'2021-11-10T20:51:00.000' AS DateTime), 5, 1, NULL)
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CateID], [CategoryName], [Descriptions], [ParentID], [Levels], [Ordering], [IsPublished], [ThumbImg], [Title], [Alias], [Cover]) VALUES (7, N'TEst', N'test', 1, 1, NULL, 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([CustommerID], [Password], [FullName], [BirthDay], [Avatar], [Address], [Mail], [Phone], [LocationID], [District], [Ward], [CreateDate], [LastLogin], [IsActived]) VALUES (1, NULL, N'Lại Huy Hà', CAST(N'2021-11-11T21:46:00.000' AS DateTime), NULL, NULL, N'laihuyha@gmail.com', N'0968454617', 1, NULL, NULL, CAST(N'2021-11-11T21:46:00.000' AS DateTime), CAST(N'2021-11-11T21:46:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Location] ON 

INSERT [dbo].[Location] ([LocationID], [Name], [Type], [Slug], [NameWithType], [PathWithType], [ParentCode], [Levels]) VALUES (1, N'TP.HCM', NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Location] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductID], [ProductName], [ShortDesc], [Descriptions], [CateID], [Price], [Discount], [ThumbImg], [Video], [DateCreated], [DateModified], [IsBestsellers], [Homeflag], [IsActived], [Tag], [Title], [Alias], [UnitInStock]) VALUES (1, N'Test', NULL, N'Just Test', 7, 1000, NULL, NULL, NULL, CAST(N'2021-11-12T10:51:00.000' AS DateTime), CAST(N'2021-11-12T10:51:00.000' AS DateTime), 1, NULL, 1, NULL, NULL, NULL, 10)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleId], [RoleName], [Descriptions]) VALUES (2, N'Staff', N'Staff')
INSERT [dbo].[Roles] ([RoleId], [RoleName], [Descriptions]) VALUES (5, N'Admin', N'Admin')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Cart] FOREIGN KEY([CartID])
REFERENCES [dbo].[Cart] ([CartID])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Cart]
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
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Location] FOREIGN KEY([LocationID])
REFERENCES [dbo].[Location] ([LocationID])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_Location]
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
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CateID])
REFERENCES [dbo].[Category] ([CateID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
USE [master]
GO
ALTER DATABASE [EcommerceVer2] SET  READ_WRITE 
GO
