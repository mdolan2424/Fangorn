using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tower.Models.ProjectViewModels
{
    public class ProjectDetails
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<ProjectTask> Tasks { get; set; }
        
    }
}
