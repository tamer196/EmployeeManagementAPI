using EmployeeManagement.Models;

namespace EmployeeManagement.DataAccess.Repository.IRepository
{
    public interface IProjectRepository
    {
        void AddProject(Project project);
        IEnumerable<Project> GetAllProjects();

    }
}
