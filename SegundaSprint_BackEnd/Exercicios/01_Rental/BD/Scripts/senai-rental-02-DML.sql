USE T_Rental;
Go

Insert Into Empresa (funImpresa)
Values ('Rental')
GO

Insert Into Marca (nomeMarca)
Values ('Jeep'),('Ford')
GO

Insert Into Cliente (nomeCliente,sobrenomeCliente, cpfCliente, cnhCliente)
Values ('Marcio','Silva','2222222','1234567890'),('Simone','Vitor','11111111', '9876543210')
Go

Insert Into Modelo (nomeModelo,idMarca)
Values ('Renegate',1),('Compass',1),('Mustang',2)
Go

Insert Into Veiculo (idEmpresa,idModelo,idMarca,placa)
Values (1,1,1,'11111111'),(1,2,1,'98473647'),(1,3,2,'13434534')
GO

Insert Into Aluguel (idCliente,idVeiculo,dataDevolucao,dataRetirada)
Values (2,2,'02/09/2021 14:30:00','30/09/2021 11:30:00'),(1,3,'01/10/2021 12:25:00','30/10/2021 20:00:00')
Go



SELECT * FROM ALUGUEL

UPDATE Cliente SET nomeCliente = 'Heliméria', sobrenomeCliente = 'Dos Santos', cpfCliente = '25252525252'  cnhCliente = '3232323232' WHERE idCliente = 3