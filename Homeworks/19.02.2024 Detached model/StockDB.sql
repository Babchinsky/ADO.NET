USE master;

IF DB_ID('StockDB') IS NULL
BEGIN
    CREATE DATABASE StockDB;
END
ELSE
BEGIN
    DROP DATABASE StockDB;
	CREATE DATABASE StockDB;
END
GO

USE StockDB;

CREATE TABLE ProductTypes(
	ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Name NVARCHAR(50) NOT NULL,
)

CREATE TABLE Suppliers(
	ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Name NVARCHAR(50) NOT NULL,
)

CREATE TABLE Products(
	ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	TypeID INT REFERENCES ProductTypes(ID) on delete cascade on update cascade,
	SupplierID INT REFERENCES Suppliers(ID) on delete cascade on update cascade,
	Quantity INT NOT NULL,
	Cost DECIMAL NOT NULL,
	SupplyDate DATE NOT NULL,
)


-- Заполнение таблицы ProductType
INSERT INTO ProductTypes (Name) VALUES
    ('Фрукты'),
    ('Овощи'),
    ('Мясо'),
    ('Молочные продукты'),
    ('Хлебобулочные изделия'),
    ('Напитки'),
    ('Кондитерские изделия'),
    ('Морепродукты'),
    ('Замороженные продукты'),
    ('Крупы');

-- Заполнение таблицы Supplier
INSERT INTO Suppliers (Name) VALUES
    ('Поставщик1'),
    ('Поставщик2'),
    ('Поставщик3'),
    ('Поставщик4'),
    ('Поставщик5'),
    ('Поставщик6'),
    ('Поставщик7'),
    ('Поставщик8'),
    ('Поставщик9'),
    ('Поставщик10');

-- Заполнение таблицы Stock
INSERT INTO Products (Name, TypeID, SupplierID, Quantity, Cost, SupplyDate) VALUES
    ('Яблоки', 1, 1, 100, 200.50, '2022-01-15'),
    ('Морковь', 2, 2, 50, 150.75, '2022-01-20'),
    ('Говядина', 3, 3, 30, 450.00, '2022-02-05'),
    ('Молоко', 4, 4, 200, 120.25, '2022-02-10'),
    ('Хлеб', 5, 5, 150, 50.50, '2022-02-20'),
    ('Вода', 6, 6, 500, 30.00, '2022-03-01'),
    ('Пирожное', 7, 7, 50, 180.00, '2022-03-10'),
    ('Креветки', 8, 8, 80, 700.75, '2022-03-15'),
    ('Замороженные овощи', 9, 9, 120, 90.50, '2022-04-01'),
    ('Гречка', 10, 10, 80, 70.25, '2022-04-10'),
    ('Ягоды', 1, 2, 60, 250.00, '2022-04-15'),
    ('Томаты', 2, 3, 40, 180.75, '2022-05-01'),
    ('Свинина', 3, 4, 25, 380.00, '2022-05-10'),
    ('Сыр', 4, 5, 120, 180.25, '2022-05-15'),
    ('Багет', 5, 6, 100, 40.50, '2022-06-01'),
    ('Сок', 6, 7, 300, 25.00, '2022-06-10'),
    ('Торт', 7, 8, 30, 250.00, '2022-06-15'),
    ('Лосось', 8, 9, 50, 600.75, '2022-07-01'),
    ('Мороженое', 9, 10, 70, 80.50, '2022-07-10'),
    ('Рис', 10, 1, 90, 60.25, '2022-07-15');



	SELECT Products.ID, Products.Name AS ProductName, ProductTypes.Name AS TypeName, Suppliers.Name AS SupplierName, Products.Quantity, Products.Cost, Products.SupplyDate
	FROM Products
	JOIN ProductTypes ON Products.TypeID = ProductTypes.ID
	JOIN Suppliers ON Products.SupplierID = Suppliers.ID;

	SELECT DISTINCT ID, Name From Suppliers;	
	
	SELECT DISTINCT ID, Name From ProductTypes;