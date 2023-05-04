use Kursach_DB
GO 
CREATE PROCEDURE sp_CloseRent
	@RentId INT,
	@ProductNumber INT
AS
UPDATE Rent
SET IsOver = 1
WHERE Rent.Id = @RentId;

UPDATE Product
SET IsProductInWarehouse = 1
WHERE Product.Number = @ProductNumber
