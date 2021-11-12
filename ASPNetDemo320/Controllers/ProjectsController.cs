using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPNetDemo320
{
    public class ProjectsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
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
            return RedirectToAction("Index");
        }

        public IActionResult Remove(string name)
        {
            ProjectStorage.RemoveByName(name);
            return RedirectToAction("Index");
        }
    }
}
