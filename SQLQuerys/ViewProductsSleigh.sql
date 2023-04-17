CREATE VIEW ProductsSleigh AS
SELECT PrPrGroups.Number, PrPrGroups.ProductGroup, PrPrGroups.Name, Sleigh.Construction, Sleigh.RunnersType, Sleigh.MaxLoad, PrPrGroups.RentCostInHour, PrPrGroups.IsProductInWarehouse
FROM PrPrGroups 
JOIN Sleigh ON Sleigh.ProductNumber = PrPrGroups.Number 