create database PersonasDb
GO
Use PersonasDb
GO

Create Table Personas
(
	Id int primary key identity,
	Nombre varchar(30),
	Telefono varchar(12),
	Cedula varchar(13),
	Direccion varchar(max)
);