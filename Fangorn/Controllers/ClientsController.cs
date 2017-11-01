using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fangorn.Models.ClientViewModels;
using Microsoft.AspNetCore.Identity;
using Fangorn.Data;
using Fangorn.Models;
using Fangorn.Models.ClientsViewModels;
using Microsoft.EntityFrameworkCore;

namespace Fangorn.Controllers
{
    public class ClientsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public ClientsController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public IActionResult Index()
        {
            var model = new ListClients();
            
            model.Clients = _context.Client.ToList();
            
            return View("ClientListView",model);
        }



        [HttpGet]
        [ActionName("Create")]
        public IActionResult GetCreateClient()
        {
            var model = new CreateClient
            {
                
            };
            return View("Create",model);
        }

        [HttpPost]
        public async Task<IActionResult> PostCreateClient(CreateClient ClientViewData)
        {
            Client Client = new Client
            {
                Name = ClientViewData.Name,
                Email = ClientViewData.Email,
                Phone = ClientViewData.Phone
            };

            _context.Add(Client);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var clientModel = await _context.Client.SingleOrDefaultAsync(c => c.Id == Id);
            EditClient client = new EditClient
            {
                Id = clientModel.Id,
                Name = clientModel.Name,
                EmailAddress = clientModel.Email,
                Phone = clientModel.Phone,
                Address = clientModel.Address,
                MainContact = clientModel.MainContact
            };

            return View("ClientEditView",client);
        }
    }
}