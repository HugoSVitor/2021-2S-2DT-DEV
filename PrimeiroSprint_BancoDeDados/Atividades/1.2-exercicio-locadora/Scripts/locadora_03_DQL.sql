Use Locadora;
Go

SELECT * FROM Empresa
SELECT * FROM Marca
SELECT * FROM Cliente
SELECT * FROM Veiculo
SELECT * FROM Modelo
SELECT * FROM Aluguel
GO

/*
 listar todos os alugueis mostrando as datas de início e fim,
 o nome do cliente que alugou e nome do modelo do carro
*/

SELECT nomeCliente, nomeModelo, dataRetirada, dataDevolucao FROM ALUGUEL
LEFT JOIN CLIENTE
ON ALUGUEL.idCliente = CLIENTE.idCliente
LEFT JOIN VEICULO
ON VEICULO.idVeiculo = ALUGUEL.idVeiculo
LEFT JOIN MODELO
ON MODELO.idModelo = VEICULO.idModelo
GO

/*
listar os alugueis de um determinado cliente mostrando seu nome,
as datas de início e fim e o nome do modelo do carro
*/

SELECT nomeCliente, nomeModelo, dataRetirada, dataDevolucao FROM ALUGUEL
RIGHT JOIN CLIENTE
ON ALUGUEL.idCliente = CLIENTE.idCliente
LEFT JOIN VEICULO
ON VEICULO.idVeiculo = ALUGUEL.idVeiculo
LEFT JOIN MODELO
ON MODELO.idModelo = VEICULO.idModelo
GO