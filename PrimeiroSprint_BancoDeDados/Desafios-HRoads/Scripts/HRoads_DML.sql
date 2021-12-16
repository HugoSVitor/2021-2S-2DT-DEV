USE HROADS_TARDE;
GO

INSERT INTO CLASSE (nomeClasse, capMaxVida, capMaxMana)
VALUES ('Bárbaro', '100', '80'), ('Monge', '70', '100'), ('Arcanista', '75', '60');
GO

INSERT INTO CLASSE (nomeClasse, capMaxVida, capMaxMana)
VALUES ('Cruzado', 'x', 'x'), ('Caçadora de Demônios', 'x', 'x'), 
	   ('Necromante', 'x', 'x'), ('Feiticeiro', 'x', 'x');
GO

INSERT INTO PERSONAGEM (idClasse ,nomePersonagem, dataAtualizacao, dataCriacao)
VALUES (1, 'DeuBug', 'Data Atual', '18/01/2019'), (2, 'BitBug', 'Data Atual', '17/03/2016'), (3, 'Fer8', 'Data Atual', '18/03/2018');
GO

INSERT INTO TIPO_HABILIDADE (tipoHabilidade)
VALUES ('Ataque'), ('Defesa'), ('Cura'), ('Magia');
GO

INSERT INTO HABILIDADE (idTipoHabilidade ,nomeHabilidade)
VALUES (1, 'Lança Mortal'), (2,'Escudo Supremo'), (3, 'Recuperar Vida');
GO


INSERT INTO CLASSE_HABILIDADE(idClasse, idHabilidade)
VALUES (1, 1), (1,2), (2,2), (2,3), (3, NULL);
GO

INSERT INTO CLASSE_HABILIDADE(idClasse, idHabilidade)
VALUES (4, 2), (5,1), (7,3);
GO