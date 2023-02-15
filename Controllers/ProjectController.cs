using Microsoft.AspNetCore.Mvc;
using TaskTrackerAPI.Services.ProjectService;

namespace TaskTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public ActionResult<List<Project>> GetAllProjects()
        {
            var allProjects = _projectService.GetAllProjects();
            if (allProjects.Count == 0)
                return NotFound("No projects in databse");
            return Ok(allProjects);
        }

        [HttpGet("{id}")]
        public ActionResult<Project> GetProject(Guid id)
        {
            var result = _projectService.GetProject(id);
            if (result is null)
                return NotFound("Project not found");
            return Ok(result);
        }

        [HttpPost]
        public ActionResult AddProject(Project project)
        {
            var addedProject = _projectService.AddProject(project);
            if (addedProject == "ok")
                return Ok();
            return BadRequest();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProject(Project project, Guid id)
        {
            var updateResult = _projectService.UpdateProject(project, id);
            if (updateResult == "failed")
                return BadRequest();
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public ActionResult DeleteProject(Guid id)
        {
            var removeResult = _projectService.RemoveProject(id);
            if (removeResult == "failed")
                return BadRequest();
            return Ok();
        }

    }
}
