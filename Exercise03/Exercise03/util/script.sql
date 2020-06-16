create table products(
	id int not null identity,
	name varchar(20) not null,
	description varchar(50) not null,
	short_name nvarchar(10) not null,
	price decimal not null,
	stack int not null
	primary key(id)
)

INSERT INTO products (name, description, short_name, price, stack)
VALUES ('Chetos', 'Chetos clasicos con queso', 'CHETOS', 10.00, 20);

SELECT id, name, description, short_name, price, stack FROM products;