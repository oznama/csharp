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