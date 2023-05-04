use Kursach_DB
GO
CREATE VIEW TenantInfo AS
SELECT Tenant.Id, Tenant.Fio, Tenant.Phone, Tenant.Age, Tenant.Gender, STRING_AGG(RentInfo.Id,', ') AS RentId, RentInfo.IsOver AS ActiveRent 
FROM Tenant 
JOIN Rent ON Rent.TenantId = Tenant.Id
JOIN RentInfo ON RentInfo.Id= Rent.Id	
GROUP BY Tenant.Id, Tenant.FIO, Tenant.Phone, Tenant.Age, Tenant.Gender, RentInfo.IsOver 
