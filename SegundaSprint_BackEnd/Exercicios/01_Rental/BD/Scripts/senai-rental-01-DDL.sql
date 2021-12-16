CREATE DATABASE T_Rental;
GO

USE T_Rental;
Go

Create Table Empresa(
  idEmpresa Tinyint Primary Key Identity(1,1),
  funImpresa Varchar (50) Not null
);
Go

Create Table Marca(
  idMarca Smallint Primary Key Identity(1,1),
  nomeMarca Varchar(25) Not null
);
Go

Create Table Cliente(
  idCliente Int Primary Key Identity,
  nomeCliente Varchar(25) Not null,
  sobrenomeCliente VARCHAR(60) NOT NULL,
  cpfCliente Char(11) Not null UNIQUE,
  cnhCliente Char(10) Not null UNIQUE
);
Go

Create Table Modelo(
  idModelo Smallint Primary Key Identity(1,1),
  idMarca Smallint Foreign Key References Marca(idMarca),
  nomeModelo Varchar(50) Not null
);
Go

Create Table Veiculo(
  idVeiculo Int Primary Key Identity(1,1),
  idEmpresa Tinyint Foreign Key References Empresa(idEmpresa),
  idModelo Smallint Foreign Key References Modelo(idModelo),
  idMarca Smallint Foreign Key References Marca(idMarca),
  placa Varchar(8) Not null
);
Go

Create Table Aluguel(
  idAluguel Int Primary Key Identity(1,1),
  idCliente Int Foreign Key References Cliente(idCliente),
  idVeiculo Int Foreign Key References Veiculo(idVeiculo),
  dataDevolucao DATETIME NOT NULL,
  dataRetirada DATETIME NOT NULL
);
Go

UPDATE Aluguel SET idCliente = 1, idVeiculo = 2, dataDevolucao = '02/09/2021 14:30:00', dataRetirada = '01/10/2021 12:25:00' WHERE idAluguel = 2
GO