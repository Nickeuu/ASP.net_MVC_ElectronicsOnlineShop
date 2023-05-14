CREATE TABLE [dbo].[AccountModel] (
    [AccountId]  INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]  NVARCHAR (50) NOT NULL,
    [MiddleName] NVARCHAR (50) NULL,
    [LastName]   NVARCHAR (50) NOT NULL,
    [Password]   NVARCHAR (100) NOT NULL,
    [Email]      NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_dbo.AccountModel] PRIMARY KEY CLUSTERED ([AccountId]), 
    CONSTRAINT [AK_AccountModel_Email] UNIQUE ([Email])
);


GO
CREATE TRIGGER [Trigger_AccountDelete]
	ON [dbo].[AccountModel]
	AFTER DELETE
	AS
	BEGIN
		SET NOCOUNT ON

		DECLARE @AccountId INT
		SELECT @AccountId = DELETED.AccountId
		FROM DELETED;

		DECLARE @CartId INT
		SELECT @CartId = dbo.CartModel.CartId
		FROM dbo.CartModel
		WHERE dbo.CartModel.AccountId = @AccountId;
		
		DELETE FROM dbo.CartItemModel WHERE CartId = @CartId
		DELETE FROM dbo.CartModel WHERE AccountId = @AccountId
		
	END


GO
CREATE TRIGGER [Trigger_AccountInsert]
	ON [dbo].[AccountModel]
	AFTER INSERT
	AS
	BEGIN
		SET NOCOUNT ON
		DECLARE @AccountId INT
		SELECT @AccountId = INSERTED.AccountId
		FROM INSERTED

		INSERT INTO dbo.CartModel(AccountId)
		VALUES(@AccountId)
	END
