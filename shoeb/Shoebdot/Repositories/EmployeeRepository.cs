using Microsoft.EntityFrameworkCore;
using Shoebdot.Data;
using Shoebdot.Models;
using System.Globalization;

namespace Shoebdot.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Employee GetById(int employeeId)
        {
            return _context.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
        }

        public Employee GetByCode(string employeeCode)
        {
            return _context.Employees.FirstOrDefault(e => e.EmployeeCode == employeeCode);
        }
        public Employee GetByMaximumSalary()
        {
            return _context.Employees.OrderByDescending(e => e.EmployeeSalary).FirstOrDefault();
        }

        public Employee GetByMinimumSalary()
        {
            return _context.Employees.OrderBy(e => e.EmployeeSalary).FirstOrDefault();
        }

        public Employee GetByThirdHighestSalary()
        {
            return _context.Employees
                .OrderByDescending(e => e.EmployeeSalary)
                .Skip(2)
                .FirstOrDefault();
        }

        public IList<Employee> GetHierarchy(int employeeId)
        {
            var hierarchy = new List<Employee>();
            var currentEmployee = GetById(employeeId);

            while (currentEmployee != null)
            {
                hierarchy.Add(currentEmployee);
                currentEmployee = GetById(currentEmployee.SupervisorId ?? 0);
            }

            return hierarchy;
        }
        public IList<EmployeeAttendanceReport> GetMonthlyAttendanceReport()
        {
            // Create the monthly attendance report by joining Employee and EmployeeAttendance entities
            var query = from emp in _context.Employees
                        join attendance in _context.EmployeeAttendances
                        on emp.EmployeeId equals attendance.EmployeeId
                        group new { emp, attendance } by new { emp, attendance.AttendanceDate.Month } into grouped
                        select new EmployeeAttendanceReport
                        {
                            EmployeeId = grouped.Key.emp.EmployeeId,

                            EmployeeName = grouped.Key.emp.EmployeeName,
                            MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(grouped.Key.Month),
                            PayableSalary = grouped.Sum(x => x.emp.EmployeeSalary),
                            TotalPresent = grouped.Sum(x => x.attendance.IsPresent ? 1 : 0),
                            TotalAbsent = grouped.Sum(x => x.attendance.IsAbsent ? 1 : 0),
                            TotalOffday = grouped.Sum(x => x.attendance.IsOffday ? 1 : 0)
                        };

            return query.ToList();
        }


    }
}
