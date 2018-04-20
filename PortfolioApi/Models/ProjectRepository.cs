using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PortfolioApi.Models
{
    public class ProjectRepository
    {
        private readonly ProjectContext context;

        public ProjectRepository(ProjectContext ctx)
        {
            context = ctx;

            // if (context.Project.Count() == 0)
            // {
            //     context.Project.Add(new Project {ProjectLink = "http://carrickwilson.com", ProjectDescription = "Dummy Project",
            //         Type = new ProjectType { TypeDescription = "Web Site"}});

            //     context.SaveChanges();
            // }
        }


        public IEnumerable<Project> GetProjects()
        { 
            return context.Project.ToList();
        }

        public Project GetbyId (int Id)
        {
            return context.Project.FirstOrDefault(x => x.Id == Id);
        }

        public void CreateProject(Project project)
        {
            context.Project.Add(project);
            context.SaveChanges();
        }

        public bool UpdateProject(Project project)
        {
            var itemToUpdate = context.Project.FirstOrDefault(x => x.Id == project.Id);

            if(itemToUpdate == null)
                return false;
            
            itemToUpdate.ProjectDescription = project.ProjectDescription;
            itemToUpdate.ProjectLink = project.ProjectLink;
            itemToUpdate.Type = project.Type;
            
            context.Project.Update(itemToUpdate);
            context.SaveChanges();

            return true;
        }

        public void DeleteProject(int Id)
        {
            var projectToDelete = context.Project.FirstOrDefault(x => x.Id == Id);

            if (projectToDelete == null)
                return;
            
            context.Project.Remove(projectToDelete);
            context.SaveChanges();
        }
    }
}