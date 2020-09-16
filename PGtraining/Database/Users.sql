CREATE TABLE [dbo].[Users]
(
	[Id] INT IDENTITY (1, 1) NOT NULL ,
    [UserId] VARCHAR(8) NOT NULL,
    [Name] NVARCHAR(32) NOT NULL, 
    [PassWord] NVARCHAR(32) NOT NULL, 
    [ExpirationDate] DATETIME NOT NULL DEFAULT '9999/12/31',
    PRIMARY KEY ([UserId])
)
