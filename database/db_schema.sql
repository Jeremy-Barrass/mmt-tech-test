CREATE DATABASE IF NOT EXISTS MmtTechTest;	
USE MmtTechTest;

CREATE TABLE IF NOT EXISTS Categories(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  name VARCHAR(40)
);

CREATE TABLE IF NOT EXISTS Products(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  name VARCHAR(40),
  sku BIGINT,
  description VARCHAR(150),
  price DECIMAL(13, 2),
  category TINYINT
);

INSERT INTO Categories (name)
VALUES
  ('Home'),
  ('Garden'),
  ('Electronics'),
  ('Fitness'),
  ('Toys');

INSERT INTO Products (name, sku, description, price, category)
VALUES
  ('Chair', 10001, 'A seat for one', 50, 1),
  ('Sofa', 10002, 'A seat for more than one', 150, 1),
  ('Rake', 20001, 'A tool for tidying your flower beds', 75, 2),
  ('Spade', 20002, 'A tool for digging', 85, 2),
  ('CD Player', 30001, 'Listen to CDs', 20, 3),
  ('Android Tablet', 30002, 'Conveniently access Google services', 200, 3),
  ('Weights', 40001, 'Get hench', 90, 4),
  ('Treadmill', 40002, 'Get fit', 350, 4),
  ('Barbie Doll', 50001, 'Teach your children unhealthy beauty standards', 86, 5),
  ('Action Man', 50002, 'Teach your children about hyper-masculinity', 65, 5);