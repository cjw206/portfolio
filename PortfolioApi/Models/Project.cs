using MongoDB.Bson.Serialization.Attributes;

namespace PortfolioApi.Models
{
    public class Project
    {
        [BsonId]
        public int ObjectId {get; set;}
        public string Title {get; set;}
        public string ProjectTech {get; set;}
        public string ProjectLink {get; set;}
        public string ProjectDescription {get; set;}
        public string Type {get; set;}
    }
}