CREATE TRIGGER [dbo].[Trigger_ProductDelete]
    ON [dbo].[ProductModel]
    AFTER DELETE
    AS
    BEGIN
        SET NoCount ON

        DECLARE @ProductId INT
        SELECT @ProductId = DELETED.ProductId
        FROM DELETED;

        DELETE FROM dbo.CartItemModel WHERE ProductId = @ProductId;

    END