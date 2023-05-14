CREATE TABLE [dbo].[ProductModel] (
    [ProductId]                INT            IDENTITY (1, 1) NOT NULL,
    [Title]                    NVARCHAR (50) NOT NULL,
    [Summary]                  TEXT NULL,
    [Price]                    REAL           NOT NULL,
    [Stock]                    INT            NOT NULL,
    CONSTRAINT [PK_dbo.ProductModel] PRIMARY KEY CLUSTERED ([ProductId] ASC)
);
GO

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