USE master
GO

-- Проверка наличия базы данных и её удаление, если она существует
IF EXISTS (SELECT 1 FROM sys.databases WHERE name = 'LibraryDB')
BEGIN
    ALTER DATABASE LibraryDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE LibraryDB;
END
GO

CREATE DATABASE LibraryDB;
GO

USE LibraryDB;
GO

CREATE TABLE Authors (
    AuthorId INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE Books (
    BookId INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(200) NOT NULL,
    AuthorId INT NOT NULL,
    FOREIGN KEY (AuthorId) REFERENCES Authors(AuthorId)
);
GO


INSERT INTO Authors (Name) VALUES ('Джордж Оруэлл');
INSERT INTO Authors (Name) VALUES ('Рей Брэдбери');
INSERT INTO Authors (Name) VALUES ('Уильям Шекспир');
INSERT INTO Authors (Name) VALUES ('Федор Достоевский');
INSERT INTO Authors (Name) VALUES ('Лев Толстой');
INSERT INTO Authors (Name) VALUES ('Эрнест Хемингуэй');
INSERT INTO Authors (Name) VALUES ('Джейн Остин');
INSERT INTO Authors (Name) VALUES ('Габриэль Гарсиа Маркес');
INSERT INTO Authors (Name) VALUES ('Александр Пушкин');
INSERT INTO Authors (Name) VALUES ('Джоан Роулинг');


INSERT INTO Books (Title, AuthorId) VALUES ('1984', 1);
INSERT INTO Books (Title, AuthorId) VALUES ('Скотный двор', 1);
INSERT INTO Books (Title, AuthorId) VALUES ('451° по Фаренгейту', 2);
INSERT INTO Books (Title, AuthorId) VALUES ('Скоро будет прошло', 2);
INSERT INTO Books (Title, AuthorId) VALUES ('Гамлет', 3);
INSERT INTO Books (Title, AuthorId) VALUES ('Ромео и Джульетта', 3);
INSERT INTO Books (Title, AuthorId) VALUES ('Преступление и наказание', 4);
INSERT INTO Books (Title, AuthorId) VALUES ('Братья Карамазовы', 4);
INSERT INTO Books (Title, AuthorId) VALUES ('Война и мир', 5);
INSERT INTO Books (Title, AuthorId) VALUES ('Анна Каренина', 5);
INSERT INTO Books (Title, AuthorId) VALUES ('По ком звонит колокол', 6);
INSERT INTO Books (Title, AuthorId) VALUES ('Фестиваль', 6);
INSERT INTO Books (Title, AuthorId) VALUES ('Гордость и предубеждение', 7);
INSERT INTO Books (Title, AuthorId) VALUES ('Разум и чувства', 7);
INSERT INTO Books (Title, AuthorId) VALUES ('Сто лет одиночества', 8);
INSERT INTO Books (Title, AuthorId) VALUES ('Осенний нарцисс', 8);
INSERT INTO Books (Title, AuthorId) VALUES ('Евгений Онегин', 9);
INSERT INTO Books (Title, AuthorId) VALUES ('Капитанская дочка', 9);
INSERT INTO Books (Title, AuthorId) VALUES ('Гарри Поттер и философский камень', 10);
INSERT INTO Books (Title, AuthorId) VALUES ('Гарри Поттер и Тайная комната', 10);

