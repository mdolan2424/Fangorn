using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tower.Models.ProjectViewModels
{
    public class ProjectDetails
    {
        public int ID { get; }
        public string Title { get;}
        public string Description { get; }
        public List<ProjectTask> Tasks { get; }
    }
}
