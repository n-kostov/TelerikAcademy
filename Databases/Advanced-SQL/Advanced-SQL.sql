SELECT e.FirstName + ' ' + e.LastName AS FullName, e.Salary
FROM Employees e
WHERE E.Salary = 
	(SELECT MIN(e2.Salary) FROM Employees e2)

SELECT e.FirstName + ' ' + e.LastName AS FullName, e.Salary
FROM Employees e
WHERE e.Salary <=
	(SELECT MIN(e2.Salary) FROM Employees e2) * 1.1

SELECT e.FirstName + ' ' + e.LastName AS FullName, e.Salary, d.Name
FROM Employees e,Departments d
WHERE e.Salary = 
  (SELECT MIN(Salary) FROM Employees e1
   WHERE e1.DepartmentID = e.DepartmentID) AND
   e.DepartmentID = d.DepartmentID

SELECT AVG(Salary) AS AverageSalary
FROM Employees
WHERE DepartmentID = 1

SELECT MIN(d.Name), AVG(Salary) AS AverageSalary
FROM Employees e, Departments d
WHERE d.Name = 'SALES' AND e.DepartmentID = d.DepartmentID

SELECT MIN(d.Name), COUNT(e.DepartmentID) AS Employees
FROM Employees e, Departments d
WHERE d.Name = 'SALES' AND e.DepartmentID = d.DepartmentID

SELECT COUNT(DepartmentID) AS EmployeesWithManager
FROM Employees
WHERE ManagerID IS NOT NULL

SELECT COUNT(DepartmentID) AS EmployeesWithoutManager
FROM Employees
WHERE ManagerID IS NULL

SELECT d.Name, AVG(e.Salary) AS AverageSalary
FROM Employees e JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name

SELECT d.Name, t.Name, COUNT(e.DepartmentID) AS Employees
FROM Employees e JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
JOIN Addresses a
	ON a.AddressID = e.AddressID
JOIN Towns t
	ON t.TownID = a.TownID
GROUP BY d.Name, t.Name

SELECT e.FirstName, e.LastName
FROM Employees e JOIN Employees e1
	ON e1.ManagerID = e.EmployeeID OR
		e1.ManagerID IS NULL
GROUP BY e.EmployeeID, e.FirstName, e.LastName
HAVING COUNT(*) = 5

SELECT e.FirstName + ' ' + e.LastName AS FullName, ISNULL(e1.FirstName + ' ' + e1.LastName, 'NO MANAGER') AS Manager
FROM Employees e JOIN Employees e1
	ON e.ManagerID = e1.EmployeeID
UNION
SELECT e.FirstName + ' ' + e.LastName AS FullName, 'NO MANAGER' AS Manager
FROM Employees e
WHERE e.ManagerID IS NULL
ORDER BY Manager

SELECT e.FirstName, e.LastName
FROM Employees e
WHERE LEN(e.LastName) = 5

SELECT FORMAT ( GETDATE(), 'dd.MM.yyyy HH:mm:ss:ff', 'en-US' ) AS DateConvert

CREATE TABLE Users (
  UserID int IDENTITY,
  UserName nvarchar(100) NOT NULL UNIQUE,
  Password nvarchar(100),
  FullName nvarchar(100) NOT NULL,
  LastLogin date,
  CONSTRAINT PK_Users PRIMARY KEY(UserID),
  CONSTRAINT chk_User CHECK (LEN(Password) >= 5)
)
GO

CREATE VIEW Logged AS
SELECT * FROM USERS
WHERE FORMAT(LastLogin, 'yyyy-MM-dd') = FORMAT(GETDATE(), 'yyyy-MM-dd')
GO

CREATE TABLE Groups (
  GroupID int IDENTITY,
  Name nvarchar(100) NOT NULL UNIQUE,
  CONSTRAINT PK_Groups PRIMARY KEY(GroupID)
)
GO

