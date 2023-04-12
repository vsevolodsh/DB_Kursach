CREATE VIEW PrPrGroups AS
SELECT Product.Number, Product.Name as Name, ProductGroup.Name AS ProductGroup, Product.RentCostInHour,  Product.IsProductInWarehouse
FROM Product
JOIN ProductGroup ON ProductGroup.Code = Product.Code AND ProductGroup.ProductSubcategoryCode = Product.ProductSubcategoryCode
