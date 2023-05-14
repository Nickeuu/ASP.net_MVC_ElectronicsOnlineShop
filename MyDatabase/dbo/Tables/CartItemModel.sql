CREATE TABLE [dbo].[CartItemModel] (
    [CartItemId] INT  IDENTITY (1, 1) NOT NULL,
    [ProductId]  INT  NOT NULL,
    [CartId]     INT  NOT NULL,
    [Quantity]   INT  NOT NULL,
    [Price]      INT NULL, 
    CONSTRAINT [PK_CartItemModel] PRIMARY KEY ([CartItemId]), 
    CONSTRAINT [FK_CartItemModel_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [ProductModel]([ProductId]) ON DELETE CASCADE ON UPDATE CASCADE, 
    CONSTRAINT [FK_CartItemModel_CartId] FOREIGN KEY ([CartId]) REFERENCES [CartModel]([CartId]) ON DELETE CASCADE ON UPDATE CASCADE
);


GO

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
		FROM inserted,dbo.ProductModel
		WHERE dbo.ProductModel.ProductId = inserted.ProductId;

	END
