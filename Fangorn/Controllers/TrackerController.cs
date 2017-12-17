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
using Tower.Models.ClientViewModels;
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

            return RedirectToAction("View Open Timelogs");
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

            return View("LogTimeViewModel", model);
        }

        [HttpPost]
        public async Task<IActionResult> LogTimePost(LogTimeAndLocationViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            var client = _context.Clients.Where(m => m.Id == model.ClientId)
                .First();
            TimeLog log = new TimeLog
            {
                Client = client,
                LoggedMinutes = model.LoggedMinutes,
                StartTime = model.StartTime,
                EndTime = DateTime.Now,
                User = user,
            };

            _context.Add(log);

            await _context.SaveChangesAsync();

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
                Sessions = new List<TimeSession>(),
                ContinueTime = DateTime.Now
                
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
        [ActionName("View Open Timelogs")]
        public async Task<IActionResult> OpenTimeLogs()
        {
            var user = await _userManager.GetUserAsync(User);
            var logs = _context.TimeLog.Where(tl => tl.User == user && tl.EndTime == DateTime.MinValue)
                .Include(tl => tl.Client)
                .Include(tl => tl.User)
                .Include(tl=>tl.Sessions)
                .ToList();


            OpenTimeLogsViewModel model = new OpenTimeLogsViewModel
            {
                OpenLogs = logs
            };

            //update recorded time since last checked.
            if (logs != null)
            {
                foreach (var log in model.OpenLogs)
                {
                    log.LoggedMinutes = 0;
                    for (int i = 0; i < log.Sessions.Count; i++)
                    {
                        log.LoggedMinutes += log.Sessions[i].Minutes;
                    }
                    if(log.PausedTime == DateTime.MinValue)
                    {
                        log.LoggedMinutes += (int)(DateTime.Now - log.ContinueTime).TotalMinutes;
                    }
                    
                    _context.Update(log);
                    await _context.SaveChangesAsync();
                }
              
                
            }
           




            return View("OpenTimeLogsView", model);
        }

        [HttpGet]
        [ActionName("View Closed Timelogs")]
        public async Task<IActionResult> RecentTimeLogs()
        {
            var user = await _userManager.GetUserAsync(User);
            var logs = _context.TimeLog.Where(tl => tl.User == user && tl.EndTime != DateTime.MinValue)
                .Include(tl => tl.User)
                .Include(tl => tl.Client)
                .ToList();

            RecentTimeLogsViewModel model = new RecentTimeLogsViewModel
            {
                TimeLogs = logs
            };

            return View("RecentTimeLogsView", model);
        }

        //end time session
        public async Task<IActionResult> Pause(int Id)
        {
            var timeLog = _context.TimeLog.Where(tl => tl.Id == Id).First();
            if (timeLog.EndTime == DateTime.MinValue)
            {
                timeLog.PausedTime = DateTime.Now;

                TimeSession session = new TimeSession
                {
                    Minutes = (int)(DateTime.Now - timeLog.ContinueTime).TotalMinutes,
                    TimeLog = timeLog
                };

                _context.Update(timeLog);
                _context.Add(session);


                await _context.SaveChangesAsync();
            }
            return RedirectToAction("View Open Timelogs");
        }

        //create new timesession
        public async Task<IActionResult> Continue(int Id)
        {

            var timeLog = _context.TimeLog.Where(tl => tl.Id == Id).First();
            if (timeLog.EndTime == DateTime.MinValue)
            {

                timeLog.PausedTime = DateTime.MinValue;
                timeLog.ContinueTime = DateTime.Now;
                _context.Update(timeLog);


                await _context.SaveChangesAsync();
            }
            return RedirectToAction("View Open Timelogs");

        }


        public async Task<IActionResult> Finalize(int Id)
        {

            var timeLog = _context.TimeLog.Where(tl => tl.Id == Id).First();
            var sessions = _context.TimeSessions.Where(ts => ts.Id == Id).ToList();

            if (timeLog.EndTime == DateTime.MinValue)
            {
                
                TimeSession session = new TimeSession
                {
                    Minutes = (int)(DateTime.Now - timeLog.ContinueTime).TotalMinutes,
                    TimeLog = timeLog
                };

                _context.Update(timeLog);
                _context.Add(session);


                //hopefully do this once
                for (int i = 0; i < timeLog.Sessions.Count; i++)
                {
                    timeLog.LoggedMinutes = 0;
                    timeLog.LoggedMinutes += timeLog.Sessions[i].Minutes + session.Minutes;
                }


                timeLog.EndTime = DateTime.Now;

                _context.Update(timeLog);

                await _context.SaveChangesAsync();
                }
            
            return RedirectToAction("View Open Timelogs");
        }
    }
}