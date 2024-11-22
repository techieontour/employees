using lunarcake.Data;
using lunarcake.Models;
using lunarcake.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace lunarcake.Controllers {
    //localhost:xxxx/api/employees
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase {

        private readonly ApplicationDBContext dBContext;

        public EmployeeController(ApplicationDBContext dBContext) {
            this.dBContext = dBContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployees() {
            var allEmployees = dBContext.Employees.ToList();
            return Ok(allEmployees);
        }

        [HttpGet]
        [Route("{id: Guid}")]
        public IActionResult GetEmployeeByID(Guid id) {
            var employee = dBContext.Employees.Find(id);
            if (employee is null) {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto) {
            var employeeEntity = new Employee() {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary,
            };
            var employee = dBContext.Employees.Add(employeeEntity);
            dBContext.SaveChanges();
            return Ok(employee);
        }

        [HttpPut]
        [Route("{id: Guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto) {
            var employee = dBContext.Employees.Find(id);
            if (employee is null) {
                return NotFound();
            }
            employee.Name = updateEmployeeDto.Name;
            employee.Email = updateEmployeeDto.Email;
            employee.Phone = updateEmployeeDto.Phone;
            employee.Salary = updateEmployeeDto.Salary;

            dBContext.SaveChanges();
            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id: Guid}")]
        public IActionResult DeleteEmployee(Guid id) {
            var employee = dBContext.Employees.Find(id);
            if (employee is null) {
                return NotFound();
            }
            dBContext.Employees.Remove(employee);
            dBContext.SaveChanges();
            return Ok();
        }
    }
}
