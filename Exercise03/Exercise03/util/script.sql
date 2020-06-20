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

-- FindAll
SELECT id, name, description, short_name, price, stack FROM products;

--FindById
SELECT id,name,description,short_name,price,stack FROM products WHERE id=@id;

--Delete
DELETE FROM products WHERE id=@id;

--Save
INSERT INTO products (name, description, short_name, price, stack) VALUES (@name, @description,@shortName,@price,@stack);

--Update
UPDATE products SET name=@name,description=@description,short_name=@shortName,price=@price,stack=@stack WHERE id=@id;