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
        // для получения пути до wwwroot
        private IWebHostEnvironment Environment;
        private string wwwPath;

        // ссылка на объект - хранилище проектов
        ProjectStorage projectStorage;

        public ProjectsController(IWebHostEnvironment _environment, IProjectStorage _projectStorage)
        {
            //
            projectStorage = (ProjectStorage)_projectStorage;

            // получить путь до wwwroot
            Environment = _environment;
            wwwPath = Environment.WebRootPath;
        }

        // при входе на страницу проектов загружаем проекты из файла. 
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

        // при добавлении проекта сохраняем все проекты в файл
        [HttpPost]
        public IActionResult Add(Project project)
        {
            projectStorage.Add(project);
            projectStorage.SaveToFile(wwwPath + "/data/projects.csv");
            return RedirectToAction("Index");
        }

        // при удалении проекта сохраняем все проекты в файл
        public IActionResult Remove(string name)
        {
            projectStorage.RemoveByName(name);
            projectStorage.SaveToFile(wwwPath + "/data/projects.csv");
            return RedirectToAction("Index");
        }
    }
}
