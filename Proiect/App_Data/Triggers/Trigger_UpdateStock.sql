CREATE TRIGGER [Trigger_UpdateStock]
	ON [dbo].[CartItemModel]
	AFTER INSERT
	AS
	BEGIN
		SET NOCOUNT ON

		DECLARE @Stock INT
		SELECT @Stock = dbo.ProductModel.Stock
		FROM dbo.ProductModel;

		SELECT @Stock -= inserted.Quantity
		FROM inserted;

		UPDATE dbo.ProductModel
		SET Stock = @Stock
		FROM inserted
		WHERE ProductId = inserted.ProductId;

	END