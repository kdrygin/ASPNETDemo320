using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPNetDemo320
{
    public class ProjectsController : Controller
    {
        private IWebHostEnvironment Environment;
        private string wwwPath;

        public ProjectsController(IWebHostEnvironment _environment)
        {
            Environment = _environment;
            wwwPath = this.Environment.WebRootPath;
        }

        public IActionResult Index()
        {
            ProjectStorage.LoadFromFile(wwwPath + "/data/projects.csv");
            var projects = ProjectStorage.Projects;
            return View(projects);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Project project)
        {
            ProjectStorage.Add(project);
            ProjectStorage.SaveToFile(wwwPath + "/data/projects.csv");
            return RedirectToAction("Index");
        }

        public IActionResult Remove(string name)
        {
            ProjectStorage.RemoveByName(name);
            ProjectStorage.SaveToFile(wwwPath + "/data/projects.csv");
            return RedirectToAction("Index");
        }
    }
}
