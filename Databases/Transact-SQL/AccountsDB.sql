CREATE PROC usp_SelectFullNames
AS
SELECT p.FirstName + ' ' + p.LastName AS FullName
FROM Persons p
GO

EXEC usp_SelectFullNames
GO

CREATE PROC usp_CountPeopleWithBalance
	(@minBalance int = 0)
AS
	SELECT p.FirstName + ' ' + p.LastName AS FullName, a.Balance
	FROM Persons p JOIN
	Accounts a
		ON p.PersonId = a.PersonId
	WHERE a.Balance >= @minBalance
GO

EXEC usp_CountPeopleWithBalance 100
GO

CREATE FUNCTION ufn_CalculateSum(@sum money, @interest money, @months int)
  RETURNS money
AS
BEGIN
  RETURN (@sum + (@sum * @interest * @months / 12))
END
GO

SELECT dbo.ufn_CalculateSum(200, 1.5, 6)
GO

CREATE PROC usp_GetAccountInterest
	(@accountId int, @interest money)
AS
	SELECT dbo.ufn_CalculateSum(a.Balance, @interest, 1)
	FROM Accounts a
	WHERE a.AccountId = @accountId
GO

EXEC usp_GetAccountInterest 1, 1.5
GO

CREATE PROC usp_WithdrawMoney
	(@accountId int, @sum money)
AS
	IF(@sum >= 0)
	BEGIN
		BEGIN TRAN
			DECLARE @currentBalance money
			SET @currentBalance = (SELECT TOP 1 a.Balance
			FROM Accounts a
			WHERE a.AccountId = @accountId)
			IF(@currentBalance < @sum)
				PRINT 'There is no enough money to withdraw'
			ELSE
			BEGIN
				UPDATE Accounts
				SET Balance = @currentBalance - @sum
				WHERE AccountId = @accountId
			END
		COMMIT TRAN
	END
	ELSE
		PRINT 'Cannot withdraw negative sum'
GO

EXEC usp_WithdrawMoney 1, 200
GO

CREATE PROC usp_DepositMoney
	(@accountId int, @sum money)
AS
	IF(@sum > 0)
	BEGIN
		BEGIN TRAN
			DECLARE @currentBalance money
			SET @currentBalance = (SELECT TOP 1 a.Balance
			FROM Accounts a
			WHERE a.AccountId = @accountId)

			UPDATE Accounts
			SET Balance = @currentBalance + @sum
			WHERE AccountId = @accountId

		COMMIT TRAN
	END
	ELSE
		PRINT 'Cannot deposit negative sum'
GO

EXEC usp_DepositMoney 1, 200
GO

CREATE TRIGGER tr_AccountsUpdate ON Accounts FOR UPDATE
AS
  INSERT INTO Logs
  SELECT d.AccountId, d.Balance, i.Balance
  FROM deleted d, inserted i
GO

