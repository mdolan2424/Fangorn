
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tower.Models.TeamViewModels
{
    public class CreateTeamViewModel
    {
        public String Name { get; set; }

        public String Description { get; set; }

        public List<TeamUser> Members { get; set; }

        public MultiSelectList Users { get; set; }

        
    }

    
}
