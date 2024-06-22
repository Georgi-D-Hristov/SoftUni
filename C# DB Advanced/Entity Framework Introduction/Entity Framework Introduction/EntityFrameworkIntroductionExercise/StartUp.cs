namespace EntityFrameworkIntroductionExercise;

using Microsoft.EntityFrameworkCore;
using MyDataBase.Infrastructure.Data;

public class StartUp
{
    public static void Main(string[] args)
    {
        using SoftUniDBContext data = new SoftUniDBContext();

        var employees = data.Employees
            .OrderBy(e => e.EmployeeId)
            .Select
            (
                e => new
                {
                    e.FirstName,
                    e.MiddleName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                }
            ).ToList();

        foreach (var employee in employees)
        {
            Console.WriteLine($"{employee.FirstName} {employee.MiddleName} {employee.LastName} {employee.JobTitle} {employee.Salary:f2}");

        }
    }
}