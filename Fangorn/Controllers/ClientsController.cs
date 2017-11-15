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
            
            model.Clients = _context.Client.Include(c=>c.Address).ToList();
            
            return View("ClientListView",model);
        }



        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateClient
            {
                
            };
            return View("CreateClient",model);
            
        }

        [HttpPost]
        public async Task<IActionResult> PostCreateClient(CreateClient ClientViewData)
        {
            Address address = new Address
            {
                Street = ClientViewData.Address.Street,
                Apartment = ClientViewData.Address.Apartment,
                City = ClientViewData.Address.City,
                Country = ClientViewData.Address.Country,
                State = ClientViewData.Address.State,
                Zip = ClientViewData.Address.Zip
            };

            Client Client = new Client
            {
                Name = ClientViewData.Name,
                Email = ClientViewData.Email,
                Phone = ClientViewData.Phone,
                Address = address
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

        [HttpPost]
        public async Task<IActionResult> EditPost(int Id, EditClient editModel)
        {
            //find client
            var client = _context.Client.SingleOrDefault(c => c.Id == Id);

            if (client == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                client.Email = editModel.EmailAddress;
                client.Name = editModel.Name;
                client.Phone = editModel.Phone;
                client.MainContact = editModel.MainContact;
                
                _context.Update(client);

                await _context.SaveChangesAsync();
            }

            return View("ClientListView");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            var client = _context.Client.SingleOrDefault(c => c.Id == Id);

            if (client == null)
            {
                return NotFound();
            }

            DetailsClient model = new DetailsClient
            {
                Name = client.Name,
                EmailAddress = client.Email,
                Address = client.Address,
                MainContact = client.MainContact,
                Phone = client.Phone
            };

            return View("ClientDetailView");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var client = _context.Client.SingleOrDefault(c => c.Id == Id);
            
            if (client == null)
            {
                return NotFound();
            }

            return View("ClientDeleteView");
        }

        
    }
}