using System.ComponentModel.DataAnnotations;

namespace Shoebdot.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public decimal EmployeeSalary { get; set; }
        public int? SupervisorId { get; set; }

        public IList<EmployeeAttendance> Attendances { get; set; }
    }
}
