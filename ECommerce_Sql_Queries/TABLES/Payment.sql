CREATE TABLE [dbo].[Payment]
(
	[PaymentId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(50) NULL,
	[CardNo] VARCHAR(50) NULL,
	[ExpiryDate] VARCHAR(50) NULL,
	[CvvNo] INT NULL,
	[Address] VARCHAR(MAX) NULL,
	[PaymentMode] VARCHAR(50) NULL,
)
