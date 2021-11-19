using System;
using System.IO;
using System.Collections.Generic;

namespace ASPNetDemo320
{
    public static class ProjectStorage
    {
        public static List<Project> Projects { get; private set; }

        static ProjectStorage()
        {
            Projects = new List<Project>();
        }

        public static void Add(Project project)
        {
            Projects.Add(project);
        }

        public static void SaveToFile(string path)
        {
            using (var tw = new StreamWriter(path))
            {
                foreach (var p in Projects)
                    tw.WriteLine(p);
            }
        }

        public static void LoadFromFile(string path)
        {
            Projects.Clear();
            try
            {
                using (var tr = new StreamReader(path))
                {
                    string str;
                    while ((str = tr.ReadLine()) != null)
                    {
                        Projects.Add(new Project(str));
                    }
                }
            }
            catch (Exception)
            { }
        }

        public static void RemoveByName(string name)
        {
            Projects.RemoveAll(p => p.Name == name);
        }
    }
}
