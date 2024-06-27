namespace SoftUni.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class EmployeeProject
    {
        public int EmployeeId { get; set; }

        public int ProjectId { get; set; }

        public Employee Employee { get; set; } = null!;

        public Project Project { get; set; } = null!;
    }
}
