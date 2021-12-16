---Cria um banco de dados chamado catalogo
Create Database Catalogo;
Go

Create Table Genero(
  idGenero Tinyint Primary Key Identity(1,1),
  nomeGenero Varchar(20)
)
Go

Alter Table Genero
Drop Column nomeGenero

Alter Table Genero
Add nomeGenero Varchar(20) Not Null

Create Table Filme(
  idFilme Smallint Primary Key Identity(1,1),
  idGenero Tinyint Foreign Key References Genero(idGenero),
  tituloFilme Varchar(50) Not Null
  );
  Go

  Use Catalogo;
  GO

  Create Table Genero(
  idGenero Tinyint Primary Key Identity(1,1),
  nomeGenero Varchar(20)
)
Go

Alter Table Genero
Drop Column nomeGenero

Alter Table Genero
Add nomeGenero Varchar(20) Not Null

Create Table Filme(
  idFilme Smallint Primary Key Identity(1,1),
  idGenero Tinyint Foreign Key References Genero(idGenero),
  tituloFilme Varchar(50) Not Null
  );
  Go