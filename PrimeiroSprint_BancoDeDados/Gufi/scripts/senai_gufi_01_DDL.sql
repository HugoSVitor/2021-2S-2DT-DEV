
CREATE DATABASE GUFI_TARDE;
GO 

USE GUFI_TARDE 



--- TIPOUSUARIO

CREATE TABLE tipoUsuario (
  idTipoUsuario SMALLINT PRIMARY KEY IDENTITY,
  tituloTipoUsuario VARCHAR(50) UNIQUE NOT NULL
);
GO

-- TIPO EVENTO
CREATE TABLE tipoEvento(
 idTipoEvento INT PRIMARY KEY IDENTITY,
 tituloTipoEvento VARCHAR(100) UNIQUE NOT  NULL
);
GO



-- SITUACAO
CREATE TABLE situacao (
  idSituacao TINYINT PRIMARY KEY IDENTITY,
  descricao VARCHAR(25) NOT NULL UNIQUE
);
GO

-- INSTITUI��O
CREATE TABLE instituicao (
   idInstituicao SMALLINT PRIMARY KEY IDENTITY,
   CNPJ CHAR(18) UNIQUE NOT NULL,
   nomeFantasia VARCHAR(100) NOT NULL,
   endereco VARCHAR(150) UNIQUE NOT NULL
);
GO

-- USUARIO

-- drop table usuario
-- drop table presenca 

CREATE TABLE usuario (
	  idUsuario INT PRIMARY KEY IDENTITY,
	  idTipoUsuario SMALLINT FOREIGN KEY REFERENCES tipoUsuario(idTipoUsuario),
	  nomeUsuario VARCHAR(100) NOT NULL,
	  email VARCHAR(256) UNIQUE NOT NULL,
	  senha VARCHAR(10) NOT NULL CHECK( len(senha) >= 8)  -->REGRA PARA COLOCAR APENAS 8. LEN PEGA O TAMANHO.

);
GO
-- EVENTO
CREATE TABLE evento(
	idEvento INT PRIMARY KEY IDENTITY,
	idTipoEvento INT FOREIGN KEY REFERENCES tipoEvento (idTipoEvento),
	idInstituicao SMALLINT FOREIGN KEY REFERENCES instituicao(idInstituicao),
	nomeEvento VARCHAR(50) NOT NULL,
	descricao VARCHAR(300) NOT NULL,
	dataEvento DATETIME NOT NULL,
	acessoLivre BIT DEFAULT (1)
);
GO




-- PRESENCA
CREATE TABLE presenca (
	idPresenca INT PRIMARY KEY IDENTITY,
	idUsuario INT FOREIGN KEY REFERENCES usuario ( idUsuario),
	idEvento INT FOREIGN KEY REFERENCES evento(idEvento),
	idSituacao TINYINT FOREIGN KEY REFERENCES situacao(idSituacao)
);
GO

/*
   PRIMARY KEY = CHAVE PRIMARIA
   FOREIGN KEY = CHAVE ESTRANGEIRA
   IDENTITY = Define que o campo ser� auto-incrementado e �nico.
   NOT NULL = Define que n�o pode ser nulo, ou seja, obrigat�rio.
   UNIQUE = Define que o valor do campo � unico, ou seja, n�o repete.
   DEFAULT = Define um valor padr�o, caso nenhum seja informado.
   GO = Pausa a leitura e executa o bloco de c�digo acima.
*/





