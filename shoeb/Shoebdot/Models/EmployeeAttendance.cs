using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shoebdot.Models
{
    public class EmployeeAttendance
    {
        [Key]
        public int EmployeeAttendanceId { get; set; }

       
        public int EmployeeId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public bool IsPresent { get; set; }
        public bool IsAbsent { get; set; }
        public bool IsOffday { get; set; }
    }
}
