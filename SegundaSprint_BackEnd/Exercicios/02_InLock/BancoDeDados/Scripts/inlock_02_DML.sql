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
VALUES ('Diablo 3,','é um jogo que contém bastante ação e é viciante, seja você um novato ou um fã.','15/05/2012','R$ 99,00',1),
('Red Dead Redemption II','jogo eletrônico de ação-aventura western.','26/10/2018','R$ 120,00',2)
GO