using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Tower.Models;
using Microsoft.AspNetCore.Identity;
using Tower.Models.ServiceOrderViewModels;
using Microsoft.EntityFrameworkCore;
using Tower.Data;
using Microsoft.AspNetCore.Authorization;
using Tower.Models.ServiceOrderViewModels.CommentViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tower.Models.ServiceOrderViewModels.BillableViewModels;

namespace Tower.Controllers
{
    [Authorize]
    public class ServiceOrderController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public ServiceOrderController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }


        // GET: /<controller>/
        
        public IActionResult Index(string filter)
        {

            var ServiceOrders = Filter(filter);

            return View(ServiceOrders);
        }

        public IActionResult Closed()
        {
            return RedirectToAction("Index", "ServiceOrder", new { filter = "Closed" });
        }

        public IActionResult Open()
        {
            return RedirectToAction("Index", "ServiceOrder", new { filter = "Open" });
        }

        public IActionResult Assigned()
        {
            return RedirectToAction("Index", "ServiceOrder", new { filter = "Assigned" });
        }


        public IQueryable Filter(string filter)
        {
            //default query
            IQueryable<ServiceOrder> query = _context.ServiceOrders.Include(creator => creator.Creator)
                .Include(t => t.AssignedTo)
                .Where(t => t.IsClosed == false);
            
            if (filter  == "Closed")
            {
                query = _context.ServiceOrders.Include(creator => creator.Creator).Include(Assigned => Assigned.AssignedTo).Where(t => t.IsClosed == true);
            }
            
            else if (filter == "Assigned")
            {
                var user = _userManager.GetUserId(User);
                
                query = _context.ServiceOrders.Include(creator => creator.Creator).Include(Assigned => Assigned.AssignedTo).Where(t => t.AssignedTo.Id == user);
                
            }
            return query;
        }

        

        #region Create
        [HttpGet]
        public IActionResult CreateServiceOrder()
        {
            var techs = _context.Users.OrderBy(u => u.Email).Select(x => x.Email);
            var clients = _context.Clients.ToList();

            var model = new CreateServiceOrderViewModel
            {
                TeamMembers = new SelectList(techs),

                Clients = clients.Select(c =>
                new SelectListItem()
                {
                    Text = c.Name.ToString()
                }),
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateServiceOrder(CreateServiceOrderViewModel ct)
        {
            var client = _context.Clients.SingleOrDefault(c => c.Name == ct.Client);
            ServiceOrder t = new ServiceOrder
            {
                Title = ct.Title,
                Description = ct.Description,
                AssignedTo = await _userManager.FindByEmailAsync(ct.AssignedTo),
                CreateDate = DateTime.Now,
                DueDate = ct.DueDate,
                Client = client
               
            };

            var user = await _userManager.GetUserAsync(User);

            t.Creator = user;

            _context.Add(t);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public IActionResult New()
        {
            return RedirectToAction("CreateServiceOrder");
        }

        #endregion Create

        #region Details
        [HttpGet]
        public ActionResult Details(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }

            var ServiceOrder = _context.ServiceOrders
                .Include(so => so.Creator)
                .Include(so => so.Client)
                .ToList()
                .Find(so=>so.Id == ID);

            var comments = _context.Comment.Where(c => c.ServiceOrder.Id == ID)
                .Include(c => c.Commentor);
            var billedCosts = _context.BillableTime.Where(bt => bt.ServiceOrder == ServiceOrder).ToList();
            var settings = _context.SiteSettings.First();
            double total = 0;
            foreach (var cost in billedCosts)
            {
                total += Math.Round(((double)cost.Cost),2);
            }
            ServiceOrderCommentsViewModel ServiceOrderComments = new ServiceOrderCommentsViewModel
            {
                ServiceOrder = ServiceOrder,
                Comments = comments.ToList(),
                BillableCost = total
            };
            return View(ServiceOrderComments);

        }
        #endregion Details
        #region Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int? ID)
        {

            if (ID == null)
            {
                return NotFound();
            }

            var ServiceOrder = await _context.ServiceOrders.SingleOrDefaultAsync(t => t.Id == ID);

            if (ServiceOrder == null)
            {
                return NotFound();
            }


            return View(ServiceOrder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditServiceOrder(int? ID, ServiceOrder model)
        {
          
            ServiceOrder serviceOrder;
            try
            {
                serviceOrder = _context.ServiceOrders.SingleOrDefault(so => so.Id == ID);
                serviceOrder.Title = model.Title;
                serviceOrder.Description = model.Description;
                serviceOrder.DueDate = model.DueDate;
                _context.Update(serviceOrder);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

                
            

            return RedirectToAction("Index");


        }
        #endregion Edit

        #region Close
        public async Task<IActionResult> Close(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }

            var ServiceOrder = _context.ServiceOrders.Find(ID);
            var user = await _userManager.GetUserAsync(User);

            ServiceOrder.IsClosed = true;
            ServiceOrder.CloseDate = DateTime.Now;
            ServiceOrder.ClosedBy = user;

            _context.Update(ServiceOrder);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        #endregion Close

        #region Delete
        [HttpGet]
        public ActionResult Delete(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }

            var ServiceOrder = _context.ServiceOrders.Find(ID);

            return View(ServiceOrder);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteServiceOrder(int? ID)
        {
            if (ID ==null)
            {
                return NotFound();
            }

            var ServiceOrder = _context.ServiceOrders.Find(ID);

            _context.Remove(ServiceOrder);

            _context.SaveChanges();
            return RedirectToAction("index");
        }

        #endregion Delete

        #region Search
        [HttpPost]
        [ActionName("Index")]
        public async Task<IActionResult> IndexSearch(string search)
        {
            if (!String.IsNullOrEmpty(search))
            {
                var ServiceOrders = await _context.ServiceOrders.Include(creator => creator.Creator).Include(Assigned => Assigned.AssignedTo).Where(t => t.Description.Contains(search) || t.Title.Contains(search)).ToListAsync();
                
                return View(ServiceOrders);
            }

            return RedirectToAction("Index");
            
        }
        #endregion Search

        #region Comments
        [HttpGet]
        public IActionResult CommentCreate(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            var ServiceOrder = _context.ServiceOrders.Find(ID);
            ServiceOrderCommentsViewModel ServiceOrderComments = new ServiceOrderCommentsViewModel
            {
                ServiceOrder = ServiceOrder
            };


            return View(ServiceOrderComments);

        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(ServiceOrderCommentsViewModel c, int id)
        {

            var user = await _userManager.GetUserAsync(User);
            var ServiceOrder = _context.ServiceOrders.Find(id);

            Comment Comment = new Comment
            {
                Commentor = user,
                Date = DateTime.Now,
                Content = c.Comment.Content,
                ServiceOrder = ServiceOrder
            };

            _context.Add(Comment);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }
        #endregion Comments

        #region Assign
        public async Task<IActionResult> Assign(int? Id)
        {
            var user = await _userManager.GetUserAsync(User);
            var ServiceOrder = _context.ServiceOrders.Include(t=>t.AssignedTo).Where(t=>t.Id == Id).ToList();
            ServiceOrder[0].AssignedTo = user;

            _context.Update(ServiceOrder[0]);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        #endregion Assign

        #region CreateBillableTime
        [HttpGet]
        public IActionResult CreateBillableTimeGet(int Id)
        {
            var serviceOrder = _context.ServiceOrders.Where(so => so.Id == Id).First();
            CreateBillableTimeViewModel model = new CreateBillableTimeViewModel
            {
                ServiceOrder = serviceOrder
            };

            return View("BillableTime/CreateBillableTimeView", model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBillableTimePost (CreateBillableTimeViewModel model, int Id)
        {
            var user = await _userManager.GetUserAsync(User);
            var settings = _context.SiteSettings.First();
            var serviceOrder = _context.ServiceOrders.Where(so => so.Id == Id).First();
            BillableTime billableTime = new BillableTime
            {
                Minutes = model.Minutes,
                ServiceOrder = serviceOrder,
                AddedBy = user,
                Cost = (((Math.Round(model.Minutes / 15.0) * 15)) * (settings.ChargeRate/60.0)),
                WorkPerformed = model.WorkPerformed
            };

             _context.Add(billableTime);

            await _context.SaveChangesAsync();
            
            return RedirectToAction("SeeBillableTimes", new { Id = Id });
        }
        #endregion CreateBillableTime


        [HttpGet]
        public async Task<IActionResult> SeeBillableTimes(int Id)
        {
            SeeBillableTimesOnServiceOrderrViewModel model = new SeeBillableTimesOnServiceOrderrViewModel();
            //find service order
            var serviceOrder = _context.ServiceOrders.Where(so => so.Id == Id).First();
            var billableTimes = _context.BillableTime.Where(b => b.ServiceOrder == serviceOrder)
                .Include(b=>b.AddedBy).ToList();
            model.ServiceOrder = serviceOrder;
            model.BillableTimes = billableTimes;
            
            return View("BillableTime/SeeBillableTimesOnServiceOrderView", model);
        }
    }
}
