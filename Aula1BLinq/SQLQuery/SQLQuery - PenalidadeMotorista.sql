use DBPenalidadeMotorista;

CREATE TABLE Penalidade (

ID INT IDENTITY (1,1) PRIMARY KEY,
RazaoSocial VARCHAR (100) NOT NULL,
CNPJ VARCHAR (50) NOT NULL,
NomeMotorista VARCHAR (100) NOT NULL,
CPF VARCHAR (30) NOT NULL,
VigenciaCadastro DATE NOT NULL

);

CREATE TABLE MetaDado(
ID INT IDENTITY (1,1) PRIMARY KEY,
Description VARCHAR (100) NOT NULL,
Data DATETIME DEFAULT GETDATE(),
NumberOfRecords INT NOT NULL,
);



SELECT * FROM Penalidade
SELECT * FROM MetaDado

DROP TABLE MetaDado
DROP TABLE Penalidade 

