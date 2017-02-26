using Fangorn.Models;
using Fangorn.Models.TicketViewModels;
using Microsoft.EntityFrameworkCore;

namespace Fangorn.DataAccessLayer
{
    public class TicketContext : DbContext
    {   public TicketContext(DbContextOptions<TicketContext> options) : base(options)
        {
        }
            public DbSet<Ticket> Tickets { get; set; }
    }

        

        
    }

 
