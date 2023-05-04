use Kursach_DB
GO 
CREATE PROCEDURE sp_DecommisProduct
	@ProductNumber INT,
	@DecommissionedDate DATE,
	@Reason NVARCHAR(250)
AS

UPDATE Product
SET IsProductInWarehouse = 0
WHERE Product.Number = @ProductNumber;

INSERT DecommissionedProduct(ProductNumber, DecommissionedDate, Reason)
VALUES
(@ProductNumber, @DecommissionedDate, @Reason)