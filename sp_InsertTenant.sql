use Kursach_DB
GO 
CREATE PROCEDURE sp_InsertTenant
	@FIO NVARCHAR(120),
	@Age INT,
	@Phone VARCHAR(20),
	@Gender VARCHAR(7)
AS
INSERT INTO Tenant(FIO, Age, Phone, Gender)
VALUES(@FIO, @Age, @Phone, @Gender)