Use Locadora;
Go

Insert Into Empresa (funImpresa)
Values ('Locadora')
GO

Insert Into Marca (nomeMarca)
Values ('Jeep'),('Ford')
GO

Insert Into Cliente (nomeCliente, cpfCliente)
Values ('Marcio','2222222'),('Simone','11111111')
Go

Insert Into Modelo (nomeModelo,idMarca)
Values ('Renegate',1),('Compass',1),('Mustang',2)
Go

Insert Into Veiculo (idEmpresa,idModelo,idMarca,placa)
Values (1,1,1,'92893879'),(1,2,1,'98473647'),(1,3,2,'13434534')
GO

Insert Into Aluguel (idCliente,idVeiculo)
Values (1,1),(2,2)
Go