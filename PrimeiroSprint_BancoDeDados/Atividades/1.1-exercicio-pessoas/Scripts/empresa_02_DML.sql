USE Empresa

INSERT INTO Pessoa (nomePessoa)
VALUES ('Gustavo'),('Lucas')
GO

INSERT INTO Telefone (idPessoa,numeroTelefone)
VALUES (1,'111111111'), (2,'22222222'),(2,'33333333')
GO

INSERT INTO Email (idPessoa,endereçoEmail)
VALUES (1,'g@hotmail.com'),(2,'ol@hotmail.com')
GO