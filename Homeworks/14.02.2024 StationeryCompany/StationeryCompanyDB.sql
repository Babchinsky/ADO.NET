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
GO

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





GO
CREATE VIEW RecentSaleView AS
SELECT TOP 1 *
FROM Sales
ORDER BY DateOfSale DESC;

GO
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
GO












GO
CREATE PROCEDURE GetProductsByType
    @ProductType NVARCHAR(50)
AS
BEGIN
    SELECT * 
    FROM ProductInfoView 
    WHERE ProductType = @ProductType;
END;
GO

CREATE PROCEDURE GetProductsBySalesManager
    @SalesManager NVARCHAR(50)
AS
BEGIN
    SELECT * 
    FROM ProductInfoView 
    WHERE SalesManager = @SalesManager;
END;
GO

CREATE PROCEDURE GetProductsByBuyingCompany
    @BuyingCompany NVARCHAR(50)
AS
BEGIN
    SELECT * 
    FROM ProductInfoView 
    WHERE BuyingCompany = @BuyingCompany;
END;
GO




CREATE PROCEDURE UpdateBuyingCompany
    @CompanyID INT,
    @NewCompanyName NVARCHAR(50)
AS
BEGIN
    UPDATE BuyingCompanies
    SET CompanyName = @NewCompanyName
    WHERE CompanyID = @CompanyID;
END;
GO


CREATE PROCEDURE UpdateSalesManager
    @ManagerID INT,
    @NewManagerName NVARCHAR(50)
AS
BEGIN
    UPDATE SalesManagers
    SET ManagerName = @NewManagerName
    WHERE ManagerID = @ManagerID;
END;
GO

CREATE PROCEDURE UpdateProductType
    @ProductTypeID INT,
    @NewProductTypeName NVARCHAR(50)
AS
BEGIN
    UPDATE ProductTypes
    SET TypeName = @NewProductTypeName
    WHERE ProductTypeID = @ProductTypeID;
END;
GO





CREATE PROCEDURE LoadProductsByMaxQuantity
AS
BEGIN
    SELECT * 
    FROM ProductInfoView 
    WHERE Quantity = (SELECT MAX(Quantity) FROM ProductInfoView);
END;

GO
CREATE PROCEDURE LoadProductsByMinQuantity
AS
BEGIN
    SELECT * 
    FROM ProductInfoView 
    WHERE Quantity = (SELECT MIN(Quantity) FROM ProductInfoView);
END;

GO
CREATE PROCEDURE LoadProductsByMinCostPrice
AS
BEGIN
    SELECT * 
    FROM ProductInfoView 
    WHERE CostPrice = (SELECT MIN(CostPrice) FROM ProductInfoView);
END;

GO
CREATE PROCEDURE LoadProductsByMaxCostPrice
AS
BEGIN
    SELECT * 
    FROM ProductInfoView 
    WHERE CostPrice = (SELECT MAX(CostPrice) FROM ProductInfoView);
END;

GO
CREATE PROCEDURE LoadRecentSale
AS
BEGIN
    SELECT * 
    FROM RecentSaleView;
END;

GO
CREATE PROCEDURE LoadAverageQuantityByType
AS
BEGIN
    SELECT * 
    FROM AverageQuantityByTypeView;
END;

GO
CREATE PROCEDURE LoadAllProductTypes
AS
BEGIN
    SELECT * FROM ProductTypes;
END;

GO
CREATE PROCEDURE LoadAllSalesManagers
AS
BEGIN
    SELECT * FROM SalesManagers;
END;

GO
CREATE PROCEDURE LoadProductInfo
AS
BEGIN
    SELECT * FROM ProductInfoView;
END;

GO
CREATE PROCEDURE LoadAllBuyingCompanies
AS
BEGIN
    SELECT * FROM BuyingCompanies;
END;
GO



CREATE PROCEDURE UpdateBuyingCompanyByName
    @Name NVARCHAR(50),
    @NewName NVARCHAR(50)
AS
BEGIN
    UPDATE BuyingCompanies
    SET CompanyName = @NewName
    WHERE CompanyName = @Name;
END;
GO

CREATE PROCEDURE UpdateSalesManagerByName
    @Name NVARCHAR(50),
    @NewName NVARCHAR(50)
AS
BEGIN
    UPDATE SalesManagers
    SET ManagerName = @NewName
    WHERE ManagerName = @Name;
END;
GO


CREATE PROCEDURE UpdateProductTypeByName
    @Name NVARCHAR(50),
    @NewName NVARCHAR(50)
AS
BEGIN
    UPDATE ProductTypes
    SET TypeName = @NewName
    WHERE TypeName = @Name;
END;
GO


CREATE PROCEDURE AddCompany
    @Name NVARCHAR(50)
AS
BEGIN
    INSERT INTO BuyingCompanies (CompanyName)
    VALUES (@Name);
END;
GO


CREATE PROCEDURE AddProductType
    @Name NVARCHAR(50)
AS
BEGIN
    INSERT INTO ProductTypes (TypeName)
    VALUES (@Name);
END;
GO


CREATE PROCEDURE AddSalesManager
    @Name NVARCHAR(50)
AS
BEGIN
    INSERT INTO SalesManagers (ManagerName)
    VALUES (@Name);
END;
GO






CREATE PROCEDURE DeleteSalesManagerAndSalesByName
    @Name NVARCHAR(50)
AS
BEGIN
    BEGIN TRANSACTION;

    -- Удаление связанных продаж
    DELETE FROM Sales
    WHERE ManagerWhoMadeTheSaleID IN (SELECT ManagerID FROM SalesManagers WHERE ManagerName = @Name);

    -- Удаление менеджера
    DELETE FROM SalesManagers
    WHERE ManagerName = @Name;

    COMMIT;
END;
GO


CREATE PROCEDURE DeleteProductTypeAndProductsByName
    @Name NVARCHAR(50)
AS
BEGIN
    BEGIN TRANSACTION;

    -- Удаление связанных продуктов
    DELETE FROM Products
    WHERE ProductTypeID IN (SELECT ProductTypeID FROM ProductTypes WHERE TypeName = @Name);

    -- Удаление типа продукта
    DELETE FROM ProductTypes
    WHERE TypeName = @Name;

    COMMIT;
END;
GO


CREATE PROCEDURE DeleteCompanyAndSalesByName
    @Name NVARCHAR(50)
AS
BEGIN
    BEGIN TRANSACTION;

    -- Удаление связанных продаж
    DELETE FROM Sales
    WHERE BuyingCompanyID IN (SELECT CompanyID FROM BuyingCompanies WHERE CompanyName = @Name);

    -- Удаление компании
    DELETE FROM BuyingCompanies
    WHERE CompanyName = @Name;

    COMMIT;
END;
GO
