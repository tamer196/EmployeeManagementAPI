using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public int ProjectVersion { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectStatus { get; set; }
        public string ProjectManager { get; set; }
        public ICollection<Employee> Employees { get; set; }

    }

}
