using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fangorn.Models.ProjectViewModels
{
    public class ProjectUser
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public Project Project { get; set; }
    }
}
