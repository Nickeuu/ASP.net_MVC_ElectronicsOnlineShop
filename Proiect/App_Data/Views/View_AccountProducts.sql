CREATE VIEW [dbo].[View_AccountProducts]
	AS SELECT
	AccountModel.FirstName,
	AccountModel.MiddleName,
	AccountModel.LastName,
	ProductModel.Title AS ProductTitle,
	CartItemModel.Quantity,
	CartItemModel.Price
	FROM dbo.AccountModel, dbo.ProductModel, dbo.CartItemModel;
