USE [EcommerceVer2]
GO
DELETE FROM [dbo].[Shipper]
GO
DELETE FROM [dbo].[Cart]
GO
DELETE FROM [dbo].[OrderDetails]
GO
DELETE FROM [dbo].[Order]
GO
DELETE FROM [dbo].[TransactStatus]
GO
DELETE FROM [dbo].[Customers]
GO
DELETE FROM [dbo].[Account]
GO
DELETE FROM [dbo].[Roles]
GO
DELETE FROM [dbo].[AttributePrices]
GO
DELETE FROM [dbo].[Product]
GO
DELETE FROM [dbo].[Brand]
GO
DELETE FROM [dbo].[Category]
GO
DELETE FROM [dbo].[Attribute]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CateID], [CategoryName], [Descriptions], [ParentID], [Levels], [Ordering], [IsPublished], [ThumbImg], [Title], [Alias], [Cover]) VALUES (1, N'Laptop', N'<p>Laptop</p>', 0, NULL, NULL, 1, N'laptop.png', N'Laptop', N'laptop', NULL)
INSERT [dbo].[Category] ([CateID], [CategoryName], [Descriptions], [ParentID], [Levels], [Ordering], [IsPublished], [ThumbImg], [Title], [Alias], [Cover]) VALUES (2, N'Smartphone', N'<p>Smartphone<br></p>', 0, NULL, NULL, 1, N'smartphone.jpg', N'Smartphone', N'smartphone', NULL)
INSERT [dbo].[Category] ([CateID], [CategoryName], [Descriptions], [ParentID], [Levels], [Ordering], [IsPublished], [ThumbImg], [Title], [Alias], [Cover]) VALUES (3, N'Phukien', N'<p>Phụ kiện</p>', 0, NULL, NULL, 1, N'phkin.jpg', N'Phụ kiện', N'phukien', NULL)
SET IDENTITY_INSERT [dbo].[Category] OFF
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
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleId], [RoleName], [Descriptions]) VALUES (2, N'Staff', N'Staff')
INSERT [dbo].[Roles] ([RoleId], [RoleName], [Descriptions]) VALUES (3, N'Admin', N'Admin')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([UserID], [Username], [Password], [Email], [FullName], [Phone], [CreateDate], [LastLogin], [RoleId], [IsActived], [Randomkey]) VALUES (1, N'Admin', N'4bf41f4c0bfebbdda7750cb50fb10884', N'laihuyha@gmail.com', N'Lại Huy Hà', N'0968454617', NULL, NULL, 3, 1, N'4@163     ')
INSERT [dbo].[Account] ([UserID], [Username], [Password], [Email], [FullName], [Phone], [CreateDate], [LastLogin], [RoleId], [IsActived], [Randomkey]) VALUES (2, N'Staff', N'a1dbfc5e025cfab8d57d8039b76f09b4', N'mahdi.noal@zooants.com', N'Staff', N'0968454612', NULL, NULL, 2, 1, N'*rcj9     ')
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([CustommerID], [Password], [FullName], [BirthDay], [Avatar], [Address], [Mail], [Phone], [District], [Ward], [CreateDate], [LastLogin], [IsActived], [Username], [Province], [Randomkey]) VALUES (1, N'ed67f7c2a101dc645d8c0894ed874a8c', N'Lại Huy Hà', NULL, N'avatar.png', N'41 Nguyễn Đường', N'laihuyha@gmail.com', N'0968454617', N'Huyện Chư Păh', N'Thị trấn Phú Hòa', CAST(N'2021-11-27T17:50:58.063' AS DateTime), NULL, 1, N'AdministratorAx102', N'Gia Lai', N'yvbv6')
INSERT [dbo].[Customers] ([CustommerID], [Password], [FullName], [BirthDay], [Avatar], [Address], [Mail], [Phone], [District], [Ward], [CreateDate], [LastLogin], [IsActived], [Username], [Province], [Randomkey]) VALUES (2, N'9bb2b0e7c5b2e9219c7f0bc21827b908', N'Trần Vũ Hải', NULL, N'avatar.png', N'adfasdfasdf', N'abctest@gmail.com', N'0911974341', N'Huyện Tu Mơ Rông', N'Xã Ngọk Lây', CAST(N'2021-11-27T17:52:01.250' AS DateTime), NULL, 1, N'Member1', N'Kon Tum', N'2giil')
INSERT [dbo].[Customers] ([CustommerID], [Password], [FullName], [BirthDay], [Avatar], [Address], [Mail], [Phone], [District], [Ward], [CreateDate], [LastLogin], [IsActived], [Username], [Province], [Randomkey]) VALUES (3, N'daf06c530fe903775bd6a087181f3e98', N'Huỳnh Đại Tấn', NULL, N'avatar.png', N'ádfasdfasdf', N'abctes1t@gmail.com', N'0968454612', N'Huyện Long Mỹ', N'Xã Vĩnh Thuận Đông', CAST(N'2021-11-27T17:52:58.303' AS DateTime), NULL, 1, N'Member2', N'Hậu Giang', N'lngpq')
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[TransactStatus] ON 

INSERT [dbo].[TransactStatus] ([TransactionStatusID], [Status], [Descriptions]) VALUES (1, N'Đơn hàng đã đặt', N'Đơn hàng đã đặt')
INSERT [dbo].[TransactStatus] ([TransactionStatusID], [Status], [Descriptions]) VALUES (2, N'Xác nhận thông tin thanh toán', N'Xác nhận thông tin thanh toán')
INSERT [dbo].[TransactStatus] ([TransactionStatusID], [Status], [Descriptions]) VALUES (3, N'Đang vận chuyển', N'Đang vận chuyển')
INSERT [dbo].[TransactStatus] ([TransactionStatusID], [Status], [Descriptions]) VALUES (4, N'Đơn hàng đã nhận', N'Đơn hàng đã nhận')
INSERT [dbo].[TransactStatus] ([TransactionStatusID], [Status], [Descriptions]) VALUES (5, N'Đơn hàng đã giao', N'Đơn hàng đã giao')
SET IDENTITY_INSERT [dbo].[TransactStatus] OFF
GO
