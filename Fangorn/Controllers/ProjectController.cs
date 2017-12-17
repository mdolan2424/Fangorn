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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tower.Controllers
{
    public class ProjectController : Controller
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
            //list of teams




            var Teams = _context.Teams.OrderBy(t => t.Name).Select(t => t.Name);
            CreateProjectViewModel model = new CreateProjectViewModel
            {
                AllTeams = new SelectList(Teams)
            };

            return View("CreateProjectView", model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(CreateProjectViewModel model)
        {
            var team = _context.Teams.SingleOrDefault(t => t.Name == model.Team.Name);
            Project project = new Project
            {
                Title = model.Title,
                Description = model.Description,
                Team = team
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
                .Include(p => p.Tasks)
                .First();
            //var projectTasks = _context.ProjectTasks.Where(pt => pt.Project.Id == Id);
            ProjectDetails details = new ProjectDetails()
            {
                Id = project.Id,
                Description = project.Description,
                Tasks = project.Tasks,
                Title = project.Title,
                completeComplexityTasks = 0,
                completeStoryTasks = 0,
                incompleteComplexityTasks = 0,
                incompleteStoryTasks = 0,
                inWorkComplexityTasks = 0,
                inWorkStoryTasks = 0
            };


            foreach (var task in details.Tasks)
            {
                if (task.Status == Status.Complete)
                {
                    details.completeComplexityTasks += task.Complexity;
                    details.completeStoryTasks += task.StoryPoints;
                }

                else if (task.Status == Status.Incomplete)
                {
                    details.incompleteStoryTasks += task.StoryPoints;
                    details.incompleteComplexityTasks += task.Complexity;
                }

                else if (task.Status == Status.InWork)
                {
                    details.inWorkComplexityTasks += task.Complexity;
                    details.inWorkStoryTasks += task.StoryPoints;
                }
            }
            return View("DetailsProjectView", details);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            //fid
            var project = _context.Projects
                .Include(t=>t.Team)
                .Where(p => p.Id == Id).First();

            var Teams = _context.Teams.OrderBy(t => t.Name).Select(t => t.Name);
            EditProjectViewModel model = new EditProjectViewModel
            {
                Id = project.Id,
                Team = project.Team,
                Description = project.Description,
                Title = project.Title,
                AllTeams = new SelectList(Teams)

            };

            return View("EditProjectView", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditPost(EditProjectViewModel model, int Id)
        {
           
            var project = _context.Projects
               .Where(p => p.Id == Id).First();
            var team = _context.Teams.SingleOrDefault(t => t.Name == model.Team.Name);
            
            project.Team = team;
            project.Title =  model.Title;
            project.Description = model.Description;

            _context.Update(project);

            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { Id = Id });
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

            var user = await _userManager.GetUserAsync(User);
            ProjectTask task = new ProjectTask
            {
                Title = model.Title,
               
                Project = project,
                Status = model.Status,
                StoryPoints = model.StoryPoints,
                Complexity = model.Complexity,
                CompletionDate = model.CompletionDate,
                
            };

            //if project has no tasks, make one
            if(project.Tasks == null)
            {
                project.Tasks = new List<ProjectTask>();
            }
            if (task.Status == Status.Complete)
            {
                task.CompletedBy = user;
            }
            _context.Add(task);


            project.Tasks.Add(task);
            _context.Update(project);

            await _context.SaveChangesAsync();


            return RedirectToAction("Details", new { Id = Id });
        }

        [HttpGet]
        public async Task<IActionResult> EditProjectTask(int Id)
        {
            var projectTask = _context.ProjectTasks.Where(pt => pt.Id == Id).First();

            EditProjectTaskViewModel model = new EditProjectTaskViewModel
            {
                Title = projectTask.Title,
               
                CompletionDate = projectTask.CompletionDate,
                Complexity = projectTask.Complexity,
                Status = projectTask.Status,
                StoryPoints = projectTask.StoryPoints
            };
            return View("EditProjectTaskView", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditProjectTask(EditProjectTaskViewModel model, int Id)
        {
            var task = _context.ProjectTasks.Where(m => m.Id == Id)
                .Include(m=>m.Project).First();
            var user = await _userManager.GetUserAsync(User);

            task.Title = model.Title;
            task.StoryPoints = model.StoryPoints;
            task.Complexity = model.Complexity;
            task.Status = model.Status;
            task.CompletionDate = model.CompletionDate;

            if (task.Status == Status.Complete)
            {
                task.CompletedBy = user;
            }

            _context.Update(task);

            await _context.SaveChangesAsync();


            return RedirectToAction("Details", new { Id = task.Project.Id });
        }

        [HttpGet]
        public async Task<IActionResult> DetailsProjectTaskView(int Id)
        {

            return View();
        }
    }

}
