using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tower.Data;
using Tower.Models;
using Tower.Models.ClientViewModels;
using Tower.Models.HomeViewModels;
using Tower.Models.ServiceOrderViewModels;
using Tower.Services;


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

            var model = new DashboardHomePageViewModel();
            model.RecentServiceOrders = new List<int>();
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
               
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }

            //return a list of dashboard items.

            //default query
            int? monthOne = _context.ServiceOrders
                .Where(so => so.CreateDate > DateTime.Now.AddDays(-DateTime.Now.Day) && so.CreateDate <= DateTime.Now).Count();
            
            if (monthOne !=null)
            {
                model.RecentServiceOrders.Add((int)monthOne);
            }
            
            for (int i=1; i<6; i++)
            {
                int? month = _context.ServiceOrders
                .Where(so => so.CreateDate > (DateTime.Now.AddMonths(-i).AddDays(-DateTime.Now.Day)) && so.CreateDate <= DateTime.Now.AddMonths(-1*(i-1)).AddDays(-DateTime.Now.Day)).Count();
                if (month != null)
                {
                    model.RecentServiceOrders.Add((int)month);
                }
                else
                {
                    model.RecentServiceOrders.Add(0);
                }
                
            }
            
            return View(model);
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
