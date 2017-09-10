using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fangorn.Controllers
{
    public class LocationController : Controller
    {
        public IActionResult Index()
        {

            List<string> ListItems = new List<string>();
            ListItems.Add("United States");

            SelectList Countries = new SelectList(ListItems);
            ViewData["Countries"] = Countries;
            return View();
        }

        public JsonResult getStates(string Country)
        {
            List<string> StatesList = new List<string>();

            switch(Country)
            {
                case "United States":
                    StatesList.Add("Montana");
                    break;
            }

            return Json(StatesList);
        }


    }
}