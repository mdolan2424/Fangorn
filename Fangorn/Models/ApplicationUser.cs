using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Tower.Models.TeamViewModels;
using Microsoft.AspNetCore.Identity;

namespace Tower.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
       
        public IEnumerable<TeamUser> teams { get; set; }

    }
}
