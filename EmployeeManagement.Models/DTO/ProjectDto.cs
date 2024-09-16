namespace EmployeeManagement.Models.DTO
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public int ProjectVersion { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectStatus { get; set; }
        public string ProjectManager { get; set; }
    }

}
