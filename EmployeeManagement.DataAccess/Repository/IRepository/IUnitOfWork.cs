namespace EmployeeManagement.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employees { get; }
        IProjectRepository Projects { get; }
        void Save();
    }
}
