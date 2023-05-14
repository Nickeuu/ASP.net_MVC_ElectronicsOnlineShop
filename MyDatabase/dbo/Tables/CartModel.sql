CREATE TABLE [dbo].[CartModel] (
    [CartId]    INT IDENTITY (1, 1) NOT NULL,
    [AccountId] INT NOT NULL,
    CONSTRAINT [PK_dbo.CartModel] PRIMARY KEY CLUSTERED ([CartId] ASC), 
    CONSTRAINT [FK_CartModel_ToTable] FOREIGN KEY ([AccountId]) REFERENCES [AccountModel]([AccountId]) ON DELETE CASCADE ON UPDATE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_CartId]
    ON [dbo].[CartModel]([CartId] ASC);