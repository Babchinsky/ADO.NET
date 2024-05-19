USE master;
GO


DECLARE @kill varchar(8000) = '';

SELECT @kill = @kill + 'kill ' + CONVERT(varchar(5), spid) + ';'
FROM master..sysprocesses
WHERE dbid = db_id('Newsletter');

EXEC(@kill);


IF db_id('Newsletter') IS NOT NULL
    DROP DATABASE [Newsletter];
GO

create database [Newsletter]
go
use [Newsletter]
go


create table Countries(
	[Id] int primary key identity(1,1),
	[Name] nvarchar(50) check([Name]<>'') unique,
)
go

create table City(
	[Id] int primary key identity(1,1),
	[Name] nvarchar(150) check([Name]<>''),
	[CountrieId] int foreign key references Countries([Id])
)
go

create table ProductSection(
	[Id] int primary key identity(1,1),
	[Name] nvarchar(250) check([Name]<>'')
)
go

create table Promotion(
	[Id] int primary key identity(1,1),
	[CountrieId] int foreign key references Countries([Id]),
	[ProductSectionId] int foreign key references ProductSection([Id]),
	[Discount] float check([Discount] >= 0 and [Discount] <= 100) default(0),
	[ExpirationDate] Date
)
go

create table Buyer(
	[Id] int primary key identity(1,1),
	[FullName] nvarchar(100) check([FullName]<>''),
	[Gender] char check ([Gender]<>''),
	[Email] nvarchar(100) check([Email]<>''),
	[CityId] int foreign key references City([Id]),
)
go

create table ShoppingCart(
    [Id] int primary key identity(1,1),
    [BuyerId] int foreign key references Buyer([Id]),
    [ProductSectionId] int foreign key references ProductSection([Id]),
    [Quantity] int check([Quantity] > 0)
)
go

create table Product(
 [Id] int primary key identity(1,1),
 [Name] nvarchar(50),
 [ProductSectionId] int foreign key references ProductSection([Id]),
)
go





INSERT INTO Countries ([Name])
VALUES ('USA'), ('UK'), ('Germany');


INSERT INTO City ([Name], [CountrieId])
VALUES ('New York', 1), ('London', 2), ('Berlin', 3);


INSERT INTO ProductSection ([Name])
VALUES ('Electronics'), ('Clothing'), ('Books');


INSERT INTO Buyer ([FullName], [Gender], [Email], [CityId])
VALUES ('John Doe', 'M', 'john.doe@example.com', 1),
       ('Jane Smith', 'F', 'jane.smith@example.com', 2),
       ('Michael Johnson', 'M', 'michael.johnson@example.com', 3);



INSERT INTO Promotion ([CountrieId], [ProductSectionId], [Discount], [ExpirationDate])
VALUES 
    (1, 1, 10, '2024-02-16'),
    (2, 2, 15, '2024-04-15'),
    (3, 3, 20, '2024-06-01');

INSERT INTO ShoppingCart ([BuyerId], [ProductSectionId], [Quantity])
VALUES 
    (1, 1, 2),
    (2, 2, 3),
    (3, 3, 1);


INSERT INTO Product ([Name], [ProductSectionId])
VALUES ('Laptop', 1),
       ('T-Shirt', 2),
       ('Novel', 3);