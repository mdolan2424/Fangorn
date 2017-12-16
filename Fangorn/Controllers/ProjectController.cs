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
            model.AllProjects = _context.Projects.ToList();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CreateProjectViewModel model = new CreateProjectViewModel
            {
                
            };

            return View("CreateProjectView", model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(CreateProjectViewModel model)
        {
            Project project = new Project
            {
                Title = model.Title,
                Description = model.Description
            };

            //save to database
            _context.Add(project);

            await _context.SaveChangesAsync();

            int Id = project.Id;

            ProjectDetails details = new ProjectDetails()
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                Tasks = project.Tasks
            };
            //go to details view
            return View("DetailsProjectView", details);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            var project = _context.Projects
                .Where(p => p.Id == Id)
                .Include(p=>p.Tasks)
                .First();
            //var projectTasks = _context.ProjectTasks.Where(pt => pt.Project.Id == Id);
            ProjectDetails details = new ProjectDetails()
            {
                Id = project.Id,
                Description = project.Description,
                Tasks = project.Tasks,
                Title = project.Title
            };
            return View("DetailsProjectView", details);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            return View("EditProjectView");
        }

        /*[HttpGet]
        public async Task<IActionResult> Delete(int Id?)
        {

        }*/

        [HttpGet]
        public async Task<IActionResult> CreateProjectTask(int Id)
        {
            //find project
            var project = _context.Projects
                .Where(p => p.Id == Id).First();


            CreateProjectTaskViewModel model = new CreateProjectTaskViewModel
            {
                Project = project
            };

            return View("CreateProjectTaskView", model);
        }

        [HttpPost]
        public async Task<IActionResult> PostCreateProjectTask(CreateProjectTaskViewModel model, int Id)
        {
            var project = _context.Projects.Where(p => p.Id == Id).First();
            ProjectTask task = new ProjectTask
            {
                Title = model.Title,
                Type = model.Type,
                Status = model.Status,
                Project = project,
                StoryPoints = model.StoryPoints,
                Complexity = model.Complexity,
                InWork = model.InWork,
                CompletionDate = model.CompletionDate,
                
            };

            //if project has no tasks, make one
            if(project.Tasks == null)
            {
                project.Tasks = new List<ProjectTask>();
            }
            
            _context.Add(task);


            project.Tasks.Add(task);
            _context.Update(project);

            await _context.SaveChangesAsync();


            return RedirectToAction("Details", new { Id = Id });
        }

        [HttpGet]
        public async Task<IActionResult> EditProjectTask(EditProjectTaskViewModel model)
        {

            return View("EditProjectTaskView");
        }

        [HttpPost]
        public async Task<IActionResult> EditCreateProjectTask(EditProjectTaskViewModel model)
        {

            ProjectTask task = new ProjectTask
            {
                Title = model.Title,
                Type = model.Type,
                Status = model.Status,
                StoryPoints = model.StoryPoints,
                Complexity = model.Complexity,
                InWork = model.InWork,
                CompletionDate = model.CompletionDate,

            };

            _context.Update(task);

            await _context.SaveChangesAsync();


            return View("DetailsProjectView");
        }


    }

}
