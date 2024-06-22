namespace EntityFrameworkIntroductionExercise;

using EntityFrameworkIntroductionExercise.Data;
using EntityFrameworkIntroductionExercise.Data.Models;
using Microsoft.EntityFrameworkCore;

public class StartUp
{
    public static void Main(string[] args)
    {
        var dbContext = new SoftUniContext();
         
        var employees = dbContext.Employees
            .Select
            (
            
            )
    }
}
