use Kursach_DB
GO 
CREATE PROCEDURE sp_ReturnProductFromRepair
	@ProductNumber INT
AS

UPDATE RepairProduct 
SET IsOver = 1
WHERE RepairProduct.ProductNumber = @ProductNumber;

UPDATE Product
SET IsProductInWarehouse = 1
WHERE Product.Number = @ProductNumber

