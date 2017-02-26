using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fangorn.Controllers
{
    public class TicketController : Controller
    {
        //private Tickets db = new Tickets();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FormCollection Collection)
        {
            //get form data
            /*try
            {
                if (ModelState.IsValid)
                {
                    
                }

            }*/
            //post to database
            return View();
        }
    }   
}
