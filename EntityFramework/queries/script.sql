create database dbentfram;

use dbentfram;

create table table01(
	id int not null identity,
	name varchar(25) not null,
	description varchar(25) not null,
	primary key(id)
)