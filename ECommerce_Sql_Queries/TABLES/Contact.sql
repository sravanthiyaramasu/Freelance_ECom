﻿CREATE TABLE [dbo].[Contact]
(
	[ContactId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(50) NULL,
	[Email] VARCHAR(50) NULL,
	[Subject] VARCHAR(50) NULL,
	[Message] VARCHAR(500) NULL,
	CreatedDate DATETIME NOT NULL
)
