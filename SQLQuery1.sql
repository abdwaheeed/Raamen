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

CREATE TABLE Detail(
	HeaderId INT NOT NULL
		FOREIGN KEY REFERENCES Header(Id)
		ON UPDATE CASCADE ON DELETE CASCADE,
	RamenId INT NOT NULL
		FOREIGN KEY REFERENCES Ramen(Id)
		ON UPDATE CASCADE ON DELETE CASCADE,
	Quantity INT NOT NULL
)

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
