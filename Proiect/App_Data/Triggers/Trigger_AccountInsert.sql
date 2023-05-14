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
