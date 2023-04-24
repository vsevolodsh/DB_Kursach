use Kursach_DB
GO 
CREATE PROCEDURE sp_InsertSkiPoles
	@Number INT,
	@ProductSubCategoryCode INT,
	@Code INT,
	@Name NVARCHAR(50),
	@RentCostInHour MONEY,
	@ShaftMaterial NVARCHAR(50),
	@HandleMaterial NVARCHAR(50),
	@SkiPolesLength TINYINT
AS
INSERT INTO Product(Number, ProductSubCategoryCode, Code, Name, RentCostInHour, IsProductInWarehouse)
VALUES(@Number,@ProductSubCategoryCode,  @Code,  @Name, @RentCostInHour, 1)

INSERT INTO SkiPoles(ProductNumber, ShaftMaterial, HandleMaterial, SkiPolesLength)
VALUES (@Number, @ShaftMaterial, @HandleMaterial, @SkiPolesLength)