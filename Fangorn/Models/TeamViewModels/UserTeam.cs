using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fangorn.Models.TeamViewModels
{
    public class UserTeam
    {

        public Team team { get; set; }
        public ApplicationUser user { get; set; }
    }
}
