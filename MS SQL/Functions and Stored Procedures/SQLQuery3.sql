--06. Employees Hired Afte
select e.FirstName, e.LastName, e.HireDate, d.Name as [DeptName] from Employees as e
join Departments as d on d.DepartmentID = e.DepartmentID
where e.HireDate > '1999' and e.DepartmentID in (3, 10)
order by e.HireDate

--07. Employees With Project

select * from Employees as e
join EmployeesProjects as ep on ep.EmployeeID = e.EmployeeID
join Projects as p on p.ProjectID = ep.ProjectID
where e.HireDate> '2002-08-13'

--13. Count Mountain Ranges
--Create a query that selects:
--•	CountryCode
--•	MountainRanges
--Filter the count of the mountain ranges in the United States, Russia and Bulgaria.


SELECT C.CountryCode, COUNT(M.MountainRange) AS MountainRanges FROM Countries AS C
JOIN MountainsCountries AS MC ON MC.CountryCode = C.CountryCode
JOIN Mountains AS M ON M.Id = MC.MountainId
WHERE C.CountryCode IN ('BG', 'RU', 'US')
GROUP BY C.CountryCode

--14. Countries With or Without Rivers
SELECT TOP(5) C.CountryName, R.RiverName FROM Countries AS C
LEFT JOIN CountriesRivers AS CR ON CR.CountryCode = C.CountryCode
LEFT JOIN Rivers AS R ON R.Id = CR.RiverId
WHERE C.ContinentCode = 'AF'
ORDER BY C.CountryName

--15. Continents and Currencies
SELECT CO.ContinentName,COUNT( C.CurrencyCode) FROM Continents AS CO
JOIN Countries AS C ON C.ContinentCode = CO.ContinentCode
GROUP BY CO.ContinentName

--16
SELECT COUNT(*) AS [Count]  FROM Countries AS C
LEFT JOIN MountainsCountries AS MC ON MC.CountryCode = C.CountryCode
LEFT JOIN Mountains AS M ON M.Id = MC.MountainId
WHERE M.Id IS NULL

--17. Highest Peak and Longest River by Country
SELECT TOP(5) C.CountryName, MAX(P.Elevation) AS [HighestPeakElevation],
MAX(R.[Length]) AS [LongestRiverLength]
FROM Countries AS C
JOIN MountainsCountries AS MC ON MC.CountryCode = C.CountryCode
JOIN Mountains AS M ON M.Id = MC.MountainId
JOIN CountriesRivers AS CR ON CR.CountryCode = C.CountryCode
JOIN Rivers AS R ON R.Id = CR.RiverId
JOIN Peaks AS P ON P.MountainId = M.Id
GROUP BY C.CountryName
ORDER BY MAX(P.Elevation) DESC, MAX(R.[Length]) DESC, C.CountryName

--18. Highest Peak Name and Elevation by Country

SELECT C.CountryName,
CASE
	WHEN MAX(P.Elevation) IS NULL THEN '(no highest peak)'
	ELSE 
END,
 AS [HighestPeakElevation],
MAX(R.[Length]) AS [LongestRiverLength],
M.MountainRange AS Mountain
FROM Countries AS C
LEFT JOIN MountainsCountries AS MC ON MC.CountryCode = C.CountryCode
LEFT JOIN Mountains AS M ON M.Id = MC.MountainId
LEFT JOIN CountriesRivers AS CR ON CR.CountryCode = C.CountryCode
LEFT JOIN Rivers AS R ON R.Id = CR.RiverId
LEFT JOIN Peaks AS P ON P.MountainId = M.Id
GROUP BY C.CountryName, M.MountainRange