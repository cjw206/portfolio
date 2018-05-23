using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace PortfolioApi.Models
{
    public class ProjectRepository
    {
        private readonly ProjectContext context;

        public ProjectRepository(ProjectContext ctx)
        {
            context = ctx;
        }


        public async Task<IEnumerable<Project>> GetProjects()
        { 
            return await context.projects.Find(_ => true).ToListAsync();
        }

        public async Task<Project> GetByTitle(string title)
        {
            var filter = Builders<Project>.Filter.Eq("Title", title);

            return await context.projects.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateProject(Project project)
        {
           await context.projects.InsertOneAsync(project);
        }

        public async Task<bool> UpdateProject(Project project)
        {
            var filter = Builders<Project>.Filter.Eq("Title", project.Title);
            var itemToUpdate = context.projects.Find(filter).FirstOrDefault();

            if(itemToUpdate == null)
                return false;
        
            var updatedItem = Builders<Project>.Update
                                                .Set(x => x.Title, project.Title)
                                                .Set(x => x.ProjectTech, project.ProjectTech)
                                                .Set(x => x.ProjectLink, project.ProjectLink)
                                                .Set(x => x.ProjectDescription, project.ProjectDescription);
            
            await context.projects.UpdateOneAsync(filter, updatedItem);

             return true;
        }

        public async Task<DeleteResult> DeleteProject(string title)
        {
            var filter = Builders<Project>.Filter.Eq("Title", title);

            return await context.projects.DeleteOneAsync(filter);
        }
    }
}