using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Fangorn.Models;
using Microsoft.AspNetCore.Identity;
using Fangorn.Models.TicketViewModels;
using Microsoft.EntityFrameworkCore;
using Fangorn.Data;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fangorn.Controllers
{
    
    public class TicketController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        public TicketController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }


        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tickets.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,DueDate")] Ticket t)
        {

            //get form data
           try
            {
                if (ModelState.IsValid)
                {
                    
                    Ticket ticket = t;
                    //get logged in user
                    ApplicationUser user = await _userManager.GetUserAsync(User);
                   
                    ticket.CreateDate = DateTime.Now;
                    ticket.User = user;
                    _context.Add(ticket);
                   
                    await _context.SaveChangesAsync();
                    Console.WriteLine("Save Complete");
                    return View();

                }
                
            }


            catch
            {
                Console.WriteLine("An error occurred");
            }
            //post to database

            return View();
        }
    }   
}
