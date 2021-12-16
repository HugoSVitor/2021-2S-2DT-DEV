USE Optus2;
GO

SELECT * FROM Usuario;
SELECT * FROM Artista;
SELECT * FROM Estilo;
SELECT * FROM Album;
SELECT * FROM Estilo;
SELECT * FROM AlbumEstilo;
GO

/*
listar todos os usuários administradores, sem exibir suas senhas
*/
SELECT nomeUsuario, email, permissao FROM Usuario
WHERE permissao = 'Admin'
GO

/*
listar todos os álbuns lançados após o um determinado ano de lançamento
*/
SELECT tituloAlbum, duracao FROM ALBUM
where dataLancamento > '2000-01-01'
GO

/*
listar os dados de um usuário através do e-mail e senha
*/
SELECT * FROM USUARIO
WHERE email = 'marcelinhoopica@outlook.com.br' AND senha = 'SenhaSecretakk'
GO

/*
listar todos os álbuns ativos, mostrando o nome do artista e os estilos do álbum 
*/
SELECT tituloAlbum Titulo,nomeArtista Artista,nomeEstilo Estilo FROM ALBUM
LEFT JOIN ARTISTA
ON ALBUM.idArtista = ARTISTA.idArtista
LEFT JOIN AlbumEstilo
ON ALBUM.idAlbum = AlbumEstilo.idAlbum
LEFT JOIN ESTILO
ON AlbumEstilo.idEstilo = ESTILO.idEstilo
WHERE disponibilidade = 'Ativo'
GO