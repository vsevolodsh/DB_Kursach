use Kursach_DB
GO 
CREATE PROCEDURE sp_InsertSkates
	@Number INT,
	@ProductSubCategoryCode INT,
	@Code INT,
	@Name NVARCHAR(50),
	@RentCostInHour MONEY,
	@BladeSteel NVARCHAR(50),
	@Fixation NVARCHAR(50),
	@Size TINYINT
AS
INSERT INTO Product(Number, ProductSubCategoryCode, Code, Name, RentCostInHour, IsProductInWarehouse)
VALUES(@Number, @Code, @ProductSubCategoryCode, @Name, @RentCostInHour, 1)

INSERT INTO Skates (ProductNumber, BladeSteel, Fixation, Size)
VALUES (@Number, @BladeSteel, @Fixation, @Size)