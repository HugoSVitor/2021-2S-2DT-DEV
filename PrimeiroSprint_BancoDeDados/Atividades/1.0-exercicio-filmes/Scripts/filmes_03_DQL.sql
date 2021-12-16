Use Catalogo;
Go

SELECT * FROM Genero
SELECT * FROM Filme
GO

SELECT idFilme, tituloFilme, nomeGenero FROM Filme
LEFT JOIN GENERO
ON Filme.idGenero = Genero.idGenero
GO

SELECT tituloFilme, nomeGenero FROM Filme
RIGHT JOIN GENERO
ON Filme.idGenero = Filme.idGenero
GO

SELECT tituloFilme, nomeGenero FROM Filme
INNER JOIN GENERO
ON Filme.idGenero = Genero.idGenero
GO

SELECT tituloFilme, nomeGenero FROM Filme
FULL OUTER JOIN GENERO
ON Filme.idGenero = Genero.idGenero
GO
