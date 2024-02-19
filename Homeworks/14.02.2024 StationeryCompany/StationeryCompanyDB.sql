USE master;

IF DB_ID('StationeryCompanyDB') IS NULL
BEGIN
    CREATE DATABASE StationeryCompanyDB;
END
ELSE
BEGIN
    DROP DATABASE StationeryCompanyDB;
	CREATE DATABASE StationeryCompanyDB;
END
GO

USE StationeryCompanyDB;

CREATE TABLE ProductTypes (
    ProductTypeID INT IDENTITY(1,1) PRIMARY KEY,
    TypeName NVARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(50) NOT NULL UNIQUE,
    ProductTypeID INT FOREIGN KEY REFERENCES ProductTypes(ProductTypeID),
    Quantity INT NOT NULL,
    CostPrice DECIMAL(10,2) NOT NULL
);

CREATE TABLE SalesManagers (
    ManagerID INT IDENTITY(1,1) PRIMARY KEY,
    ManagerName NVARCHAR(50) NOT NULL
);

CREATE TABLE BuyingCompanies (
    CompanyID INT IDENTITY(1,1) PRIMARY KEY,
    CompanyName NVARCHAR(50) NOT NULL
);

CREATE TABLE Sales (
    SaleID INT IDENTITY(1,1) PRIMARY KEY,
    ProductID INT FOREIGN KEY REFERENCES Products(ProductID),
    NumberOfSold INT NOT NULL,
    DateOfSale DATE NOT NULL,
    BuyingCompanyID INT FOREIGN KEY REFERENCES BuyingCompanies(CompanyID),
    ManagerWhoMadeTheSaleID INT FOREIGN KEY REFERENCES SalesManagers(ManagerID),
    UnitPrice DECIMAL(10,2),
    QuantitySold INT
);



-- Заполнение таблицы ProductTypes
INSERT INTO ProductTypes (TypeName) VALUES 
('Ручки'),
('Блокноты'),
('Скрепки'),
('Карандаши'),
('Клей'),
('Бумага');

-- Заполнение таблицы Products
INSERT INTO Products (ProductName, ProductTypeID, Quantity, CostPrice) VALUES
('Синие ручки', 1, 100, 0.5),
('Большой блокнот', 2, 50, 2.5),
('Металлические скрепки', 3, 200, 0.1),
('Черные карандаши', 4, 150, 1.0),
('Клей ПВА', 5, 80, 1.2),
('Белая бумага', 6, 120, 0.8);

-- Заполнение таблицы SalesManagers
INSERT INTO SalesManagers (ManagerName) VALUES 
('Иван Иванов'),
('Мария Сидорова'),
('Петр Петров'),
('Анна Аннова'),
('Александр Александров');

-- Заполнение таблицы BuyingCompanies
INSERT INTO BuyingCompanies (CompanyName) VALUES 
('ООО "КанцТовары"'),
('ИП "Покупатель"'),
('Фирма "Бумажный мир"'),
('Канцелярская компания "Радуга"'),
('ООО "ТехноБум"');

-- Заполнение таблицы Sales
INSERT INTO Sales (ProductID, NumberOfSold, DateOfSale, BuyingCompanyID, ManagerWhoMadeTheSaleID, UnitPrice, QuantitySold) VALUES
(1, 50, '2024-02-17', 1, 1, 1.0, 50),
(2, 20, '2024-02-18', 2, 2, 3.0, 20),
(3, 100, '2024-02-19', 3, 3, 0.2, 100),
(4, 30, '2024-02-20', 4, 4, 1.5, 30),
(5, 15, '2024-02-21', 5, 5, 2.0, 15),
(6, 80, '2024-02-22', 1, 1, 0.9, 80);


CREATE VIEW ProductInfoView AS
SELECT
    P.ProductID,
    P.ProductName,
    PT.TypeName AS ProductType,
    P.Quantity,
    P.CostPrice,
    S.NumberOfSold,
    S.DateOfSale,
    BC.CompanyName AS BuyingCompany,
    SM.ManagerName AS SalesManager,
    S.UnitPrice,
    S.QuantitySold
FROM
    Products P
    JOIN ProductTypes PT ON P.ProductTypeID = PT.ProductTypeID
    JOIN Sales S ON P.ProductID = S.ProductID
    JOIN BuyingCompanies BC ON S.BuyingCompanyID = BC.CompanyID
    JOIN SalesManagers SM ON S.ManagerWhoMadeTheSaleID = SM.ManagerID;


CREATE VIEW RecentSaleView AS
SELECT TOP 1 *
FROM Sales
ORDER BY DateOfSale DESC;


CREATE VIEW AverageQuantityByTypeView AS
SELECT
    PT.ProductTypeID,
    PT.TypeName,
    AVG(P.Quantity) AS AverageQuantity
FROM
    Products P
    JOIN ProductTypes PT ON P.ProductTypeID = PT.ProductTypeID
GROUP BY
    PT.ProductTypeID,
    PT.TypeName;