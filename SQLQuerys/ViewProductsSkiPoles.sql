CREATE VIEW ProductsSkiPoles AS
SELECT PrPrGroups.Number, PrPrGroups.ProductGroup, PrPrGroups.Name, SkiPoles.HandleMaterial, SkiPoles.ShaftMaterial, SkiPoles.SkiPolesLength, PrPrGroups.RentCostInHour, PrPrGroups.IsProductInWarehouse
FROM PrPrGroups 
JOIN SkiPoles ON SkiPoles.ProductNumber = PrPrGroups.Number 