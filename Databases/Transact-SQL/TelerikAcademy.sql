CREATE FUNCTION fn_ContainsLetters(
	@name NVARCHAR(50),
	@letters NVARCHAR(50))
	RETURNS BIT
AS
BEGIN
	DECLARE @contains BIT
	SET @contains = 1
	DECLARE @currentLetter VARCHAR(1)
	DECLARE @count INT
	SET @count = 1
	IF(@name IS NULL OR @name = '')
		RETURN 0
	WHILE(@count <= LEN(@name))
	BEGIN
		SET @currentLetter = SUBSTRING(@name, @count, 1);
		IF(CHARINDEX(@currentLetter, @letters, 0) = 0)
		BEGIN
			SET @contains = 0
		END
		SET @count = @count + 1
	END

	RETURN @contains
END
GO

CREATE PROC usp_FindFirstNames(@lettersToSearch NVARCHAR(50))
AS
DECLARE @valid bit
SET @valid = 0
                                       
SELECT e.FirstName
FROM Employees e
WHERE 1 = 
(SELECT dbo.fn_ContainsLetters(
	e.FirstName,
	@lettersToSearch))
GO

CREATE PROC usp_FindMiddleNames(@lettersToSearch NVARCHAR(50))
AS
DECLARE @valid bit
SET @valid = 0
                                       
SELECT e.MiddleName
FROM Employees e
WHERE 1 = 
(SELECT dbo.fn_ContainsLetters(
	e.MiddleName,
	@lettersToSearch))
GO

CREATE PROC usp_FindLastNames(@lettersToSearch NVARCHAR(50))
AS
DECLARE @valid bit
SET @valid = 0
                                       
SELECT e.LastName
FROM Employees e
WHERE 1 = 
(SELECT dbo.fn_ContainsLetters(
	e.LastName,
	@lettersToSearch))
GO

CREATE PROC usp_FindTownNames(@lettersToSearch NVARCHAR(50))
AS
DECLARE @valid bit
SET @valid = 0
                                       
SELECT t.Name
FROM Towns t
WHERE 1 = 
(SELECT dbo.fn_ContainsLetters(
	t.Name,
	@lettersToSearch))
GO

CREATE PROC usp_CombineResults(@lettersToSearch NVARCHAR(50))
AS
CREATE TABLE #results (Name VARCHAR(50))

INSERT INTO #results
   EXEC usp_FindFirstNames @lettersToSearch
INSERT INTO #results
   EXEC usp_FindMiddleNames @lettersToSearch
INSERT INTO #results
   EXEC usp_FindLastNames @lettersToSearch
INSERT INTO #results
   EXEC usp_FindTownNames @lettersToSearch

SELECT *
FROM #results
GO

EXEC usp_CombineResults 'oistmiahf'

DECLARE empCursor CURSOR READ_ONLY FOR
        SELECT e.FirstName, e.LastName, t.Name,
                o.FirstName, o.LastName
        FROM Employees e
                INNER JOIN Addresses a
                        ON a.AddressID = e.AddressID
                INNER JOIN Towns t
                        ON t.TownID = a.TownID,
        Employees o
                INNER JOIN Addresses a1
                        ON a1.AddressID = o.AddressID
                INNER JOIN Towns t1
                        ON t1.TownID = a1.TownID               
 
        OPEN empCursor
        DECLARE @firstName1 NVARCHAR(50)
        DECLARE @lastName1 NVARCHAR(50)
        DECLARE @town NVARCHAR(50)
        DECLARE @firstName2 NVARCHAR(50)
        DECLARE @lastName2 NVARCHAR(50)
        FETCH NEXT FROM empCursor
                INTO @firstName1, @lastName1, @town, @firstName2, @lastName2
 
        WHILE @@FETCH_STATUS = 0
                BEGIN
                        PRINT @firstName1 + ' ' + @lastName1 +
                                '     ' + @town + '      ' + @firstName2 + ' ' + @lastName2
                        FETCH NEXT FROM empCursor
                                INTO @firstName1, @lastName1, @town, @firstName2, @lastName2
                END
 
        CLOSE empCursor
        DEALLOCATE empCursor
GO

CREATE TABLE UsersTowns (
        ID INT IDENTITY,
        FullName NVARCHAR(50),
        TownName NVARCHAR(50)
)
INSERT INTO UsersTowns
SELECT e.FirstName + ' ' + e.LastName, t.Name
                FROM Employees e
                        INNER JOIN Addresses a
                                ON a.AddressID = e.AddressID
                        INNER JOIN Towns t
                                ON t.TownID = a.TownID
                GROUP BY t.Name, e.FirstName, e.LastName
 

DECLARE @name NVARCHAR(50)
        DECLARE @town NVARCHAR(50)
 
        DECLARE empCursor1 CURSOR READ_ONLY FOR
                SELECT DISTINCT ut.TownName
                        FROM UsersTowns ut     
 
        OPEN empCursor1
        FETCH NEXT FROM empCursor1
                INTO @town
 
                WHILE @@FETCH_STATUS = 0
                BEGIN
                        PRINT @town
 
                        DECLARE empCursor2 CURSOR READ_ONLY FOR
                                SELECT ut.FullName
                                FROM UsersTowns ut
                                        WHERE ut.TownName = @town
                        OPEN empCursor2
                       
                        FETCH NEXT FROM empCursor2
                                INTO @name
                               
                                WHILE @@FETCH_STATUS = 0
                                BEGIN
                                        PRINT '   ' + @name
                                        FETCH NEXT FROM empCursor2 INTO @name
                                END
 
                                CLOSE empCursor2
                                DEALLOCATE empCursor2
                        FETCH NEXT FROM empCursor1 INTO @town
                END
 
        CLOSE empCursor1
        DEALLOCATE empCursor1

GO

DECLARE @name nvarchar(MAX);
SET @name = N'';
SELECT @name += e.FirstName + ' ' + E.LastName + N','
FROM Employees e
SELECT LEFT(@name,LEN(@name)-1);