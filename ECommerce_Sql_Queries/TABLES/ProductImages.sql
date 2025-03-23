CREATE TABLE [dbo].[ProductImages]
(
   ImageId INT PRIMARY KEY IDENTITY(1,1),
   ImageUrl VARCHAR(MAX) NULL,
   ProductId INT FOREIGN KEY REFERENCES [Product](ProductId) ON DELETE CASCADE NOT NULL,
   DefaultImage BIT NULL
)
