Create Database Optus2;
Go

Use Optus2;
Go

Create Table Artista(
	idArtista  Smallint Primary Key Identity(1,1),
	nomeArtista Varchar(40) Not null
);
Go

Create Table Estilo(
	idEstilo Tinyint Primary Key Identity(1,1),
	nomeEstilo Varchar(20) Not null
);
Go

Create Table Usuario(
	idUsuario Int Primary Key Identity(1,1),
	nomeUsuario Varchar(20) Not null,
	permissao Varchar(10) Not null,
	email Varchar(35) Not null,
	senha Varchar(35) Not null
);
Go

Drop Table Usuario

Alter Table Usuario
Drop Column duracao,disponibilidade;

Alter Table Usuario
Add senha Varchar(20) Not null;


Create Table Album(
	idAlbum Int Primary Key Identity(1,1),
	idArtista Smallint Foreign Key References Artista(idArtista),
	tituloAlbum Varchar(40) Not null,
	dataLancamento Varchar(8) Not null,
	duracao Varchar(10) Not null,
	disponibilidade Varchar(10) Not null,
);
Go

Create Table AlbumEstilo(
	idAlbumEstilo Int Primary Key Identity(1,1),
	idAlbum Int Foreign Key References Album(idAlbum),
	idEstilo Tinyint Foreign Key References Estilo(idEstilo)
);
Go