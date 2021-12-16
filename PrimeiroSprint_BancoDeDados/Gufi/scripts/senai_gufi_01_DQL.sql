USE GUFI_TARDE;
GO

-- Lista todos os tipos de usu�rios
   SELECT * FROM tipoUsuario 

-- Lista todos os usu�rios
   SELECT * FROM usuario 

-- Lista todas as institui��es
   SELECT * FROM instituicao 

-- Lista todos os tipos de eventos
   SELECT * FROM tipoEvento

-- Lista todos os eventos 
   SELECT * FROM evento

-- Lista todas as presen�as
   SELECT * FROM presenca 

-- Seleciona os dados dos usu�rios mostrando o tipo de usu�rio
   SELECT U.idUsuario as ID,
          U.nomeUsuario [USUARIO NOME], 
		  --T.idTipoUsuario 'Tipo de Usu�rio', -- COLUNA COMENTADA.
		  T.tituloTipoUsuario titulo
   FROM usuario U
   INNER JOIN tipoUsuario T ON U.idTipoUsuario = T.idTipoUsuario
   	  
 -- Seleciona os dados dos eventos, da institui��o e dos tipos de eventos
    SELECT E.nomeEvento Evento,
           I.nomeFantasia Institui��o,
		   TE.tituloTipoEvento [Tipo do Evento]
    FROM evento E
    INNER JOIN tipoEvento TE ON E.idTipoEvento = TE.idTipoEvento
    INNER JOIN instituicao I ON E.idInstituicao = I.idInstituicao
   	  
-- Seleciona os dados dos eventos, da institui��o, 
--dos tipos de eventos e dos usu�rios
-- e a situacao da presenca
   SELECT U.nomeUsuario Usu�rio,
          TU.tituloTipoUsuario [Tipo de Usu�rio],
          U.email [Email do Usu�rio],
		  E.nomeEvento [Nome do Evento],
		  E.dataEvento,		 
		  convert(varchar(20),E.dataEvento,106) [Data do Evento], --TRATADO.
		  TE.tituloTipoEvento [Tipo do Evento],
		  I.nomeFantasia Institui��o,
		  S.descricao Situa��o,
		  E.acessoLivre
   FROM usuario U
   INNER JOIN presenca P ON (U.idUsuario = P.idUsuario)
   INNER JOIN situacao S ON (P.idUsuario = S.idSituacao)
   INNER JOIN evento E ON (P.idEvento = E.idEvento)
   INNER JOIN tipoEvento TE ON (E.idTipoEvento = TE.idTipoEvento)
   JOIN instituicao I ON (E.idInstituicao = I.idInstituicao)
   INNER JOIN tipoUsuario TU ON (U.idTipoUsuario = TU.idTipoUsuario) 

-- Busca um usu�rio atrav�s do seu e-mail e senha
   SELECT nomeUsuario, email, senha 
   FROM usuario 
   WHERE email = 'adm@adm.com'
   AND senha = 'adm12345'   	   