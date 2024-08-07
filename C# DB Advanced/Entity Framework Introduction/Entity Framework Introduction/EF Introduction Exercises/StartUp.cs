﻿namespace SoftUni
{
    using Microsoft.EntityFrameworkCore;
    using SoftUni.Data;
    using SoftUni.Models;
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
            //Console.WriteLine(GetEmployeesFromResearchAndDevelopment(data));

            //06. Adding a New Address and Updating Employee
            //Console.WriteLine(AddNewAddressToEmployee(data));

            //07. Employees and Projects
            // Console.WriteLine(GetEmployeesInPeriod(data));

            //08. Addresses by Town
            Console.WriteLine(GetAddressesByTown(data));
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Take(10)
                .Select(a => new
                {
                   Adress = a.AddressText,
                   Town = a.Town.Name,
                   EmployeeCount = a.Employees.Count
                }).ToList();

            var sb = new StringBuilder();
            foreach (var item in addresses)
            {
                sb.AppendLine($"{item.Adress}, {item.Town} - {item.EmployeeCount}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Take(10)
                .Select(e => new
                {
                    EmployeeNames = $"{e.FirstName} {e.LastName}",
                    ManagerNames = $"{e.Manager.FirstName} {e.Manager.LastName}",
                    Projects = e.EmployeesProjects
                        .Where(ep =>
                            ep.Project.StartDate.Year >= 2001 &&
                            ep.Project.StartDate.Year <= 2003
                        )
                        .Select(ep => new
                        {
                            ProjectName = ep.Project.Name,
                            ProjectStartDate = ep.Project.StartDate,
                            EndDate = ep.Project.EndDate.HasValue ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt") : "not finished"
                        })
                }).ToList();

            var sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.EmployeeNames} - Manager: {emp.ManagerNames}");
                if (emp.Projects.Any())
                {
                    foreach (var proj in emp.Projects)
                    {
                        sb.AppendLine($"--{proj.ProjectName} - {proj.ProjectStartDate} - {proj.EndDate}");
                    }
                }

               
            }
            return sb.ToString().TrimEnd();
        }
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
           var newAddress = new Address();
          newAddress.TownId = 5;
            newAddress.AddressText = "Vitoshka 15";

            context.Addresses.Add(newAddress);

            var employee = context.Employees
                .Where(e => e.LastName == "Nakov")
                .FirstOrDefault();

            employee.Address = newAddress;

            context.SaveChangesAsync();

            var employees = context.Employees
                .OrderByDescending(e=>e.AddressId)
                .Select(e => e.Address)
                .Take(10)
                .ToList();

            var sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.AddressText}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string  GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees =  context
                .Employees
                .Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.Department,
                        e.Salary
                    })
                .Where(e=>e.Department.Name== "Research and Development")
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
