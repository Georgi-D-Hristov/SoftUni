namespace SoftUni
{
    using Microsoft.EntityFrameworkCore;
    using SoftUni.Data;
    using System.Text;
    using System.Threading.Channels;

    public class StartUp

    {
        public static void Main(string[] args)
        {
            using SoftUniContext data = new SoftUniContext();

            // 3.Employees Full Information
            // Console.WriteLine(GetEmployeesFullInformation(data));

            //04. Employees with Salary Over 50 000

            // Console.WriteLine(GetEmployeesWithSalaryOver50000(data));

            //05. Employees from Research and Development
            Console.WriteLine(GetEmployeesFromResearchAndDevelopment(data));
           
        }

        public static string  GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees =  context
                .Employees
                .Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.Departments.Select(d=> new { d.Name }),
                        e.Salary,
                        e.Department
                    })
                .Where(e=>e.Department.Name== "Research" || e.Department.Name == "Development")
                .OrderBy(e=>e.Salary)
                .ThenByDescending(e=>e.FirstName)
            
                .ToList();

            var sb = new StringBuilder();
            foreach (var employee in employees) 
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from Research and Development - ${employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string  GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees =  context
                            .Employees
                            .Select(e => new
                            {
                                e.FirstName,
                                e.Salary
                            })
                            .Where(e => e.Salary > 50000)
                            .OrderBy(e => e.FirstName)
                           .ToList()
                           ;
         

            var sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
          

            //var employees = context.Employees
            //    .OrderBy(e => e.EmployeeId)
            //    .Select
            //    (
            //    e => new
            //    {
            //        e.FirstName,
            //        e.MiddleName,
            //        e.LastName,
            //        e.JobTitle,
            //        e.Salary
            //    }).ToList();
            //var sb = new StringBuilder();
            //foreach (var employee in employees)
            //{
            //    sb.AppendLine($"{employee.FirstName} {employee.MiddleName} {employee.LastName} {employee.JobTitle} {employee.Salary:f2}");
            //}

            //return sb.ToString().TrimEnd();

            return string.Join(Environment.NewLine, context.Employees
                .Select(e=> $"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}"));
        }
    }
}
