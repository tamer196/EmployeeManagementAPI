using EmployeeManagement.DataAccess.Data;
using EmployeeManagement.DataAccess.Repository.IRepository;
using EmployeeManagement.Models;

namespace EmployeeManagement.DataAccess.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _db;

        public ProjectRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void AddProject(Project project)
        {
            _db.Project.Add(project);
        }

        public IEnumerable<Project> GetAllProjects()
        {
            return _db.Project.ToList();
        }
    }
}
