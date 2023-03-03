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
            if (allProjects != null && allProjects.Count == 0)
                return NotFound("No projects in databse");
            return Ok(allProjects);
        }

        [HttpGet("{id}")]
        public ActionResult<Project> GetProjectById(Guid id)
        {
            var result = _projectService.GetProjectById(id);
            if (result is null)
                return NotFound("Project with this id not found");
            return Ok(result);
        }

        [HttpGet("startatless/{date}")]
        public ActionResult<Project> GetProjectsByDateLess(string date)
        {
            var result = _projectService.GetProjectsByDate(date, "less");
            if (result is null)
                return NotFound("Projects with this filters not found");
            return Ok(result);
        }

        [HttpGet("startatmore/{date}")]
        public ActionResult<Project> GetProjectsByDateMore(string date)
        {
            var result = _projectService.GetProjectsByDate(date, "more");
            if (result is null)
                return NotFound("Projects with this filters not found");
            return Ok(result);
        }

        [HttpGet("{startDate},{endDate}")]
        public ActionResult<Project> GetProjectsByDates(string startDate, string endDate)
        {
            var result = _projectService.GetProjectsByDates(startDate, endDate);
            if (result is null)
                return NotFound("Projects with this filters not found");
            return Ok(result);
        }

        [HttpPost]
        public ActionResult AddProject(Project project)
        {
            var addedProject = _projectService.AddProject(project);
            if (addedProject == "ok")
                return Ok();
            return BadRequest(addedProject);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProject(Project project, Guid id)
        {
            var updateResult = _projectService.UpdateProject(project, id);
            if (updateResult == "ok")
                return Ok();
            return BadRequest(updateResult);

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
