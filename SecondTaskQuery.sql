CREATE DATABASE ProductsDb;

USE ProductsDb;

CREATE TABLE Product (
	id int IDENTITY PRIMARY KEY,
	name NVARCHAR(64) not null
);

CREATE TABLE Category (
	id int IDENTITY PRIMARY KEY,
	name NVARCHAR(64) not null
);

CREATE TABLE Product_Category(
	product_id int REFERENCES Product (id),
	category_id int REFERENCES Category (id),
);

INSERT INTO Category (name) VALUES
	('Обувь'),
	('Бытовая химия'),
	('Фрукты');

INSERT INTO Product (name) VALUES
	('Адидас'),
	('Найк'),
	('Мыло'),
	('Шампунь'),
	('Яблоки'),
	('Бананы'),
	('Курица'),
	('Сникерс');

INSERT INTO Product_Category (product_id,category_id) VALUES
	(1,1),
	(2,1),
	(3,2),
	(4,2),
	(5,3),
	(6,3);

SELECT p.name, c.name FROM Product p 
LEFT JOIN Product_Category pc ON pc.product_id = p.id 
LEFT JOIN Category c ON pc.category_id = c.id 