
CREATE VIEW RentInfo AS
SELECT Rent.Id AS Id, Tenant.FIO AS TenantName, STRING_AGG(Product.Number,', ') AS ProductsNumbers, Rent.DateStart AS DateStart, 
Rent.DateEnd AS DateEnd, Rent.TotalRentCost AS RentCost, Rent.TotalDepositCost AS Deposit, Rent.IsOver
FROM ProductRent
JOIN Product ON Product.Number = ProductRent.ProductNumber
JOIN Rent ON Rent.Id = ProductRent.RentId
JOIN Tenant ON Tenant.Id = Rent.TenantId
GROUP BY Rent.Id, Tenant.FIO, Rent.TotalRentCost, Rent.DateStart, Rent.DateEnd , Rent.TotalDepositCost, Rent.IsOver