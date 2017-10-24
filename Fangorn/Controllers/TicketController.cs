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
using Microsoft.AspNetCore.Authorization;
using Fangorn.Models.TicketViewModels.CommentViewModels;

namespace Fangorn.Controllers
{
    [Authorize]
    public class TicketController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public TicketController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }


        // GET: /<controller>/
        
        public IActionResult Index(string filter)
        {

            var tickets = Filter(filter);

            return View(tickets);
        }

        public IActionResult Closed()
        {
            return RedirectToAction("Index", "Ticket", new { filter = "Closed" });
        }

        public IActionResult Open()
        {
            return RedirectToAction("Index", "Ticket", new { filter = "Open" });
        }

        public IActionResult Assigned()
        {
            return RedirectToAction("Index", "Ticket", new { filter = "Assigned" });
        }


        public IQueryable Filter(string filter)
        {
            //default query
            IQueryable<Ticket> query = _context.Tickets.Include(creator => creator.Creator).Include(Assigned => Assigned.AssignedTo).Where(t => t.IsClosed == false);
            
            if (filter  == "Closed")
            {
                query = _context.Tickets.Include(creator => creator.Creator).Include(Assigned => Assigned.AssignedTo).Where(t => t.IsClosed == true);
            }
            
            else if (filter == "Assigned")
            {
                var user = _userManager.GetUserId(User);
                
                query = _context.Tickets.Include(creator => creator.Creator).Include(Assigned => Assigned.AssignedTo).Where(t => t.AssignedTo.Id == user);
                
            }
            return query;
        }

        

        #region Create
        [HttpGet]
        public IActionResult CreateTicket()
        {
            var techs = _context.Users.OrderBy(u => u.Email).Select(x => x.Email);

            var model = new CreateTicketViewModel
            {
                TeamMembers = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(techs)
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(CreateTicketViewModel ct)
        {
            Ticket t = new Ticket
            {
                Title = ct.Title,
                Description = ct.Description,
                AssignedTo = await _userManager.FindByEmailAsync(ct.AssignedTo),
                CreateDate = DateTime.Now,
                CloseDate = ct.DueDate
            };

            var user = await _userManager.GetUserAsync(User);

            t.Creator = user;

            _context.Add(t);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public IActionResult New()
        {
            return RedirectToAction("CreateTicket");
        }

        #endregion Create

        #region Details
        [HttpGet]
        public ActionResult TicketCommentsDetailsView(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }

            var ticket = _context.Tickets.Find(ID);
            var comments = _context.Comment.Where(c => c.Ticket.Id == ID).Include(c => c.Commentor);
            TicketCommentsViewModel ticketComments = new TicketCommentsViewModel
            {
                Ticket = ticket,
                Comments = comments.ToList()
            };
            return View(ticketComments);

        }
        #endregion Details

        [HttpGet]
        public async Task<IActionResult> Edit(int? ID)
        {

            if (ID == null)
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
            if (ID != ticket.Id)
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

        
        
        public async Task<IActionResult> Close(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }

            var ticket = _context.Tickets.Find(ID);
            var user = await _userManager.GetUserAsync(User);

            ticket.IsClosed = true;
            ticket.CloseDate = DateTime.Now;
            ticket.ClosedBy = user;

            _context.Update(ticket);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }

            var ticket = _context.Tickets.Find(ID);

            return View(ticket);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteTicket(int? ID)
        {
            if (ID ==null)
            {
                return NotFound();
            }

            var ticket = _context.Tickets.Find(ID);

            _context.Remove(ticket);

            _context.SaveChanges();
            return RedirectToAction("index");
        }
        
        [HttpPost]
        [ActionName("Index")]
        public async Task<IActionResult> IndexSearch(string search)
        {
            if (!String.IsNullOrEmpty(search))
            {
                var tickets = await _context.Tickets.Include(creator => creator.Creator).Include(Assigned => Assigned.AssignedTo).Where(t => t.Description.Contains(search) || t.Title.Contains(search)).ToListAsync();
                
                return View(tickets);
            }

            return RedirectToAction("Index");
            
        }

        #region Comments
        [HttpGet]
        public IActionResult CommentCreate(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            var ticket = _context.Tickets.Find(ID);
            TicketCommentsViewModel ticketComments = new TicketCommentsViewModel
            {
                Ticket = ticket
            };


            return View(ticketComments);

        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(TicketCommentsViewModel c, int id)
        {

            var user = await _userManager.GetUserAsync(User);
            var ticket = _context.Tickets.Find(id);

            Comment Comment = new Comment
            {
                Commentor = user,
                Date = DateTime.Now,
                Content = c.Comment.Content,
                Ticket = ticket
            };

            _context.Add(Comment);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }
        #endregion Comments

        public async Task<IActionResult> Assign(int? Id)
        {
            var user = await _userManager.GetUserAsync(User);
            var ticket = _context.Tickets.Include(t=>t.AssignedTo).Where(t=>t.Id == Id).ToList();
            ticket[0].AssignedTo = user;

            _context.Update(ticket[0]);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
