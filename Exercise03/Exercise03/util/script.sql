create table products(
	id int not null identity,
	name varchar(20) not null,
	description varchar(50) not null,
	short_name nvarchar(10) not null,
	price decimal not null,
	stack int not null
	primary key(id)
)

create table users(
	id int not null identity,
	username varchar(20) not null,
	pswd varchar(20) not null,
	fullname varchar(100) not null,
	primary key(id)
)

create table providers(
	id int not null identity,
	name varchar(50) not null,
	description varchar(50) not null,
	created_date datetime not null default getdate(),
	user_id int not null,
	primary key(id),
	foreign key (user_id) references users(id)
)

create table purchases(
	id int not null identity,
	purchase_date datetime not null default getdate(),
	user_id int not null,
	provider_id int not null,
	purchase_total decimal not null,
	primary key(id),
	foreign key (user_id) references users(id),
	foreign key (provider_id) references providers(id)
)

create table purchases_item(
	id int not null identity,
	product_id int not null,
	purchase_id int not null,
	quantity int not null,
	primary key(id),
	foreign key (product_id) references products(id),
	foreign key (purchase_id) references purchases(id)
)

create table clients(
	id int not null identity,
	name varchar(100) not null,
	address varchar(100),
	phone varchar(10),
	user_id int not null,
	created_date datetime not null default getdate(),
	primary key(id),
	foreign key (user_id) references users(id)
)

create table sales(
	id int not null identity,
	sale_date datetime not null default getdate(),
	user_id int not null,
	sale_total decimal not null,
	client_id int,
	trusted bit default 0,
	primary key(id),
	foreign key (user_id) references users(id),
	foreign key(client_id) references clients(id)
)

create table sales_item(
	id int not null identity,
	product_id int not null,
	sale_id int not null,
	quantity int not null,
	primary key(id),
	foreign key (product_id) references products(id),
	foreign key (sale_id) references sales(id)
)


INSERT INTO products (name, description, short_name, price, stack)
VALUES ('Chetos', 'Chetos clasicos con queso', 'CHETOS', 10.00, 20);

-- FindAll Products
SELECT id, name, description, short_name, price, stack FROM products;

--FindById Products
SELECT id,name,description,short_name,price,stack FROM products WHERE id=@id;

--Delete Products
DELETE FROM products WHERE id=@id;

--Save Products
INSERT INTO products (name, description, short_name, price, stack) VALUES (@name, @description,@shortName,@price,@stack);

--Update Products
UPDATE products SET name=@name,description=@description,short_name=@shortName,price=@price,stack=@stack WHERE id=@id;

--UpdateStack Products
UPDATE products SET stack = stack + @quantity WHERE id =  @id;

--Save Users
INSERT INTO users (username,pswd,fullname) VALUES (@userName,@pswd,@fullName);

--UPDATE Users
UPDATE users SET username=@userName,pswd=@pswd,fullname=@fullName WHERE id=@id;

--DELETE Users
DELETE FROM users WHERE id=@id;

--FindAll Users
SELECT id,username,pswd,fullname FROM users;

--FindById Userd
SELECT id,username,pswd,fullname FROM users WHERE id=@id;

--DELETE Clients
DELETE FROM clients WHERE id=@id;

--FindAll Clients
SELECT id,name,address,phone,user_id,created_date FROM clients;

--FindById Clients
SELECT id,name,address,phone,user_id,created_date FROM clients WHERE id=@id;

--Save Clients
INSERT INTO clients (name,address,phone,user_id,created_date) VALUES(@name,@address,@phone,@userId,@createdDate);

--Update Clients
UPDATE clients SET name=@name,address=@address,phone=@phone,user_id=@userId,created_date=@createdDate WHERE id=@id;

-- ONM: Querys de ejercicio de relacion 1:M
SELECT * FROM users; -- Todos los usuarios

SELECT id, name, address, phone, created_date FROM clients WHERE user_id = 2; -- Clientes por usuario

-- Edra
INSERT INTO clients (name, address, phone, user_id) VALUES ('Gudelia Gonzalez', 'Su casa', '5565656565', 1);
INSERT INTO clients (name, address, phone, user_id) VALUES ('La Guera', 'Enfrente de la casa', '5564643790', 1);
INSERT INTO clients (name, address, phone, user_id) VALUES ('Reina', 'Tambien enfrente de la casa pero al lado de la guera', '2888828282', 1);
-- Carlos
INSERT INTO clients (name, address, phone, user_id) VALUES ('Fernando', 'A un lado de la casa', '2888989898', 2);
INSERT INTO clients (name, address, phone, user_id) VALUES ('Silvia', 'Atras de la casa', '2888738274', 2);

