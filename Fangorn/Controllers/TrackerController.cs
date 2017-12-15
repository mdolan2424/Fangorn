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
using Tower.Models.ClientsViewModels;
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
        
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var timeLogs = _context.TimeLog.Where(tl => tl.User == user);
            RecentTimeLogsViewModel model = new RecentTimeLogsViewModel
            {
                TimeLogs = timeLogs
            };

            return RedirectToAction("OpenTimeLogs");
        }

        //Log a time

        [HttpGet]
        [ActionName("Log Time")]
        public IActionResult LogTime()
        {
            LogTimeAndLocationViewModel model = new LogTimeAndLocationViewModel
            {

                AllClients = _context.Client.ToList()
            };

            return View("LogTimeViewModel",model);
        }

        [HttpPost]
        public async Task<IActionResult> LogTimePost(LogTimeAndLocationViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            TimeLog log = new TimeLog
            {
                Client = model.Client,
                LoggedMinutes = model.LoggedMinutes,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                User = user
            };


            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Check In")]
        public IActionResult CheckIn()
        {
            //get a list of all clients.
            var clients = _context.Clients.ToList();

            var model = new CheckInViewModel
            {
                Clients = clients.Select(c =>
                new SelectListItem()
                {
                    Text = c.Email.ToString()
                }),
            };

            return View("CheckInView", model);
        }

        [HttpPost]
        public async Task<IActionResult> CheckInPost(CheckInViewModel model)
        {
            //Create a new Timelog
            var user = await _userManager.GetUserAsync(User);
            var client = _context.Clients.Where(c => c.Email == model.Client.Email).SingleOrDefault();
            TimeLog timeLog = new TimeLog
            {
                Client = client,
                StartTime = DateTime.Now,
                LoggedMinutes = 0,
                User = user,
            };

            _context.Add(timeLog);

            await _context.SaveChangesAsync();
             
            return RedirectToAction("Index");
        }
        
        public IActionResult ViewLog()
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

        [HttpGet]
        public async Task<IActionResult> OpenTimeLogs()
        {
            var user = await _userManager.GetUserAsync(User);
            var logs = _context.TimeLog.Where(tl => tl.User == user && tl.EndTime == DateTime.MinValue).Include(tl => tl.Client).ToList();
            
            
            OpenTimeLogsViewModel model = new OpenTimeLogsViewModel
            {
                OpenLogs = logs
            };

            //update recorded time since last checked.

            foreach (var log in model.OpenLogs)
            {
                //logged minutes is equal to now minus the start time.
                log.LoggedMinutes = (int)(DateTime.Now - log.StartTime).TotalMinutes;
                _context.Update(log);
            }
            
            await _context.SaveChangesAsync();

            return View("OpenTimeLogsView",model);
        }

        [HttpGet]
        public async Task<IActionResult> RecentTimeLogs()
        {
            var user = await _userManager.GetUserAsync(User);
            var logs = _context.TimeLog.Where(tl => tl.User == user && tl.EndTime != null).ToList();
            
            RecentTimeLogsViewModel model = new RecentTimeLogsViewModel
            {
                TimeLogs = logs
            };
            
            return View(model);
        }
        
    }
}