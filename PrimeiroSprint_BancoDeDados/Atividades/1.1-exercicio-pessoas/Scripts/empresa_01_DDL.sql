Create Database Empresa;
Go

Use Empresa;
Go

Create Table Pessoa(
  idPessoa Smallint Primary Key Identity(1,1),
  nomePessoa Varchar(20) Not null
);
Go

Create Table Telefone(
  idTelefone Smallint Primary Key Identity(1,1),
  idPessoa Smallint Foreign Key references Pessoa(idPessoa),
  numeroTelefone Varchar(15) Not null
);
Go

Create Table Email(
  idEmail Int Primary Key Identity(1,1),
  idPessoa Smallint Foreign Key References Pessoa(idPessoa),
  endere�oEmail Varchar(256) Not Null
)
Go

Create Table CNH(
  idCNH Smallint Primary Key Identity(1,1),
  idPessoa Smallint Foreign Key References Pessoa(idPessoa),
  descri�ao Char(11) Not Null Unique
);
Go
