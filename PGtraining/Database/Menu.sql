﻿CREATE TABLE [dbo].[Menu]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [OrderNo] NCHAR(8) NOT NULL, 
    [MenuCode] VARCHAR(8) NOT NULL, 
    [MenuName] NVARCHAR(32) NOT NULL
)
