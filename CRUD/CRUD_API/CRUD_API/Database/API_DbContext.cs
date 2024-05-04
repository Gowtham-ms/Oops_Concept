using CRUD_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_API.Database
{
    public class API_DbContext : DbContext //-- this is going to be the bridge between our application and database
    {
        public API_DbContext(DbContextOptions options) : base(options) { 
        }
        // just this is table to acccess inside my application
        public DbSet<Employee> Employees { get; set; }
    }
}
