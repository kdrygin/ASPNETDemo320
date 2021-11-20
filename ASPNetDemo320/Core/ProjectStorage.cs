using System;
using System.IO;
using System.Collections.Generic;

namespace ASPNetDemo320
{
    public interface IProjectStorage
    {
        void Add(Project project);
        void RemoveByName(string name);
        void SaveToFile(string path);
        void LoadFromFile(string path);
    }

    public class ProjectStorage : IProjectStorage
    {
        public  List<Project> Projects { get; private set; }

        public ProjectStorage()
        {
            Projects = new List<Project>();
        }

        public void Add(Project project)
        {
            Projects.Add(project);
        }

        public void SaveToFile(string path)
        {
            using (var tw = new StreamWriter(path))
            {
                foreach (var p in Projects)
                    tw.WriteLine(p);
            }
        }

        public void LoadFromFile(string path)
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

        public void RemoveByName(string name)
        {
            Projects.RemoveAll(p => p.Name == name);
        }
    }
}
