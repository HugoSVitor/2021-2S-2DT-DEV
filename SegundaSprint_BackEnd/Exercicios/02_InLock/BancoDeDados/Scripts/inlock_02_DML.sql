USE inlock_games_tarde;
GO

INSERT INTO ESTUDIO (nomeEstudio)
VALUES ('Blizzard'),('Rockstar Studios'),('Square Enix')
GO

INSERT INTO TIPOUSUARIO (titulo)
VALUES ('ADMINISTRADOR'),('CLIENTE')
GO

INSERT INTO USUARIO (email,senha,idTipoUsuario)
VALUES ('cliente@cliente.com','cliente',2),('admin@admin.com','admin',1)
GO

INSERT INTO JOGO (nomeJogo,descricao,dataLancamento,valor,idEstudio)
VALUES ('Diablo 3,','� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�.','15/05/2012','R$ 99,00',1),
('Red Dead Redemption II','jogo eletr�nico de a��o-aventura western.','26/10/2018','R$ 120,00',2)
GO