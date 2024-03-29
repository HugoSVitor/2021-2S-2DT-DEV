CREATE DATABASE HROADS_TARDE;
GO

USE HROADS_TARDE;
GO

CREATE TABLE CLASSE(
	idClasse SMALLINT PRIMARY KEY IDENTITY(1,1),
	nomeClasse VARCHAR(20) NOT NULL,
	capMaxVida VARCHAR(10),
	capMaxMana VARCHAR(10)

);
GO

CREATE TABLE PERSONAGEM (
	idPersonagem SMALLINT PRIMARY KEY IDENTITY(1,1),
	idClasse SMALLINT FOREIGN KEY REFERENCES CLASSE(idClasse),
	nomePersonagem VARCHAR(40) NOT NULL,
	dataAtualizacao VARCHAR (15) NOT NULL,
	dataCriacao DATE NOT NULL

);
GO


CREATE TABLE TIPO_HABILIDADE (
	idTipoHabilidade SMALLINT PRIMARY KEY IDENTITY (1,1),
	tipoHabilidade VARCHAR(20) NOT NULL
);
GO

CREATE TABLE HABILIDADE(
	idHabilidade SMALLINT PRIMARY KEY IDENTITY(1,1),
	idTipoHabilidade SMALLINT FOREIGN KEY REFERENCES TIPO_HABILIDADE(idTipoHabilidade),
	nomeHabilidade VARCHAR(20) NOT NULL

);
GO

CREATE TABLE CLASSE_HABILIDADE (
	idClasseHabilidade SMALLINT PRIMARY KEY IDENTITY (1,1),
	idClasse SMALLINT FOREIGN KEY REFERENCES CLASSE(idClasse),
	idHabilidade SMALLINT FOREIGN KEY REFERENCES HABILIDADE(idHabilidade)

);
GO

