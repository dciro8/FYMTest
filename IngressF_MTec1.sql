
CREATE TABLE dbo.[User]
(
	Id uniqueidentifier NOT NULL,
	DocumentType VARCHAR(5) NOT NULL, 
	DocumentNumber VARCHAR(50) NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Email VARCHAR(100) NOT NULL,
	Password VARCHAR(250),
	Role uniqueidentifier NOT NULL,
	State Bit NOT NULL
)
GO

ALTER TABLE dbo.[User] ADD CONSTRAINT User_p1 PRIMARY KEY (Email)
GO


CREATE TABLE dbo.Role
(
	Id uniqueidentifier NOT NULL,
	IdentificaionCode VARCHAR(5) NOT NULL,
	Description VARCHAR(50) NOT NULL,
	State Bit NOT NULL
)	
GO


ALTER TABLE dbo.Role ADD CONSTRAINT Role_p1 PRIMARY KEY (Id)
GO

CREATE TABLE dbo.DocumentType
(
	Id uniqueidentifier NOT NULL,
	Code VARCHAR(5) NOT NULL,
	Description VARCHAR(50) NOT NULL,
	State Bit NOT NULL
)
GO
	

ALTER TABLE dbo.DocumentType ADD CONSTRAINT DocumentType_P1 PRIMARY KEY (Code)
GO



ALTER TABLE dbo.[User]  ADD  CONSTRAINT FK_Users_Role FOREIGN KEY(Role)
REFERENCES dbo.Role (ID)
GO

ALTER TABLE dbo.[User]  ADD  CONSTRAINT FK_Users_DocumentType FOREIGN KEY(DocumentType)
REFERENCES dbo.DocumentType (Code)
GO


INSERT INTO dbo.DocumentType (Id ,Code, Description, State) VALUES ('892A430C-87EF-45C9-9776-470D754B989F','CC', 'Cédula de ciudadania', 1)
INSERT INTO dbo.DocumentType (Id ,Code, Description, State) VALUES ('2C0E702E-6A4F-4CF5-888F-EE50A61DE724','CE', 'Cédula de extranjería', 1)
INSERT INTO dbo.DocumentType (Id ,Code, Description, State) VALUES ('155B47D2-95E1-4E13-BDA8-FE43B2D86328','PA', 'Pasaporte', 1)
GO

INSERT INTO dbo.Role (Id ,IdentificaionCode, Description, State) VALUES ('8013CFE1-B7D2-4795-A2FE-B21558C21C9F','ADM', 'Administrador', 1)
INSERT INTO dbo.Role (Id ,IdentificaionCode, Description, State) VALUES ('2A5591A4-68BA-4AC3-A6D2-447E1D70ABA7','DEF', 'Default', 1)
INSERT INTO dbo.Role (Id ,IdentificaionCode, Description, State) VALUES ('8013CFE1-B7D2-4795-A2FE-B21558C21C9F','ADM', 'Administrador', 1)

go

USE [IngressF_MTec]
GO

INSERT INTO [dbo].[User]
           ([Id]
           ,[DocumentType]
           ,[DocumentNumber]
           ,[FirstName]
           ,[LastName]
           ,[Email]
           ,[Password]
           ,[Role]
           ,[State])
     VALUES
           ('03D3976D-94A1-4E62-9D70-AA5BD7C924C8'
           ,'CC'
           ,'112826543'
           ,'David'
           ,'Ciro'
           ,'ciro@mail.com'
           ,'8f210c0d1c4d52dcf56a2c2d9ef13763'
           ,'8013CFE1-B7D2-4795-A2FE-B21558C21C9F'
           ,1)
GO




SELECT NEWID()