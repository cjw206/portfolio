using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PortfolioApi.Models
{
    public class Project
    {
        [BsonId]
        public ObjectId Id {get; set;}
        public string Title {get; set;}
        public string ProjectTech {get; set;}
        public string ProjectLink {get; set;}
        public string ProjectDescription {get; set;}
        public string Type {get; set;}
    }
}