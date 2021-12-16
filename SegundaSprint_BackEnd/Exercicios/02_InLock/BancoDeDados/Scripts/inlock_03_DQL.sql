USE inlock_games_tarde;
GO


SELECT * FROM USUARIO

SELECT * FROM ESTUDIO

SELECT * FROM JOGO

SELECT nomeJogo,descricao,dataLancamento,valor,nomeEstudio FROM JOGO
LEFT JOIN ESTUDIO
ON JOGO.idEstudio = ESTUDIO.idEstudio
GO

SELECT nomeEstudio,nomeJogo FROM ESTUDIO
LEFT JOIN JOGO
ON ESTUDIO.idEstudio = JOGO.idEstudio
GO

SELECT * FROM USUARIO WHERE email='cliente@cliente.com' AND senha='cliente'
GO

SELECT * FROM JOGO WHERE idJogo= 1
GO

SELECT * FROM ESTUDIO WHERE idEstudio= 3
GO
