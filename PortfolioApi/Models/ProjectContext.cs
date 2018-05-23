using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace PortfolioApi.Models
{
    public class ProjectContext
    {
        private readonly IMongoDatabase data;
        public ProjectContext(IOptions<DataConfig> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            data = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<Project> projects => data.GetCollection<Project>("Projects");
    }
}