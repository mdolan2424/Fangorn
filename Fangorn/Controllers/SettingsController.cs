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
using Tower.Models.SettingsViewModels;

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
            //get settings from DB. If none exist, create one.

            var settings = _context.SiteSettings.FirstOrDefault();

            if (settings == null)
            {
                Settings model = new Settings();

                model.ChargeRate = 0;
                model.SiteName = "Tower";

                _context.Add(model);
                _context.SaveChanges();

                return View(model);
            }

            
            
            return View(settings);
            
            
        }

        [HttpGet]
        public IActionResult Edit()
        {
            var settings = _context.SiteSettings.FirstOrDefault();

            if (settings == null)
            {
                Settings model = new Settings();

                model.ChargeRate = 0;
                model.SiteName = "Tower";

                _context.Add(model);
                _context.SaveChanges();

                return View(model);
            }
            
            return View(settings);
        }


        [HttpPost]
        public async Task<IActionResult> EditPost(Settings model)
        {
            var settings = _context.SiteSettings.FirstOrDefault();

            if (ModelState.IsValid)
            {
                settings.SiteName = model.SiteName;
                settings.ChargeRate = model.ChargeRate;

                _context.Update(settings);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

    }
}
