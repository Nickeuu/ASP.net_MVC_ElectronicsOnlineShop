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
