using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjection.Models;

namespace DependencyInjection.Repository
{
    public interface IEmployee
    {
        List<Employee> GetEmployees();
    }
}
