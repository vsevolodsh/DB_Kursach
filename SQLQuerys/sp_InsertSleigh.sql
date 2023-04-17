use Kursach_DB
GO 
CREATE PROCEDURE sp_InsertSleigh
	@Number INT,
	@ProductSubCategoryCode INT, 
	@Code INT,
	@Name NVARCHAR(50),
	@RentCostInHour MONEY,
	@Construction NVARCHAR(50),
	@RunnersType NVARCHAR(50),
	@MaxLoad TINYINT
AS
INSERT INTO Product(Number, ProductSubCategoryCode, Code, Name, RentCostInHour, IsProductInWarehouse)
VALUES(@Number, @ProductSubCategoryCode, @Code,  @Name, @RentCostInHour, 1)

INSERT INTO Sleigh(ProductNumber, Construction, RunnersType, MaxLoad)
VALUES (@Number, @Construction, @RunnersType, @MaxLoad)