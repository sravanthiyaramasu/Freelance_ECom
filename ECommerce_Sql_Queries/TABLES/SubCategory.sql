CREATE TABLE [dbo].[SubCategory]
(
   SubCategoryId INT PRIMARY KEY IDENTITY(1,1),
   SubCategoryName VARCHAR(100) NOT NULL,
   CategoryId INT FOREIGN KEY REFERENCES Category(CategoryId) ON DELETE CASCADE NOT NULL,
   IsActive BIT NOT NULL,
   CreatedDate DATETIME NOT NULL
)
