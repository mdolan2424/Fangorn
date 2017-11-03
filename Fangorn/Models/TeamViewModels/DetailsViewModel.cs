using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tower.Models.TeamViewModels
{
    public class DetailsViewModel
    {
        public String Id { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public List<TeamUser> Members { get; set; }

        

    }
}
