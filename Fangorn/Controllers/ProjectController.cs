using Tower.Data;
using Tower.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tower.Models.ProjectViewModels;

namespace Tower.Controllers
{
    public class ProjectController: Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public ProjectController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ListAllProjects model = new ListAllProjects();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CreateProjectViewModel model = new CreateProjectViewModel
            {
                
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(CreateProjectViewModel model)
        {
            Project project = new Project
            {
                Title = model.Title,
                Description = model.Description
            };

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            return View();
        }

        /*[HttpGet]
        public async Task<IActionResult> Delete(int Id?)
        {

        }*/
    }

}
