using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tower.Models.ClientViewModels;
using Microsoft.AspNetCore.Identity;
using Tower.Data;
using Tower.Models;
using Tower.Models.ClientsViewModels;
using Microsoft.EntityFrameworkCore;
using Tower.Models.LocationViewModels;
namespace Tower.Controllers
{
    public class SettingsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public SettingsController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {

            return RedirectToAction("Read");
        }

        [HttpGet]
        public IActionResult Setup()
        {

            return View();
        }

        [HttpPost]
        public IActionResult SetupPost()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Read()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }


        [HttpPost]
        public IActionResult EditPost()
        {
            return View();
        }

    }
}
