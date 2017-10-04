using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Fangorn.Controllers
{
    public class TrackerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //Log a time

        [HttpGet]
        public IActionResult LogTime()
        {

            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public IActionResult LogTimePost()
        {

            return View();
        }
       
        
        [HttpGet]
        public IActionResult ReadTime()
        {

            return View();
        }
        
        [HttpGet]
        public IActionResult EditTime()
        {

            return View();
        }

        [HttpPost]
        public IActionResult EditTimePost()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DeleteTime()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeleteTimePost()
        {

            return View();
        }

       
        public IActionResult LinkClient()
        {

            return View();
        }
        

        

        

        //link a client.
    }
}