CREATE TABLE [dbo].[Category]
(
	CategoryId INT PRIMARY KEY IDENTITY(1,1),
   CategoryName VARCHAR(100) NOT NULL,
   CategoryImageUrl VARCHAR(MAX) NOT NULL,
   IsActive BIT NOT NULL,
   CreatedDate DATETIME NOT NULL
)
