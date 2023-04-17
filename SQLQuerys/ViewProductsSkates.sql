CREATE VIEW ProductsSkates AS
SELECT PrPrGroups.Number, PrPrGroups.ProductGroup, PrPrGroups.Name, Skates.BladeSteel, Skates.Fixation, Skates.Size, PrPrGroups.RentCostInHour, PrPrGroups.IsProductInWarehouse
FROM PrPrGroups 
JOIN Skates ON Skates.ProductNumber = PrPrGroups.Number 