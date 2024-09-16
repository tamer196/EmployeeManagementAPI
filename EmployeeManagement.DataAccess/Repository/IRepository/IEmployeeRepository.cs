using EmployeeManagement.Models;

namespace EmployeeManagement.DataAccess.Repository.IRepository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        void AddEmployee(Employee employee);
        void AssignEmployeeToProjects(int employeeId, List<int> projectIds);
    }
}
