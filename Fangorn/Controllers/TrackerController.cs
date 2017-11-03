using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tower.Models.TrackerViewModels;
using Microsoft.AspNetCore.Identity;
using Tower.Models;
using Tower.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Tower.Controllers
{
    public class TrackerController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public TrackerController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {

            LogTimeAndLocationViewModel model = new LogTimeAndLocationViewModel
            {
                AllClients = _context.Client.ToList()
            };
            
            return View(model);
        }

        //Log a time

        [HttpGet]
        public IActionResult LogTime()
        {
            TimeLog model = new TimeLog();


            return View();
        }

        [HttpPost]
        public IActionResult LogTimePost()
        {

            return View();
        }


        [HttpGet]
        public IActionResult ReadTime()
        {

            return View();
        }

        [HttpGet]
        public IActionResult EditTime()
        {

            return View();
        }

        [HttpPost]
        public IActionResult EditTimePost()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DeleteTime()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeleteTimePost()
        {

            return View();
        }


        public IActionResult LinkClient()
        {

            return View();
        }






        //link a client.
    }
}