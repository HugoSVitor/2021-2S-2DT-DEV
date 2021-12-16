USE T_Rental;
GO

SELECT * FROM Empresa
SELECT * FROM Marca
SELECT * FROM Cliente
SELECT * FROM Veiculo
SELECT * FROM Modelo
SELECT * FROM Aluguel
GO

SELECT nomeCliente, nomeModelo, dataRetirada, dataDevolucao FROM ALUGUEL
LEFT JOIN CLIENTE
ON ALUGUEL.idCliente = CLIENTE.idCliente
LEFT JOIN VEICULO
ON VEICULO.idVeiculo = ALUGUEL.idVeiculo
LEFT JOIN MODELO
ON MODELO.idModelo = VEICULO.idModelo
GO

SELECT nomeCliente, nomeModelo, dataRetirada, dataDevolucao FROM ALUGUEL
RIGHT JOIN CLIENTE
ON ALUGUEL.idCliente = CLIENTE.idCliente
LEFT JOIN VEICULO
ON VEICULO.idVeiculo = ALUGUEL.idVeiculo
LEFT JOIN MODELO
ON MODELO.idModelo = VEICULO.idModelo
GO

SELECT idVeiculo, nomeModelo, nomeMarca, placa FROM Veiculo LEFT JOIN Modelo ON Veiculo.idModelo = Modelo.idModelo LEFT JOIN Marca ON Veiculo.idMarca = Marca.idMarca