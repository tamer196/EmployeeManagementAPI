using EmployeeManagement.DataAccess.Data;
using EmployeeManagement.DataAccess.Repository.IRepository;

namespace EmployeeManagement.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Employees = new EmployeeRepository(_db);
            Projects = new ProjectRepository(_db);
        }

        public IEmployeeRepository Employees { get; private set; }
        public IProjectRepository Projects { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
