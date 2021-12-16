Use Optus2;
Go

Insert Into Artista (nomeArtista)
Values ('Rogérinho'),('Marta')
go

Insert Into Estilo (nomeEstilo)
Values ('Country'),('Rock'),('Funk')
GO

Insert Into Usuario (nomeUsuario,permissao,email,senha)
Values ('Marcelinho','Comum','marcelinhoopica@outlook.com.br','senhaSecretakk')
,('Cleiton','Admin','cleitinmacetante@gmail.com','senha123')
Go

Insert Into Album (idArtista,tituloAlbum,dataLancamento,duracao,disponibilidade)
Values (1,'Caminho ao Inferno','02092021','5 horas','Ativo'),
(2,'Norte do Texas','22052010','8 horas','Inativo')
Go

Select * From Artista

Select * From Estilo

Select * From Usuario

