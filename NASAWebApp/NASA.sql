-- database setup steps
-- open your Sql Server Management Studio.
-- execute this script on the target sql server to set up the empty database.
-- then configure the connection string ConStr in appsettings.json
-- "ConStr": "Data Source=(local);Initial Catalog=NASA;Integrated Security=True;TrustServerCertificate=True"
-- If you use a sub-instance of sql like sql express, then your connectionstring will change to
-- "ConStr": "Data Source=(local)\\sqlexpress;Initial Catalog=NASA;Integrated Security=True;TrustServerCertificate=True"
-- For SQL Server authentication, yiu should additionally add the user id and the password to the conecction string
USE master
GO
CREATE DATABASE NASA
GO
Use NASA
GO
CREATE TABLE Users(
	UserId int primary key IDENTITY(1,1) NOT NULL,
	Email nvarchar(255) NOT NULL,
	PasswordHash nvarchar(255) NOT NULL,
	FullName nvarchar(100) NULL,
	CreatedAt datetime NULL,
);

 
CREATE TABLE SearchHistories
(
	SearchId int IDENTITY(1,1) NOT NULL,
	UserId int foreign key references Users(UserId),
	SearchTerm nvarchar(255) NOT NULL,
	SearchDate datetime NULL,
);




