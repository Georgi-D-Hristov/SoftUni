--01. Employees with Salary Above 35000
CREATE PROC usp_GetEmployeesSalaryAbove35000 
AS
	SELECT E.FirstName AS [First Name],
	E.LastName AS [Last Name]
	FROM Employees AS E
	WHERE E.Salary>35000

	EXEC usp_GetEmployeesSalaryAbove35000

--02. Employees with Salary Above Number
CREATE PROC usp_GetEmployeesSalaryAboveNumber
(@number DECIMAL(18,4))
AS
	SELECT E.FirstName AS [First Name],
	E.LastName AS [Last Name]
	FROM Employees AS E
	WHERE E.Salary>=@number

EXEC usp_GetEmployeesSalaryAboveNumber 35000
DROP PROC usp_GetEmployeesSalaryAboveNumber

--03. Town Names Starting With
CREATE PROC usp_GetTownsStartingWith
@string VARCHAR(30)
AS
	DECLARE @param varchar(30)
	set @param = CONCAT(@string, '%')
	SELECT Name FROM Towns
	WHERE Name LIKE @param


EXEC usp_GetTownsStartingWith 'B'

--04. Employees from Town
CREATE PROC usp_GetEmployeesFromTown 
@townName VARCHAR(30)
AS
	SELECT E.FirstName AS [First Name],
	E.LastName AS [Last Name]
	FROM Employees AS E
	JOIN Addresses AS A ON A.AddressID = E.AddressID
	JOIN Towns AS T ON T.TownID = A.TownID
	WHERE T.Name = @townName

	exec usp_GetEmployeesFromTown 'London'

--05. Salary Level Function

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4)) 
RETURNS NVARCHAR(10)
AS
BEGIN
	DECLARE @salaryLevel nvarchar(10)

	if (@salary <30000)
		set @salaryLevel = 'Low'
	else if (@salary between 30000 and 50000)
		set @salaryLevel = 'Average'
	else 
		set @salaryLevel = 'High'

	return @salaryLevel
END

select Salary, dbo.ufn_GetSalaryLevel(Salary) as [Salary Level]
from Employees

--06. Employees by Salary Level
create proc usp_EmployeesBySalaryLevel 
@salaryLevel nvarchar(10)
as
	select FirstName as [First Name], LastName as [Last Name]
	from Employees
	where dbo.ufn_GetSalaryLevel(Salary) = @salaryLevel

	exec usp_EmployeesBySalaryLevel 'High'

--07. Define Function

CREATE FUNCTION ufn_IsWordComprised
(
    @setOfLetters NVARCHAR(MAX),
    @word NVARCHAR(MAX)
)
RETURNS BIT
AS
BEGIN
    
    DECLARE @i INT = 1;
    DECLARE @wordLen int = len(@word) 

	while(@i<=@wordLen)
	begin
		if (CHARINDEX(SUBSTRING(@word, @i, 1), @setOfLetters) =0)
			return 0
		set @i = @i+1
	end
 return 1
END

--09. Find Full Name
create proc usp_GetHoldersFullName 
as


select concat(FirstName, ' ', LastName) as [Full Name]
from AccountHolders

exec usp_GetHoldersFullName

--10. People with Balance Higher Than
create proc usp_GetHoldersWithBalanceHigherThan (@minBalance decimal(10,2))
as
select ah.FirstName as [First Name],
ah.LastName as [Last Name]
from AccountHolders as ah
join Accounts as a on a.AccountHolderId = ah.Id
group by ah.FirstName, ah.LastName
having sum(a.Balance)>@minBalance
order by ah.FirstName, ah.LastName

exec usp_GetHoldersWithBalanceHigherThan 124

--11. Future Value Function
--


create function ufn_CalculateFutureValue 
(
@sum decimal(12,4),
@yearlyInterestRate float,
@numberOfYears int
)
returns decimal(12,4)
as
begin

	return  @sum * (POWER((1 + @yearlyInterestRate), @numberOfYears))
	
end

select dbo.ufn_CalculateFutureValue(123.12, 0.1,5)

--12. Calculating Interest
create proc usp_CalculateFutureValueForAccount 
(@accountId int, @interest float)

as


	select a.Id as [Account Id],
	ah.FirstName as [First Name],
	ah.LastName [Last Name],
	a.Balance as [Current Balance],
	dbo.ufn_CalculateFutureValue (a.Balance, @interest, 5) as [Balance in 5 years]
	from Accounts as a
	join AccountHolders as ah on ah.Id = a.AccountHolderId
	where a.Id = @accountId


exec dbo.usp_CalculateFutureValueForAccount 1, 0.1