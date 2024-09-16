using EmployeeManagement.DataAccess.Data;
using EmployeeManagement.DataAccess.Repository.IRepository;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.DataAccess.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;

        public EmployeeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _db.Employee.Include(e => e.Projects).ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return _db.Employee.Include(e => e.Projects).FirstOrDefault(e => e.Id == id);
        }

        public void AddEmployee(Employee employee)
        {
            _db.Employee.Add(employee);
        }

        public void AssignEmployeeToProjects(int employeeId, List<int> projectIds)
        {
            var employee = _db.Employee.Include(e => e.Projects).FirstOrDefault(e => e.Id == employeeId);
            if (employee != null)
            {
                var projects = _db.Project.Where(p => projectIds.Contains(p.Id)).ToList();
                var employeeProjects = employee.Projects.ToList();
                employeeProjects.AddRange(projects);
                employee.Projects = employeeProjects;
            }
        }
    }
}
