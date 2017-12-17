using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tower.Models.ClientViewModels;
using Microsoft.AspNetCore.Identity;
using Tower.Data;
using Tower.Models;
using Tower.Models.ClientViewModels;
using Microsoft.EntityFrameworkCore;
using Tower.Models.LocationViewModels;

namespace Tower.Controllers
{
    public class ClientController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public ClientController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new ListClients();

            model.Clients = _context.Client.Include(c => c.Address).ToList();

            return View("ClientListView", model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateClient
            {

            };
            return View("CreateClient", model);

        }

        [HttpPost]
        public async Task<IActionResult> PostCreateClient(CreateClient ClientViewData)
        {
            if (ModelState.IsValid)
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
                _context.Add(address);

                Client client = new Client
                {
                    Name = ClientViewData.Name,
                    Email = ClientViewData.Email,
                    Phone = ClientViewData.Phone,
                    Address = address
                };
                _context.Add(address);
                _context.Add(client);
                await _context.SaveChangesAsync();


            }


            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var clientModel = await _context.Client
                 .Include(c => c.Address)
                 .SingleOrDefaultAsync(c => c.Id == Id);
            EditClient client = new EditClient
            {
                Id = clientModel.Id,
                Name = clientModel.Name,
                EmailAddress = clientModel.Email,
                Phone = clientModel.Phone,
                Address = clientModel.Address,
                MainContact = clientModel.MainContact
            };

            return View("ClientEditView", client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int Id, EditClient editModel)
        {
            //find client
            var client = _context.Client
                .Include(a=>a.Address)
                .SingleOrDefault(c => c.Id == Id);
            
            if (client == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                client.Id = editModel.Id;
                client.Email = editModel.EmailAddress;
                client.Name = editModel.Name;
                client.Phone = editModel.Phone;
                client.MainContact = editModel.MainContact;
                client.Address.Street = editModel.Address.Street; 
                client.Address.Apartment = editModel.Address.Apartment;
                client.Address.City = editModel.Address.City;
                client.Address.State = editModel.Address.State;
                client.Address.Zip = editModel.Address.Zip;

                _context.Update(client);

                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            var client = _context.Client
                .Include(c=>c.Address).
                SingleOrDefault(c => c.Id == Id);

            if (client == null)
            {
                return NotFound();
            }

            DetailsClient model = new DetailsClient
            {
                Id = client.Id,
                Name = client.Name,
                EmailAddress = client.Email,
                Address = client.Address,
                MainContact = client.MainContact,
                Phone = client.Phone
            };

            return View("ClientDetailView", model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var client = _context.Client.SingleOrDefault(c => c.Id == Id);

            if (client == null)
            {
                return NotFound();
            }

            return View("ClientDeleteView", client);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int Id)
        {
            var client = _context.Client.SingleOrDefault(c => c.Id == Id);

            if (client == null)
            {
                return NotFound();
            }


            _context.Remove(client);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        #region Search
        [HttpPost]
        public async Task<IActionResult> IndexSearch(string search)
        {
            if (!String.IsNullOrEmpty(search))
            {
                var Clients = await _context.Clients
                    .Where(t => t.Name.Contains(search) || t.Email.Contains(search))
                    .ToListAsync();
                var model = new ListClients();
                model.Clients = Clients;
                return View("ClientListView", model);
            }

            return RedirectToAction("Index");

        }
        #endregion Search

        [ActionName("Clients")]
        public IActionResult getClients()
        {

            return RedirectToAction("Index");
        }

    }
}