CREATE DATABASE inlock_games_tarde;
GO

USE inlock_games_tarde
GO

CREATE TABLE ESTUDIO
(
	idEstudio INT PRIMARY KEY IDENTITY(1,1),
	nomeEstudio VARCHAR(65) NOT NULL UNIQUE
);
GO

CREATE TABLE JOGO
(
	idJogo INT PRIMARY KEY IDENTITY(1,1),
	nomeJogo VARCHAR(100) NOT NULL UNIQUE,
	descricao VARCHAR(200) NOT NULL,
	dataLancamento DATE,
	valor VARCHAR(20) NOT NULL,
	idEstudio INT FOREIGN KEY REFERENCES ESTUDIO(idEstudio)
);
GO

CREATE TABLE TIPOUSUARIO
(
	idTipoUsuario INT PRIMARY KEY IDENTITY(1,1),
	titulo VARCHAR(20) NOT NULL
);
GO

CREATE TABLE USUARIO
(
	idUsuario INT PRIMARY KEY IDENTITY(1,1),
	email VARCHAR(100) NOT NULL UNIQUE,
	senha VARCHAR(25) NOT NULL,
	idTipoUsuario INT FOREIGN KEY REFERENCES TIPOUSUARIO(idTipoUsuario)
);
GO