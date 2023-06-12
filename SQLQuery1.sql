CREATE TABLE [Role] (
	Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(50) NOT NULL
)

CREATE TABLE [User](
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	RoleID INT NOT NULL
		FOREIGN KEY REFERENCES [Role](Id)
		ON UPDATE CASCADE ON DELETE CASCADE,
	UserName VARCHAR(50) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	Gender VARCHAR(50) NOT NULL,
	[Password] VARCHAR(50) NOT NULL,
)

CREATE TABLE Header(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	CustomerId INT NOT NULL
		FOREIGN KEY REFERENCES [User](Id)
		ON UPDATE CASCADE ON DELETE CASCADE,
	StaffId INT NOT NULL,
	[Date] DATETIME
)

CREATE TABLE Meat (
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name] VARCHAR(50) NOT NULL
)


CREATE TABLE Ramen(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	MeatId INT NOT NULL
		FOREIGN KEY REFERENCES Meat(Id)
		ON UPDATE CASCADE ON DELETE CASCADE,
	[Name] VARCHAR(50) NOT NULL,
	Broth VARCHAR(50) NOT NULL,
	Price VARCHAR(50) NOT  NULL
)

CREATE TABLE [dbo].[Detail] (
    [HeaderId] INT NOT NULL,
    [RamenId]  INT NOT NULL,
    [Quantity] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([HeaderId] ASC, [RamenId] ASC),
    FOREIGN KEY ([HeaderId]) REFERENCES [dbo].[Header] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY ([RamenId]) REFERENCES [dbo].[Ramen] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);

SET IDENTITY_INSERT [dbo].[Role] ON
INSERT INTO [dbo].[Role] ([Id], [Name]) VALUES (1, N'Admin')
INSERT INTO [dbo].[Role] ([Id], [Name]) VALUES (2, N'Staff')
INSERT INTO [dbo].[Role] ([Id], [Name]) VALUES (3, N'Member')
SET IDENTITY_INSERT [dbo].[Role] OFF

SET IDENTITY_INSERT [dbo].[User] ON
INSERT INTO [dbo].[User] ([Id], [RoleID], [UserName], [Email], [Gender], [Password]) VALUES (1, 1, N'lazyadmin', N'adminramen@gmail.com', N'Male', N'admin123')
INSERT INTO [dbo].[User] ([Id], [RoleID], [UserName], [Email], [Gender], [Password]) VALUES (2, 2, N'staff', N'stafframen@gmail.com', N'Male', N'Staff123')
INSERT INTO [dbo].[User] ([Id], [RoleID], [UserName], [Email], [Gender], [Password]) VALUES (3, 3, N'Wahid', N'wahid@gmail.com', N'Male', N'wahid123')
INSERT INTO [dbo].[User] ([Id], [RoleID], [UserName], [Email], [Gender], [Password]) VALUES (4, 3, N'testing', N'tes@gmail.com', N'Female', N'tes')
SET IDENTITY_INSERT [dbo].[User] OFF

SET IDENTITY_INSERT [dbo].[Meat] ON
INSERT INTO [dbo].[Meat] ([Id], [Name]) VALUES (1, N'Chicken')
INSERT INTO [dbo].[Meat] ([Id], [Name]) VALUES (2, N'Pork')
INSERT INTO [dbo].[Meat] ([Id], [Name]) VALUES (3, N'Beef')
SET IDENTITY_INSERT [dbo].[Meat] OFF

SET IDENTITY_INSERT [dbo].[Ramen] ON
INSERT INTO [dbo].[Ramen] ([Id], [MeatId], [Name], [Broth], [Price]) VALUES (1, 1, N'Shoyu Ramen', N'Pork Bone broth with soy sauce', N'50000')
INSERT INTO [dbo].[Ramen] ([Id], [MeatId], [Name], [Broth], [Price]) VALUES (5, 2, N'Miso Ramen', N'Chicken Bone broth with miso paste', N'60000')
INSERT INTO [dbo].[Ramen] ([Id], [MeatId], [Name], [Broth], [Price]) VALUES (6, 2, N'Tonkotsu Ramen', N'Slow-cooked pork bone broth', N'55000')
INSERT INTO [dbo].[Ramen] ([Id], [MeatId], [Name], [Broth], [Price]) VALUES (7, 3, N'Curry Ramen', N' Broth with a curry spice blend', N'70000')
SET IDENTITY_INSERT [dbo].[Ramen] OFF
