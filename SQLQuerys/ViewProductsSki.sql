CREATE VIEW ProductsSkis AS
SELECT PrPrGroups.Number, PrPrGroups.ProductGroup, PrPrGroups.Name, Ski.RidingStyle, Ski.SkiLength, PrPrGroups.RentCostInHour, PrPrGroups.IsProductInWarehouse
FROM PrPrGroups 
JOIN Ski ON Ski.ProductNumber = PrPrGroups.Number 