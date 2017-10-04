using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fangorn.Models.TeamViewModels
{
    public class Team
    {
        public String Id { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public IEnumerable<TeamUser> Members { get; set; }



    }
}
