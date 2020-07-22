create database dbentfram;

use dbentfram;


create table table01(
	id int not null identity,
	name varchar(25) not null,
	description varchar(25) not null,
	primary key(id)
)

create table table02(
	id int not null identity,
	name varchar(25) not null,
	description varchar(25) not null,
	created datetime not null default getdate(),
	primary key(id)
)

create table users(
	id int not null identity,
	fullname varchar(100) not null,
	shortname varchar(30),
	email varchar(100) not null unique,
	password varchar(15) not null,
	status varchar(8)not null,
	createdate datetime not null default getdate(),
	lastaccess_date datetime,
	lastaccessIP varchar(30) not null,
	primary key(id),
)

create table employees(
	id int not null identity,
	num_employee varchar(10) not null unique,
	firstname varchar(30) not null,
	lastname varchar (70) not null,
	status varchar(8) not null,
	contract_date datetime not null,
	position varchar(50) not null,
	department varchar(50) not null,
	boss varchar(100) not null,
	users_id int not null,
	primary key(id),
	foreign key(users_id) references users(id)
)

create table general(
	id int not null identity,
	employee_id int not null,
	rfc varchar(13)not null,
	curp varchar(18) not null,
	nss varchar(30)not null,
	bank varchar(50) not null,
	interbank_account int not null,
	user_id int not null,
	primary key(id),
	foreign key (employee_id) references employees(id),
	foreign key (user_id) references users(id)
)

--alter table users alter column lastaccess_date datetime;
alter table users add unique (email);
alter table employees add unique (num_employee);
DBCC CHECKIDENT ('users', RESEED, 0)

SELECT *FROM users;
SELECT *FROM employees;
SELECT *FROM general;