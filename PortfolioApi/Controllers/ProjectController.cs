using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using PortfolioApi.Models;

namespace PortfolioApi.Controllers
{
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private ProjectRepository repository;
        public ProjectController(ProjectContext ctx)
        {
            repository = new ProjectRepository(ctx);
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetProjects()
        {
            var projects = repository.GetProjects();

            return Ok(projects);
        }

        [HttpGet("{id}", Name = "GetId")]
        public IActionResult GetById(int id)
        {
            var project = repository.GetbyId(id);

            if(project == null)
                BadRequest("Project doesn't exist");

            return Ok(project);
        }

        [HttpPost]
        [Route("AddProject")]
        public IActionResult CreateProject([FromBody] Project project)
        {
            repository.CreateProject(project);

            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateProject([FromBody] Project project)
        {
            var success = repository.UpdateProject(project);

            if (!success)
                BadRequest("Failed to update.");
            
            return new NoContentResult();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteProject(int Id)
        {
            repository.DeleteProject(Id);

            return Ok();
        }
    }
}