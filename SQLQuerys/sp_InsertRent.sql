use Kursach_DB
GO 
CREATE PROCEDURE sp_InsertRent
	@TenantId INT,
	@TotalRentCost MONEY,
	@DateStart Datetime,
	@DateEnd Datetime,
	@TotalDeposit MONEY,
	@ProductNumber INT,
	@RentId INT
AS
INSERT INTO Rent(TenantId, TotalRentCost, DateStart, DateEnd, TotalDepositCost, IsOver)
VALUES(@TenantId, @TotalRentCost, @DateStart, @DateEnd, @TotalDeposit, 0)
--SET @RentId = SCOPE_IDENTITY()

INSERT INTO ProductRent (RentId, ProductNumber)
VALUES (@RentId, @ProductNumber)

UPDATE Product
SET IsProductInWarehouse = 0
WHERE Product.Number = @ProductNumber