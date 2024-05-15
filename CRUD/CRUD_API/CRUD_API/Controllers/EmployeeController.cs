using CRUD_API.Database;
using CRUD_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_API.Controllers
{
    // /localhost:5112/api/Employee , www.devapplications.com/api/EmployeeController
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // 
        
        private readonly API_DbContext _context;
        public EmployeeController(API_DbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Read()
        {
            var Employees = await _context.Employees.ToListAsync();
            return Ok(Employees);
          
            // 200 , 404 , 505
        }
        // FromBody - it will get value from our UI body
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Employee emp)
        {
            emp.EmployeeId = new Guid();
            await _context.Employees.AddAsync(emp);
            await _context.SaveChangesAsync();
            return Ok(emp);
        }
        // Update our database
        [HttpPut]
        [Route("{EmployeeId:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid EmployeeId, [FromBody] Employee emp)
        {
            var employees = await _context.Employees.FirstOrDefaultAsync(a => a.EmployeeId == EmployeeId);
            if (employees == null)
            {
                return BadRequest();
            }
            employees.EmployeeName = emp.EmployeeName;
            employees.MobileNumber = emp.MobileNumber;
            employees.EmailID = emp.EmailID;
            await _context.SaveChangesAsync();
            return Ok(employees);
        }
        // delete the row from database
        [HttpDelete]
        [Route("{EmployeeId:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid EmployeeId)
        {
            var employees = await _context.Employees.FirstOrDefaultAsync(a => a.EmployeeId == EmployeeId);
            if (employees == null)
            {
                return BadRequest();
            }
            _context.Employees.Remove(employees);
            await _context.SaveChangesAsync();
            return Ok(employees);
        }
    }
}