ALTER TABLE USERS ADD GroupID int
GO

ALTER TABLE USERS
ADD CONSTRAINT FK_Users_Groups
  FOREIGN KEY (GroupID)
  REFERENCES Groups(GroupID)
GO

INSERT INTO Groups (Name)
VALUES ('Sailor'), ('Thief')

INSERT INTO Users(UserName, Password, FullName, LastLogin, GroupID)
VALUES ('Sailor I AM', 'SAIL ON THE WATER', 'PIRATE', '2001-06-06', 4), 
	('Thief I AM', 'GOT YA POCKET', 'MoneyStealer', '2009-12-21', 3)

UPDATE USERS
SET GroupID = 5
FROM Users u
WHERE u.UserName = 'Thief I AM'

DELETE
FROM Users
WHERE UserName LIKE 'qwerty%'

DELETE
FROM Groups
WHERE Name = 'Administrator'

INSERT INTO Users(UserName, Password, FullName)
SELECT SUBSTRING(e.FirstName, 1, 1) + LOWER(e.LastName) + ' ' + LOWER(e.FirstName),
	SUBSTRING(e.FirstName, 1, 1) + LOWER(e.LastName) + SUBSTRING(e.FirstName, 1, 1) + LOWER(e.LastName),
	e.FirstName + ' ' + e.LastName
FROM Employees e

UPDATE USERS
SET Password = NULL
FROM Users u
WHERE u.LastLogin > '2010-03-10'

DELETE USERS
WHERE Password IS NULL

SELECT d.Name, e.JobTitle, AVG(e.Salary)
FROM Employees e JOIN
	Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle

SELECT e.FirstName + ' ' + e.LastName AS FullName,
	d1.Department, d1.JobTitle, d1.Salary
FROM Employees e JOIN 
	(SELECT d.DepartmentID, d.Name AS Department, e1.JobTitle, MIN(e1.Salary) AS Salary
	FROM Employees e1 JOIN
		Departments d
		ON e1.DepartmentID = d.DepartmentID
	GROUP BY d.DepartmentID, d.Name, e1.JobTitle) d1
	ON e.DepartmentID = d1.DepartmentID
		AND e.Salary = d1.Salary
		AND e.JobTitle = d1.JobTitle

SELECT TOP 1 n.Name, n.EmployeesCount
FROM
	(SELECT t.Name, COUNT(*) AS EmployeesCount
	FROM Employees e JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
	JOIN Addresses a
		ON a.AddressID = e.AddressID
	JOIN Towns t
		ON t.TownID = a.TownID
	GROUP BY t.Name) n
ORDER BY n.EmployeesCount DESC

SELECT t.Name AS Town, COUNT(*) AS ManagersCount
FROM Employees e JOIN Employees m
	ON e.ManagerID = m.EmployeeID
		OR (e.ManagerID IS NULL AND m.ManagerID IS NULL AND e.EmployeeID = m.EmployeeID)
JOIN Addresses a
	ON a.AddressID = e.AddressID
JOIN Towns t
	ON t.TownID = a.TownID
GROUP BY t.Name

CREATE TABLE WorkHours(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT NOT NULL,
CurrentDate DATETIME NOT NULL,
Task NVARCHAR(50),
WorkedHours INT NOT NULL,
Comments NVARCHAR(100),
CONSTRAINT FK_WorkHours_Employees FOREIGN KEY(EmployeeId)
REFERENCES Employees(EmployeeId) ON DELETE CASCADE
)
GO

CREATE TABLE Commands(
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(10)
)
GO

INSERT INTO Commands(Name)
VALUES ('Insert'), ('Update'), ('Delete')

