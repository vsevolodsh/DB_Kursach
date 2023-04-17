
CREATE VIEW BookedProducts AS
SELECT Booking.Id, Tenant.FIO, STRING_AGG(Product.Number,', ') AS ProductsNumbers, Booking.DateEnd
FROM ProductBooking
JOIN Product ON Product.Number = ProductBooking.ProductNumber
JOIN Booking ON Booking.Id = ProductBooking.BookingId
JOIN Tenant ON Tenant.Id = Booking.TenantId
GROUP BY Booking.Id, Tenant.FIO, Booking.DateEnd