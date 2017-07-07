using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fangorn.Models.HomeViewModels;
using Fangorn.Data;
using Microsoft.EntityFrameworkCore;
using Fangorn.Services;

namespace Fangorn.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly ApplicationDbContext _context;
        private AuthMessageSender _mail;
        
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Tickets()
        {
            ViewData["Message"] = "Tickets.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Contact";

            return View();
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Contact([Bind("Name,Email,Subject,Message")] ContactModel c)
        {
            if (ModelState.IsValid)
            {
                string name = c.Name;
                string email = c.Email;
                string subject = c.Subject;
                string message = c.Message;

                //await _mail.SendEmailAsync(email, subject, message);
                
                //Store in Database
                
                ContactModel contact = c;
                _context.Add(contact);
                await _context.SaveChangesAsync();

                return View();
            }

            return View();
            
        }

        
        public IActionResult Error()
        {
            return View();
        }
    }
}
