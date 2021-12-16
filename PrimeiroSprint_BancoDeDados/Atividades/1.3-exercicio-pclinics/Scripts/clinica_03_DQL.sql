USE Clinica;
GO

SELECT * FROM Dono
SELECT * FROM Pet
SELECT * FROM Veterinario
SELECT * FROM TipoPet
SELECT * FROM CLINICA
SELECT * FROM Atendimento
SELECT * FROM Ra�aPet
SELECT * FROM Clinica
GO

/*
listar todos os veterin�rios (nome e CRMV) de uma cl�nica (raz�o social)
*/
SELECT nomeClinica, nomeVeterinario FROM VETERINARIO
INNER JOIN CLINICA
ON VETERINARIO.idClinica = CLINICA.idClinica
WHERE CLINICA.idClinica = 5
GO

/*
listar todas as ra�as que come�am com a letra S
*/
SELECT nomeRa�a FROM Ra�aPet
WHERE nomeRa�a LIKE 's%'

/*
listar todos os tipos de pet que terminam com a letra O
*/
SELECT nomeTipoPet FROM TipoPet
WHERE nomeTipoPet LIKE '%o'

/*
listar todos os pets mostrando os nomes dos seus donos
*/
SELECT nomePet pet, nomeDono dono FROM PET
LEFT JOIN DONO
ON PET.idDono = Dono.idDono

/*
listar todos os atendimentos mostrando o nome do veterin�rio que atendeu,
o nome, a ra�a e o tipo do pet que foi atendido,
o nome do dono do pet e o nome da cl�nica onde o pet foi atendido
*/
SELECT idAtendimento ,nomeVeterinario [Veterin�rio],
nomePet Pet, nomeTipoPet [TipoPet], nomeRa�a [Ra�aPet], 
nomeDono Dono, nomeClinica Clinica FROM ATENDIMENTO
LEFT JOIN VETERINARIO
ON ATENDIMENTO.idVeterinario = VETERINARIO.idVeterinario
LEFT JOIN PET
ON ATENDIMENTO.idPet = PET.idPet
LEFT JOIN Ra�aPet
ON Pet.idRa�aPet = Ra�aPet.idRa�aPet
LEFT JOIN TipoPet
ON Ra�aPet.idTipoPet = TipoPet.idTipoPet
LEFT JOIN Dono
ON PET.idDono = Dono.idDono
LEFT JOIN Clinica
ON Veterinario.idClinica = Clinica.idClinica