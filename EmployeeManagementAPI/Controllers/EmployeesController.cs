using EmployeeManagement.DataAccess.Repository.IRepository;
using EmployeeManagement.Models;
using EmployeeManagement.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Employees
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            try
            {
                var employees = _unitOfWork.Employees.GetAllEmployees()
                            .Select(e => new EmployeeDto
                            {
                                Id = e.Id,
                                Name = e.Name,
                                Email = e.Email,
                                Position = e.Position,
                                Department = e.Department,
                                Phone = e.Phone,
                                Projects = e.Projects.Select(p => new ProjectDto { Id = p.Id, ProjectName = p.ProjectName }).ToList()
                            })
                            .ToList(); return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            try
            {
                var employee = _unitOfWork.Employees.GetEmployeeById(id);
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/Employees
        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (employee == null)
                {
                    return BadRequest();
                }
                _unitOfWork.Employees.AddEmployee(employee);
                _unitOfWork.Save();
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("assignEmployeesOnProjects")]
        public IActionResult AssignEmployeeToProjects(int employeeId, [FromBody] List<int> projectIds)
        {
            try
            {
                _unitOfWork.Employees.AssignEmployeeToProjects(employeeId, projectIds);
                _unitOfWork.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
