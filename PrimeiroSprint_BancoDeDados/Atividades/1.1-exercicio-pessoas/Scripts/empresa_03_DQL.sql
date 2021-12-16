Use Empresa;
Go

SELECT * FROM Pessoa
SELECT * FROM Telefone
SELECT * FROM Email
GO

SELECT nomePessoa, numeroTelefone, endereçoEmail FROM Pessoa
LEFT JOIN Telefone
ON Pessoa.idPessoa = Telefone.idPessoa
FULL OUTER JOIN EMAIL
ON Pessoa.idPessoa = Email.idPessoa
ORDER BY nomePessoa DESC
GO