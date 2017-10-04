using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fangorn.Data;
using Fangorn.Models.TeamViewModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fangorn.Controllers
{
    public class TeamsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeamsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Teams
        public async Task<IActionResult> Index()
        {
            return View(await _context.Teams.ToListAsync());
        }

        // GET: Teams/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //ThenInclude will grab additional attributes from related tables.
            var team = await _context.Teams
                .Include(t => t.Members).ThenInclude(m => m.User)
                .SingleOrDefaultAsync(m => m.Id == id);
                
            
            
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // GET: Teams/Create
        //ModelView
        public IActionResult CreateTeam()
        {
            
            var users = _context.Users.ToList();
            CreateTeamViewModel model = new CreateTeamViewModel
            {
                Users = new MultiSelectList(users)
            };

            return View(model);
        }

        // POST: Teams/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTeam([Bind("Name,Description")] CreateTeamViewModel createTeam, string[] members)
        {
            if (ModelState.IsValid)
            {
                //Many-to-Many relationship
                Team team = new Team
                {
                    Members = new List<TeamUser>(),
                    Description = createTeam.Description,
                    Name = createTeam.Name
                };
                _context.Add(team);

                //recent
                await _context.SaveChangesAsync();

                foreach (var member in members )
                {

                    var savedTeam = (from t in _context.Teams where t.Name == team.Name select team).SingleOrDefault();
                    //fails if not found.
                    var user = (from u in _context.Users where u.Email == member select u).SingleOrDefault();
                    var TeamUser = new TeamUser { TeamId = savedTeam.Id, Team = savedTeam, UserId = user.Id, User = user };
                    team.Members.Append(TeamUser);
                    _context.Add(TeamUser);
                }

                
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
                
            }
            return View();
        }

        
        // GET: Teams/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams.SingleOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }
            return View(team);
        }

        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Team team)
        {
            if (id != team.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(team);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExists(team.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(team);
        }

        // GET: Teams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .SingleOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.Teams.SingleOrDefaultAsync(m => m.Id == id);
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }*/
    }
}
