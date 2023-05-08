use Kursach_DB
GO 
CREATE PROCEDURE sp_InsertBooking
	@BookingId INT,
	@TenantId INT,
	@DateEnd Datetime,
	@ProductNumber INT
AS
INSERT INTO Booking (TenantId, DateEnd)
VALUES(@TenantId,  @DateEnd)

INSERT INTO ProductBooking (BookingId, ProductNumber)
VALUES (@BookingId, @ProductNumber)

UPDATE Product
SET IsProductInWarehouse = 0
WHERE Product.Number = @ProductNumber