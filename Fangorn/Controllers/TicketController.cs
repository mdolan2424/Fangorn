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
        //database
        private readonly ApplicationDbContext _context;

        public TicketController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }


        // GET: /<controller>/
        public async Task<IActionResult> Index(string sortOrder)
        {
            

            return View(await _context.Tickets.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> IndexGrid()
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
                    ticket.Creator = user;
                    _context.Add(ticket);
                   
                    await _context.SaveChangesAsync();
                   
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

        
        [HttpGet]
        public ActionResult Details(int? ID)
        {
            if (ID==null)
            {
                return NotFound();
            }
            var ticket = _context.Tickets.Find(ID);

            return View(ticket);
            
        }

      
        [HttpGet]
        public async Task<IActionResult> Edit(int? ID)
        {

            if (ID==null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets.SingleOrDefaultAsync(t => t.Id == ID);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int ID, [Bind("Id,Title,Description,CreateDate,DueDate,CloseDate,UserId")] Ticket ticket)
        {
            if (ID!= ticket.Id)
            {

                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                        throw;
                    
                }

                return RedirectToAction("Index");
            }

            return View(ticket);

            
        }

        

        [HttpPost]
        public ActionResult Delete(int? ID)
        {
            if (ID ==null)
            {
                return NotFound();
            }

            var ticket = _context.Tickets.Find(ID);

            _context.Remove(ticket);

            return View();
        }
    }   
}
