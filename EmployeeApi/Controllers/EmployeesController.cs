using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Models;
using EmployeeApi.Data;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public EmployeesController()
        {
            _context = new EmployeeContext();
        }

        //GET: api/employees//{id}
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        // POST: api/employees
        [HttpPost]
        public ActionResult<Employee> CreateEmployee(Employee employee)
        {
            employee.Id = _context.Employees.Max(e => e.Id) + 1;
            _context.Employees.Add(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

        // PUT: api/employees/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, Employee updatedEmployee)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound();

            employee.FirstName = updatedEmployee.FirstName;
            employee.LastName = updatedEmployee.LastName;
            employee.Position = updatedEmployee.Position;
            employee.Salary = updatedEmployee.Salary;

            return NoContent();
        }

        // DELETE: api/employees/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound();

            _context.Employees.Remove(employee);
            return NoContent();
        }
    }
}