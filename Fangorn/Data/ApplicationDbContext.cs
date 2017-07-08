using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Fangorn.Models;
using Fangorn.Models.TicketViewModels;
using Fangorn.Models.ProjectViewModels;
using Fangorn.Models.TeamViewModels;
using Fangorn.Models.InventoryViewModels;
using Fangorn.Models.HomeViewModels;
namespace Fangorn.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {}

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Team> Teams { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            
        }


        public DbSet<Fangorn.Models.InventoryViewModels.Item> Item { get; set; }


        public DbSet<Fangorn.Models.HomeViewModels.ContactModel> ContactModel { get; set; }


        public DbSet<Fangorn.Models.TicketViewModels.TicketComment> TicketComment { get; set; }
    }
}
