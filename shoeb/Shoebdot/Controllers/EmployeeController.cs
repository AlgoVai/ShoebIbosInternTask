using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoebdot.Repositories;

namespace Shoebdot.Controllers
{
   [Route("api/employees")]
   // [ApiController]
    //[Route("[controller]/[action]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
       
        [HttpGet("GetEmployeeById/{id}")]
        
        public IActionResult GetById(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }

        [HttpGet("code/{employeeCode}")]
        public IActionResult GetByCode(string employeeCode)
        {
            var employee = _employeeRepository.GetByCode(employeeCode);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }

        [HttpGet("third-highest-salary")]
        public IActionResult GetByEmployeeNameWithThirdHighestSalary()
        {
            var employee = _employeeRepository.GetByThirdHighestSalary();
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }
        //[Route("GetByMaximumSalary")]
        [HttpGet("maximum-salary")]
        public IActionResult GetByMaximumSalary()
        {
            var employees = _employeeRepository.GetByMaximumSalary();
            return Ok(employees);
        }

        [HttpGet("minimum-salary")]
        public IActionResult GetByMinimumSalary()
        {
            var employees = _employeeRepository.GetByMinimumSalary();
            return Ok(employees);
        }

        [HttpGet("monthly-attendance-report")]
        public IActionResult GetMonthlyAttendanceReport()
        {
            try
            {
                var report = _employeeRepository.GetMonthlyAttendanceReport();
                return Ok(report);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("hierarchy/{employeeId}")]
        public IActionResult GetHierarchy(int employeeId)
        {
            var hierarchy = _employeeRepository.GetHierarchy(employeeId);
            if (hierarchy == null)
                return NotFound();
            return Ok(hierarchy);
        }
    }
}
