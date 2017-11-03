using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tower.Models.HomeViewModels;
using Tower.Data;
using Microsoft.EntityFrameworkCore;
using Tower.Services;
using Microsoft.AspNetCore.Identity;
using Tower.Models;

namespace Tower.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly ApplicationDbContext _context;
        private AuthMessageSender _mail;
        private SignInManager<ApplicationUser> SignInManager;
        private UserManager<ApplicationUser> _userManager;

        
        
        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        //require a login to access the website.
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                

            }

            else
            {
                return RedirectToAction("Login", "Account");
            }


            return View();
        }
        
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult ServiceOrders()
        {
            ViewData["Message"] = "ServiceOrders.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Contact";

            return View();
        }


        //requires email integration
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
