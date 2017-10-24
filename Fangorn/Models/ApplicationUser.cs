using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Fangorn.Models.TeamViewModels;
using Microsoft.AspNetCore.Identity;

namespace Fangorn.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
       
        public IEnumerable<TeamUser> teams { get; set; }

    }
}
