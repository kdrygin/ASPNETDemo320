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
        ProjectStorage projectStorage;

        public ProjectsController(IWebHostEnvironment _environment, IProjectStorage _projectStorage)
        {
            projectStorage = (ProjectStorage)_projectStorage;
            Environment = _environment;
            wwwPath = this.Environment.WebRootPath;
        }

        public IActionResult Index()
        {
            projectStorage.LoadFromFile(wwwPath + "/data/projects.csv");
            var projects = projectStorage.Projects;
            return View(projectStorage.Projects);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Project project)
        {
            projectStorage.Add(project);
            projectStorage.SaveToFile(wwwPath + "/data/projects.csv");
            return RedirectToAction("Index");
        }

        public IActionResult Remove(string name)
        {
            projectStorage.RemoveByName(name);
            projectStorage.SaveToFile(wwwPath + "/data/projects.csv");
            return RedirectToAction("Index");
        }
    }
}
