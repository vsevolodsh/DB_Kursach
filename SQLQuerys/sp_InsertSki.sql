use Kursach_DB
GO 
CREATE PROCEDURE sp_InsertSki
	@Number INT,
	@ProductSubCategoryCode INT,
	@Code INT,
	@Name NVARCHAR(50),
	@RentCostInHour MONEY,
	@RidingStyle NVARCHAR(50),
	@SkiLength INT
AS
INSERT INTO Product(Number, ProductSubCategoryCode, Code, Name, RentCostInHour, IsProductInWarehouse)
VALUES(@Number, @ProductSubCategoryCode, @Code, @Name, @RentCostInHour, 1)

INSERT INTO Ski(ProductNumber, RidingStyle, SkiLength)
VALUES (@Number, @RidingStyle, @SkiLength)