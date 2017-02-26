using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Fangorn.DataAccessLayer;
using Fangorn.Models.TicketViewModels;

namespace Fangorn.Models
{
    public static class DbInitializer
    {
        public static void Initialize(TicketContext context)
        {

            context.Database.EnsureCreated();

            if (context.Tickets.Any())
            {
                return;
            }

            var tickets = new Ticket[]
            {
            new Ticket{Title="Test Title", Description="Test Description", CreateDate=DateTime.Parse("2005-09-01"),CloseDate=DateTime.Parse("2006-09-01")}
            };


            foreach(Ticket t in tickets)
            {
                context.Tickets.Add(t);
            }
            context.SaveChanges();  
        }

    }

}