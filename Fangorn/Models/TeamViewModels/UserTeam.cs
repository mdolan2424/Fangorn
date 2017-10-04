using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fangorn.Models.TeamViewModels
{
    public class TeamUser
    {

        public String UserId { get; set; }
        public ApplicationUser User { get; set; }

        public String TeamId { get; set; }
        public Team Team { get; set; }

    }
}
