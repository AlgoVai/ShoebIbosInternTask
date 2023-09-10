using Shoebdot.Models;

namespace Shoebdot.Repositories
{
    public interface IEmployeeRepository
    {
        Employee GetByCode(string employeeCode);
        Employee GetById(int employeeId);
        Employee GetByMaximumSalary();
        Employee GetByMinimumSalary();
        Employee GetByThirdHighestSalary();
        IList<Employee> GetHierarchy(int employeeId);
        IList<EmployeeAttendanceReport> GetMonthlyAttendanceReport();
    }
}