CREATE TABLE WorkHoursLogs(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT NOT NULL,
CurrentDate DATETIME NOT NULL,
Task NVARCHAR(50),
WorkedHours INT NOT NULL,
Comments NVARCHAR(100),
CommandId INT NOT NULL,
CONSTRAINT FK_WorkHoursLogs_Employees FOREIGN KEY(EmployeeId)
REFERENCES Employees(EmployeeId) ON DELETE CASCADE,
CONSTRAINT FK_WorkHoursLogs_Commands FOREIGN KEY(CommandId)
REFERENCES Commands(Id)
)
GO

CREATE TRIGGER tr_WorkHoursInsert ON WorkHours FOR INSERT
AS
  INSERT INTO WorkHoursLogs(EmployeeId, CurrentDate, Task, WorkedHours, Comments, CommandId)
  SELECT EmployeeId, CurrentDate, Task, WorkedHours, Comments, 1 FROM inserted
GO

CREATE TRIGGER tr_WorkHoursUpdate ON WorkHours FOR UPDATE
AS
  INSERT INTO WorkHoursLogs(EmployeeId, CurrentDate, Task, WorkedHours, Comments, CommandId)
  SELECT EmployeeId, CurrentDate, Task, WorkedHours, Comments, 2 FROM deleted
  INSERT INTO WorkHoursLogs(EmployeeId, CurrentDate, Task, WorkedHours, Comments, CommandId)
  SELECT EmployeeId, CurrentDate, Task, WorkedHours, Comments, 2 FROM inserted
GO

CREATE TRIGGER tr_WorkHoursDelete ON WorkHours FOR DELETE
AS
  INSERT INTO WorkHoursLogs(EmployeeId, CurrentDate, Task, WorkedHours, Comments, CommandId)
  SELECT EmployeeId, CurrentDate, Task, WorkedHours, Comments, 3 FROM deleted
GO

INSERT INTO WorkHours(EmployeeId, CurrentDate, WorkedHours)
VALUES (1, '2004-04-04', 4), (1, '2005-05-05', 5), (2, '2006-06-06', 6)

UPDATE WorkHours
SET WorkedHours = 8
FROM WorkHours
WHERE EmployeeId = 1

DELETE FROM WorkHours
WHERE EmployeeId = 2

BEGIN TRAN
ALTER TABLE EmployeesProjects
   DROP CONSTRAINT FK_EmployeesProjects_Employees

ALTER TABLE EmployeesProjects
   ADD CONSTRAINT FK_EmployeesProjects_Employees_Cascade
   FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID) ON DELETE CASCADE

ALTER TABLE EmployeesProjects
   DROP CONSTRAINT FK_EmployeesProjects_Projects

ALTER TABLE EmployeesProjects
   ADD CONSTRAINT FK_EmployeesProjects_Projects_Cascade
   FOREIGN KEY (ProjectID) REFERENCES Projects(ProjectID) ON DELETE CASCADE

ALTER TABLE Departments
   DROP CONSTRAINT FK_Departments_Employees

ALTER TABLE Departments
   ADD CONSTRAINT FK_Departments_Employees_Cascade
   FOREIGN KEY (ManagerID) REFERENCES Employees(EmployeeID) ON DELETE CASCADE

DELETE FROM Employees
WHERE DepartmentID IN
(SELECT e1.DepartmentID FROM Employees e1
JOIN Departments d
	ON e1.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales')
ROLLBACK TRAN

BEGIN TRAN
DROP TABLE EmployeesProjects
ROLLBACK TRAN

BEGIN TRAN

CREATE TABLE #TempEmployeesProjects( EmployeeID int, ProjectID int ) 
INSERT INTO #TempEmployeesProjects (EmployeeID, ProjectID) 
SELECT e.EmployeeID, e.ProjectID 
FROM EmployeesProjects e

DROP TABLE EmployeesProjects

CREATE TABLE EmployeesProjects( EmployeeID int, ProjectID int ) 
INSERT INTO EmployeesProjects (EmployeeID, ProjectID) 
SELECT EmployeeID, ProjectID 
FROM #TempEmployeesProjects

DROP TABLE #TempEmployeesProjects

COMMIT TRAN