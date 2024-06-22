select *

from(
	select e.EmployeeID,e.FirstName,e.LastName,e.Salary,
	DENSE_RANK ( ) OVER ( PARTITION BY Salary ORDER BY EmployeeID ) as [Rank]
	from Employees as e
	where e.Salary between 10000 and 50000
	--order by e.Salary desc
)  as a
where a.[Rank]=2
order by a.Salary desc

--12. Countries Holding 'A' 3 or More Times
SELECT C.CountryName AS[Country Name], c.IsoCode as [ISO Code]
FROM Countries AS c
WHERE C.CountryName LIKE '%A%A%A%'
ORDER BY c.IsoCode

--13. Mix of Peak and River Names
SELECT * FROM Peaks
SELECT * FROM Rivers

--16

SELECT Username, IpAddress AS [IP Addresses] FROM Users
WHERE IpAddress LIKE '___.1_%._%.___'
ORDER BY Username

--17. Show All Games with Duration & Part of the Day
SELECT [Name] as Game,
CASE
	WHEN DATEPART(HOUR, [Start])<12 THEN 'Morning'
	WHEN DATEPART(HOUR, [Start])<18 THEN 'Afternoon'
	ELSE 'Evening'
END AS [Part of the Day],
CASE
	WHEN Duration<=3 THEN 'Extra Short'
	WHEN Duration<=6 THEN 'Short'
	WHEN Duration>6 THEN 'Long'
	WHEN Duration IS NULL THEN 'Extra Long'
END AS Duration
FROM Games
ORDER BY Name, Duration

--18 ORDER TABLE

SELECT * FROM ORDERS
