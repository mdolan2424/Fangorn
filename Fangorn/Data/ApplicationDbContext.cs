using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tower.Models;
using Tower.Models.ServiceOrderViewModels;
using Tower.Models.ProjectViewModels;
using Tower.Models.TeamViewModels;
using Tower.Models.InventoryViewModels;
using Tower.Models.HomeViewModels;
using Tower.Models.ClientViewModels;
using Tower.Models.LocationViewModels;
using Tower.Models.TrackerViewModels;
namespace Tower.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {}

        public DbSet<ServiceOrder> ServiceOrders { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamUser> TeamUsers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<TeamUser>()
            .HasKey(t => new { t.UserId, t.TeamId });

            builder.Entity<TeamUser>().HasOne(tu => tu.User).WithMany(t => t.teams).HasForeignKey(tu => tu.UserId);
            builder.Entity<TeamUser>().HasOne(tu => tu.Team).WithMany(u => u.Members).HasForeignKey(tu => tu.TeamId);
        }


        public DbSet<Tower.Models.InventoryViewModels.Item> Item { get; set; }


        public DbSet<Tower.Models.HomeViewModels.ContactModel> ContactModel { get; set; }


        public DbSet<Tower.Models.ServiceOrderViewModels.CommentViewModels.Comment> Comment { get; set; }


        public DbSet<Tower.Models.ClientViewModels.Client> Client { get; set; }


        public DbSet<Tower.Models.LocationViewModels.Address> Address { get; set; }


        public DbSet<Tower.Models.TrackerViewModels.TimeLog> TimeLog { get; set; }
        
    }
}
