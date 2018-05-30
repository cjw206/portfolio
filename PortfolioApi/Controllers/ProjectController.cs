using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System.Linq;
using PortfolioApi.Models;

namespace PortfolioApi.Controllers
{
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private ProjectRepository repository;
        public ProjectController(IOptions<DataConfig> settings)
        {
            repository = new ProjectRepository(settings);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetProjects()
        {
            //var projects = repository.GetProjects();

            return new ObjectResult(await repository.GetProjects());
        }

        [HttpGet("{title}", Name = "GetId")]
        public IActionResult GetById(string title)
        {
            var project = repository.GetByTitle(title);

            if(project == null)
                BadRequest("Project doesn't exist");

            return Ok(project);
        }

        [HttpPost]
        [Route("AddProject")]
        public async Task<IActionResult> CreateProject([FromBody] Project project)
        {
            await repository.CreateProject(project);

            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateProject([FromBody] Project project)
        {
            var success = await repository.UpdateProject(project);

            if (!success)
                BadRequest("Failed to update.");
            
            return new NoContentResult();
        }

        [HttpDelete("{title}")]
        public async Task<IActionResult> DeleteProject(string title)
        {
            var result = await repository.DeleteProject(title);

            return Ok(result);
        }
    }
}