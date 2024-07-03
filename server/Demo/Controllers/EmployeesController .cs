using Demo.Data;
using Demo.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public EmployeesController(AppDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await dbContext.Employees.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(Guid id)
        {
            var employee = await dbContext.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            dbContext.Employees.Add(employee);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(Guid id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            dbContext.Entry(employee).State = EntityState.Modified;

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            var employee = await dbContext.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            dbContext.Employees.Remove(employee);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }

/*        [HttpDelete("cleanup")]
        public async Task<IActionResult> DeleteAllEmployees()
        {
            var employees = await dbContext.Employees.ToListAsync();
            dbContext.Employees.RemoveRange(employees);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }*/

        private bool EmployeeExists(Guid id)
        {
            return dbContext.Employees.Any(e => e.Id == id);
        }
    }
}
