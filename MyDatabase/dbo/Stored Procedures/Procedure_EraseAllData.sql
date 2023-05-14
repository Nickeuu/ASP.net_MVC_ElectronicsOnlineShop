CREATE PROCEDURE [dbo].[Procedure_EraseAllData]
AS
	DELETE FROM AccountModel;
	DELETE FROM CartItemModel;
	DELETE FROM CartModel;
	DELETE FROM ProductModel;
	DELETE FROM View_ProductStock;