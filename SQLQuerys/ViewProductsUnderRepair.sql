CREATE VIEW ProductsUnderRepair AS
SELECT PrPrGroups.Number, PrPrGroups.ProductGroup, PrPrGroups.Name, RepairCompany.Name AS RepairCompanyName, RepairProduct.Cost, RepairProduct.DateStart,  RepairProduct.DateEnd, 
RepairProduct.IsOver
FROM RepairProduct 
JOIN PrPrGroups ON PrPrGroups.Number = RepairProduct.ProductNumber 
JOIN RepairCompany ON RepairCompany.Id =  RepairProduct.RepairCompanyId