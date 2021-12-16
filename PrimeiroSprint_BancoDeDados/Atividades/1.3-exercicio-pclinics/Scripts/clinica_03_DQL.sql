USE Clinica;
GO

SELECT * FROM Dono
SELECT * FROM Pet
SELECT * FROM Veterinario
SELECT * FROM TipoPet
SELECT * FROM CLINICA
SELECT * FROM Atendimento
SELECT * FROM RaçaPet
SELECT * FROM Clinica
GO

/*
listar todos os veterinários (nome e CRMV) de uma clínica (razão social)
*/
SELECT nomeClinica, nomeVeterinario FROM VETERINARIO
INNER JOIN CLINICA
ON VETERINARIO.idClinica = CLINICA.idClinica
WHERE CLINICA.idClinica = 5
GO

/*
listar todas as raças que começam com a letra S
*/
SELECT nomeRaça FROM RaçaPet
WHERE nomeRaça LIKE 's%'

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
listar todos os atendimentos mostrando o nome do veterinário que atendeu,
o nome, a raça e o tipo do pet que foi atendido,
o nome do dono do pet e o nome da clínica onde o pet foi atendido
*/
SELECT idAtendimento ,nomeVeterinario [Veterinário],
nomePet Pet, nomeTipoPet [TipoPet], nomeRaça [RaçaPet], 
nomeDono Dono, nomeClinica Clinica FROM ATENDIMENTO
LEFT JOIN VETERINARIO
ON ATENDIMENTO.idVeterinario = VETERINARIO.idVeterinario
LEFT JOIN PET
ON ATENDIMENTO.idPet = PET.idPet
LEFT JOIN RaçaPet
ON Pet.idRaçaPet = RaçaPet.idRaçaPet
LEFT JOIN TipoPet
ON RaçaPet.idTipoPet = TipoPet.idTipoPet
LEFT JOIN Dono
ON PET.idDono = Dono.idDono
LEFT JOIN Clinica
ON Veterinario.idClinica = Clinica.idClinica