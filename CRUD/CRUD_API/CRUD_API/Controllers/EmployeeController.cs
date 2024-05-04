using CRUD_API.Database;
using CRUD_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_API.Controllers
{
    // localhost/api/EmployeeController , www.devapplications.com/api/EmployeeController
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
        public async Task<IActionResult> Get()
        {
            var Employees = await _context.Employees.ToListAsync();
            return Ok(Employees);
            // 200 , 404 , 505
        }
        // FromBody - it will get value from our UI body
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employee emp)
        {
            emp.EmployeeId = new Guid();
            await _context.Employees.AddAsync(emp);
            await _context.SaveChangesAsync();
            return Ok(emp);
        }

    }
}
