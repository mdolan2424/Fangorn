
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fangorn.Models.TeamViewModels
{
    public class CreateTeamViewModel
    {
        public String Name { get; set; }

        public String Description { get; set; }

        public IEnumerable<ApplicationUser> Members { get; set; }

        public MultiSelectList Users { get; set; }

        
    }
}
