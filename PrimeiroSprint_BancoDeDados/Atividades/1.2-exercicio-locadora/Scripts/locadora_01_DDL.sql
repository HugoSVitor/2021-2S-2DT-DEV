Create Database Locadora;
Go

Use Locadora;
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
  nomeCliente Varchar(50) Not null,
  cpfCliente Char(11) Not null
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
);
Go

ALTER TABLE ALUGUEL
ADD dataDevolucao SMALLDATETIME
ALTER TABLE ALUGUEL
ADD dataRetirada SMALLDATETIME NOT NULL