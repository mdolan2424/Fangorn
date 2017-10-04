using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Fangorn.Controllers
{
    public class ClientsController : Controller
    {
        public IActionResult Index()
        {
            return View("ClientListView");
        }

        public IActionResult Create()
        {
            return View("ClientCreateView");
        }

        public IActionResult Edit()
        {
            return View("ClientEditView");
        }
    }
}