-- Version 1 de query para ver clientes de un usuario
SELECT users.fullname, clients.name, clients.address, clients.phone, clients.created_date
FROM users, clients
WHERE clients.user_id = users.id
AND users.id = 1
-- Version 2 de query para ver clientes de un usuario
SELECT u.fullname, c.name, c.address, c.phone, c.created_date
FROM users u, clients c
WHERE c.user_id = u.id
AND u.id = 1
-- Version 3 de query para ver clientes de un usuario (Buena practica utilizar JOIN)
SELECT u.fullname, c.name, c.address, c.phone, c.created_date
FROM users u
INNER JOIN clients c ON c.user_id = u.id
WHERE u.id = 1

--Delete Providers
DELETE FROM providers WHERE id=@id;
--FindAll Providers
SELECT id,name,description,created_date,user_id FROM providers
--FindById Providers
SELECT id,name,description,created_date,user_id FROM providers WHERE id=@id;
--Save Providers
INSERT INTO providers (name,description,user_id) VALUES(@name,@description,@userId);
--Update Providers
UPDATE  providers SET name=@name,description=@description,created_date=@createdDate, user_id=@userId Where id=@id;
--Delete Sales
DELETE FROM sales WHERE id =@id;
--FindAll Sales
SELECT id, sale_date,user_id,sale_total,client_id,trusted FROM sales;
--FindById Sales
SELECT id, sale_date,user_id,sale_total,client_id,trusted FROM sales WHERE id=@id;
--FindByUserId Sales
SELECT id, sale_date,user_id,sale_total,client_id,trusted FROM sales WHERE user_id=@userId;
--FindByClientId Sales
SELECT id, sale_date,user_id,sale_total,client_id,trusted FROM sales WHERE client_id=@clientId;
--Save Sales 
INSERT INTO sales (user_id,sale_total,client_id,trusted)VALUES (@userId,@saleTotal,@clientId,@trusted);
--Update Sales
UPDATE sales SET user_id=@userId,sale_total=@saleTotal,client_id=@clientId,trusted=@trusted WHERE id=@id;
--Delete Purchases
DELETE FROM purchases WHERE id =@id;
--FindAll Purchases
SELECT id,purchase_date,user_id,provider_id,purchase_total FROM purchases;
--FindById Purchases
SELECT id,purchase_date,user_id,provider_id,purchase_total FROM purchases WHERE id=@id;
--FindByProviderId Purchases
SELECT id,purchase_date,user_id,provider_id,purchase_total FROM purchases WHERE provider_id=@providerId;
--FindByUserId Purchases
SELECT id,purchase_date,user_id,provider_id,purchase_total FROM purchases WHERE user_id=@userId;
--Save Purchases
INSERT INTO purchases (user_id,provider_id,purchase_total)VALUES (@userId,@providerId@purchaseTotal);
--Update Purchases
UPDATE purchases SET purchase_date=@purchaseDate,user_id=@userId, provider_id=@providerId,purchase_total=@purchaseTotal WHERE id=@id;
--Delete sales_item
DELETE FROM sales_item WHERE sale_id =@saleId;
--FindAll seles_item
SELECT id,product_id,sale_id,quantiy FROM sales_item;
--FindById seles_item
SELECT id,product_id,sale_id,quantiy FROM sales_item WHERE id=@id;
--FindByProductId seles_item
SELECT id,product_id,sale_id,quantiy FROM sales_item WHERE product_id=@productId;
--FindBySaleId seles_item
SELECT id,product_id,sale_id,quantiy FROM sales_item WHERE sale_id=@saleId;
--Save sales_item
INSERT INTO sales_item (product_id,sale_id, quantity)VALUES (@productId,@saleId,@quantity);

--Delete purchases_item
DELETE FROM purchases_item WHERE purchase_id=@purchaseId;
--FindAll purchases_item
SELECT id,product_id,purchase_id, quantity FROM purchases_item;
--FindById purchases_item
SELECT id, product_id, purchase_id, quantity FROM purchases_item WHERE id=@id
--FindByProductId purchases_item
SELECT id, product_id, purchase_id, quantity FROM purchases_item WHERE product_id=@productId;
--FindByPurchaseId purchases_item
SELECT id, product_id, purchase_id, quantity FROM purchases_item WHERE purchase_id=@purchaseId;
--Save purchases_item
INSERT INTO purchases_item (product_id,purchase_id, quantity)VALUES (@productId,@purchaseId,@quantity);


-- Borra todos los registros
DELETE FROM sales;
-- Resetea la secuencia del ID a 0
DBCC CHECKIDENT (sales, RESEED, 0);