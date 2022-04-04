CREATE DATABASE [TesteLogin]

USE [TesteLogin]
GO

IF NOT EXISTS (SELECT 1 FROM SYS.TABLES T WHERE T.NAME = 'Usuario')
BEGIN
	CREATE TABLE Usuario (
		Usuario VARCHAR(255),
		senha VARCHAR (255),
		Status VARCHAR(15),
		PRIMARY KEY (Usuario)
		)
END        


IF NOT EXISTS (SELECT 1 FROM SYS.TABLES T WHERE T.NAME = 'HistoricoLogins')
BEGIN
	CREATE TABLE HistoricoLogins (
		IdUsuario INT IDENTITY (1,1) NOT NULL,
		UserName VARCHAR(255),
		Status VARCHAR(15) ,
		DT_LOGIN DATETIME,
		PRIMARY KEY (IdUsuario)
		)
     ALTER TABLE HistoricoLogins ADD CONSTRAINT FK_HistoricoLogins_CD_USER FOREIGN KEY (IdUsuario)     
    REFERENCES Usuario (CD_USER) 
END



--------------------------------------------------------------------------------------------------


