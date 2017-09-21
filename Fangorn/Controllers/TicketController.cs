﻿using System;
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
        public async Task<IActionResult> Index(string sortOrder)
        {
            //Creator is passed in as extra information to the view.
            var tickets = await _context.Tickets.Include(creator => creator.Creator).Include(Assigned => Assigned.AssignedTo).ToListAsync();
            
            //taken from teams controller
            /*var team = await _context.Teams
                .Include(t => t.Members).ThenInclude(m => m.User)
                .SingleOrDefaultAsync(m => m.Id == id);*/


            return View(tickets);
        }
        
        
        [HttpGet]
        public IActionResult CreateTicket()
        {
            var techs = _context.Users.OrderBy(u=>u.Email).Select(x => x.Email);

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
                AssignedTo = await _userManager.FindByEmailAsync(ct.AssignedTo)
            };
            var user = await _userManager.GetUserAsync(User);

            t.Creator = user;

            _context.Add(t);


            await _context.SaveChangesAsync();

                    return RedirectToAction("Index");

              
        }

        [HttpGet]
        public ActionResult TicketCommentsDetailsView(int? ID)
        {
            if (ID==null)
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
        public async Task<IActionResult> createComment (TicketCommentsViewModel c, int id)
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

        [HttpGet]
        public async Task<IActionResult> Edit(int? ID)
        {

            if (ID==null)
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
            if (ID!= ticket.Id)
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
                var tickets = await _context.Tickets.Include(creator => creator.Creator).Include(Assigned => Assigned.AssignedTo).Where(t => t.Description.Contains(search)).Where(t=>t.Description.Contains(search)).ToListAsync();
                return View(tickets);
            }

            return RedirectToAction("Index");
            
        }
  
    }   
}
