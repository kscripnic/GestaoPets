CREATE DATABASE Pets
GO

USE Pets
GO

CREATE TABLE Pets (
	CodigoPet INT IDENTITY,
	Nome VARCHAR(255),
	Idade INT,
	Especie VARCHAR(255)
)
GO

Insert into Pets (Nome,Idade,Especie) Values('Jack irmao', 2, 'dog')

select * from Pets