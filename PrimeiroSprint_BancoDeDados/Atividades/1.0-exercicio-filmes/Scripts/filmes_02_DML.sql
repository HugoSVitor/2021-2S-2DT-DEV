Use Catalogo;
GO

Insert Into Genero(nomeGenero)
Values ('A��o'), ('Romance');
GO

Select  * From Genero

Delete From Genero
Where idGenero = 2
GO

Update Filme  set tituloFilme = 'Rambo 2'


Insert Into Filme (idGenero,tituloFilme)
Values (1, 'Rambo'), (1,'Vingadores'), (3,'Ghost'), (3,'Di�rio de uma paix�o')
GO

Select  * From Filme

Delete From Filme
Where idFilme in(2,3)