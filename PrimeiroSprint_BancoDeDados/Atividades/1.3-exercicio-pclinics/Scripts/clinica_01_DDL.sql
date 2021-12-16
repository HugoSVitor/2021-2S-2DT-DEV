Create Database Clinica;
Go

Use Clinica;
Go

Create Table Clinica(
  idClinica Tinyint Primary Key Identity(1,1),
  ende�o Varchar(100) Not null,
  CNPJ CHAR(14) NOT NULL,
  nomeClinica VARCHAR(25) NOT NULL
);
Go
DROP TABLE Clinica

DROP TABLE Veterinario

DROP TABLE Atendimento

Create Table Dono(
  idDono Int Primary Key Identity(1,1),
  cpfDono Char(11) Not null,
  nomeDono Varchar(20) Not null Unique
);
Go

Create Table TipoPet(
  idTipoPet Int Primary Key Identity(1,1),
  nomeTipoPet Varchar(30) Not null
);
Go

Create Table Ra�aPet(
  idRa�aPet Int Primary Key Identity(1,1),
  idTipoPet Int Foreign Key References TipoPet(idTipoPet),
  nomeRa�a Varchar(20) Not null
);
Go

Create Table Pet(
  idPet Int Primary Key identity(1,1),
  idDono Int Foreign Key References Dono(idDono),
  idRa�aPet Int Foreign Key References Ra�aPet(idRa�aPet),
  dataNascimento Varchar(8) Not null,
  nomePet Varchar(20) Not null,
);
Go

Create Table Veterinario(
  idVeterinario Smallint Primary Key identity(1,1),
  idClinica Tinyint Foreign Key References Clinica(idClinica),
  nomeVeterinario Varchar(20) Not null,
);
Go

Create Table Atendimento(
  idAtendimento Int Primary Key Identity(1,1),
  idVeterinario Smallint Foreign Key References Veterinario(idVeterinario),
  idPet Int Foreign Key References Pet(idPet)
);
Go