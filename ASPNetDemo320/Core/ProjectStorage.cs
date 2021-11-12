using System;
using System.Collections.Generic;

namespace ASPNetDemo320
{
    public static class ProjectStorage
    {
        public static List<Project> Projects { get; private set; } = new List<Project>
        {
            new Project
            {
                Name = "CGI Examples",
                Link = "https://github.com/kdrygin/CgiExamples",
                Description = "dotNet Core 3.1 C# CGI Examples"
            }
        };

        public static void Add(Project project)
        {
            Projects.Add(project);
        }

        public static void RemoveByName(string name)
        {
            Projects.RemoveAll(p => p.Name == name);
        }
    }
}
