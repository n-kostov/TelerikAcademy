SELECT * FROM Departments

SELECT Name FROM Departments

SELECT FirstName + ' ' + LastName AS FullName, Salary FROM Employees

SELECT FirstName + ' ' + LastName AS FullName FROM Employees

SELECT FirstName + ' ' + LastName AS FullName, 
	FirstName + '.' + LastName + '@telerik.com' AS [Full Email Addresses] FROM Employees

SELECT DISTINCT Salary FROM Employees

SELECT * FROM Employees
WHERE JobTitle = 'Sales Representative'

SELECT FirstName + ' ' + LastName AS FullName FROM Employees
WHERE FirstName LIKE 'SA%'

SELECT FirstName + ' ' + LastName AS FullName FROM Employees
WHERE LastName LIKE '%EI%'

SELECT FirstName + ' ' + LastName AS FullName, Salary FROM Employees
WHERE Salary BETWEEN 20000 AND 30000

SELECT FirstName + ' ' + LastName AS FullName, Salary FROM Employees
WHERE Salary IN(25000,14000,12500,23600)

SELECT FirstName + ' ' + LastName AS FullName FROM Employees
WHERE ManagerID IS NULL

SELECT FirstName + ' ' + LastName AS FullName, Salary FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

SELECT TOP 5 FirstName + ' ' + LastName AS FullName, Salary FROM Employees
ORDER BY Salary DESC

SELECT e.FirstName + ' ' + e.LastName AS FullName, ad.AddressText FROM Employees e
JOIN Addresses ad
ON E.AddressID = ad.AddressID

SELECT e.FirstName + ' ' + e.LastName AS FullName, ad.AddressText FROM Employees e, Addresses ad
WHERE E.AddressID = AD.AddressID

SELECT e.FirstName + ' ' + e.LastName AS FullName, m.FirstName + ' ' + m.LastName AS Manager 
FROM Employees e LEFT OUTER JOIN Employees m
ON e.ManagerID = m.EmployeeID

SELECT e.FirstName + ' ' + e.LastName AS FullName, m.FirstName + ' ' + m.LastName AS Manager, 
ad.AddressText 
FROM Employees e LEFT OUTER JOIN Employees m 
ON e.ManagerID = m.EmployeeID
JOIN Addresses ad
ON e.AddressID = ad.AddressID

SELECT Name FROM Departments
UNION
SELECT Name FROM Towns

SELECT e.FirstName + ' ' + e.LastName AS FullName, m.FirstName + ' ' + m.LastName AS Manager 
FROM Employees e RIGHT OUTER JOIN Employees m
ON e.ManagerID = m.EmployeeID

SELECT e.FirstName + ' ' + e.LastName AS FullName, m.FirstName + ' ' + m.LastName AS Manager 
FROM Employees e LEFT OUTER JOIN Employees m
ON e.ManagerID = m.EmployeeID

SELECT e.FirstName + ' ' + e.LastName AS FullName, d.Name, e.HireDate
FROM Employees e JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE (d.Name = 'SALES' OR D.Name = 'FINANCE') AND
	(e.HireDate BETWEEN '1995/01/01' AND '2005/01/01')