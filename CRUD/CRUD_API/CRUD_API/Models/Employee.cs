using System.ComponentModel.DataAnnotations;

namespace CRUD_API.Models
{
    // this is going to be our table
    public class Employee
    {
        // creating columns here :
        [Key]
        public Guid EmployeeId { get; set; } // 16 digit code 
        public string EmployeeName { get; set; }
        public int MobileNumber { get; set; }
        public string EmailID { get; set; }

    }
}
