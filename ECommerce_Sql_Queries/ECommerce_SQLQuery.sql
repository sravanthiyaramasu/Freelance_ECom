USE ECommerce
CREATE TABLE Category
(
   CategoryId INT PRIMARY KEY IDENTITY(1,1),
   CategoryName VARCHAR(100) NOT NULL,
   CategoryImageUrl VARCHAR(MAX) NOT NULL,
   IsActive BIT NOT NULL,
   CreatedDate DATETIME NOT NULL
)
CREATE TABLE SubCategory
(
   SubCategoryId INT PRIMARY KEY IDENTITY(1,1),
   SubCategoryName VARCHAR(100) NOT NULL,
   CategoryId INT FOREIGN KEY REFERENCES Category(CategoryId) ON DELETE CASCADE NOT NULL,
   IsActive BIT NOT NULL,
   CreatedDate DATETIME NOT NULL
)
CREATE TABLE [Product]
(
   ProductId INT PRIMARY KEY IDENTITY(1,1),
   ProductName VARCHAR(100) NOT NULL,
   ShortDescription VARCHAR(200) NULL,
   LongDescription VARCHAR(MAX) NULL,
   AdditionalDescription VARCHAR(MAX) NULL,
   Price DECIMAL(18,2) NOT NULL,
   Quantity INT NOT NULL,
   Size VARCHAR(30) NULL,
   Color VARCHAR(50) NULL,
   CompanyName VARCHAR(100) NULL,
   CategoryId INT FOREIGN KEY REFERENCES Category(CategoryId) ON DELETE CASCADE NOT NULL,
   SubCategoryId INT NOT NULL,
   Sold INT NULL,
   IsCustomized BIT NOT NULL,
   IsActive BIT NOT NULL,
   CreatedDate DATETIME NOT NULL

)
CREATE TABLE ProductImages
(
   ImageId INT PRIMARY KEY IDENTITY(1,1),
   ImageUrl VARCHAR(MAX) NULL,
   ProductId INT FOREIGN KEY REFERENCES [Product](ProductId) ON DELETE CASCADE NOT NULL,
   DefaultImage BIT NULL
)
CREATE TABLE Roles
(
   RoleId INT PRIMARY KEY,
   RoleName VARCHAR(50) NOT NULL
)

INSERT INTO Roles VALUES(1, 'Admin')
INSERT INTO Roles VALUES(2, 'Customer')

CREATE TABLE Users
(
   UserId INT PRIMARY KEY IDENTITY(1,1),
   Name VARCHAR(50) NULL,
   UserName VARCHAR(50) UNIQUE,
   Mobile VARCHAR(30) NULL,
   Email VARCHAR(50) NULL,
   Address VARCHAR(MAX) NULL,
   PostCode VARCHAR(50) NULL,
   Password VARCHAR(50) NULL,
   ImageUrl VARCHAR(MAX) NULL,
   RoleId INT FOREIGN KEY REFERENCES Roles(RoleId) ON DELETE CASCADE NOT NULL,
   CreatedDate DATETIME NOT NULL
)
CREATE TABLE ProductReview
(
   ReviewId INT PRIMARY KEY IDENTITY(1,1),
   Rating INT NOT NULL,
   Comment VARCHAR(MAX) NULL,
   ProductId INT FOREIGN KEY REFERENCES Product (ProductId) ON DELETE CASCADE NOT NULL,
   UserId INT FOREIGN KEY REFERENCES Users (UserId) ON DELETE CASCADE NOT NULL,
   CreatedDate DATETIME NOT NULL

)
