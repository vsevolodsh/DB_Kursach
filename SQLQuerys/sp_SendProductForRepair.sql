use Kursach_DB
GO 
CREATE PROCEDURE sp_SendProductForRepair
	@RepairCompanyId INT,
	@ProductNumber INT,
	@Cost MONEY,
	@DateStart DATE,
	@DateEnd DATE
AS
UPDATE Product 
SET IsProductInWarehouse = 0
WHERE Product.Number = @ProductNumber;

INSERT INTO RepairProduct(RepairCompanyId, ProductNumber, Cost, DateStart, DateEnd, IsOver)
VALUES (@RepairCompanyId, @ProductNumber, @Cost, @DateStart, @DateEnd, 0)