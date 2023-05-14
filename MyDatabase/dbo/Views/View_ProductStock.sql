CREATE VIEW [dbo].[View_ProductStock]
	AS SELECT
	ProductModel.ProductId,ProductModel.Title,ProductModel.Stock
	FROM ProductModel;

