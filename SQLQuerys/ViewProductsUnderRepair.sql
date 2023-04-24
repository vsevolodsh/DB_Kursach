CREATE VIEW ProductsUnderRepair AS
SELECT PrPrGroups.Number, PrPrGroups.ProductGroup, PrPrGroups.Name, RepairCompany.Name AS RepairCompanyName, RepairProduct.Cost, RepairProduct.StartDate,  RepairProduct.EndDate
FROM RepairProduct 
JOIN PrPrGroups ON PrPrGroups.Number = RepairProduct.ProductNumber 
JOIN RepairCompany ON RepairCompany.Id =  RepairProduct.RepairCompanyId