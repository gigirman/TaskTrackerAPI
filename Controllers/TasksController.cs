using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskTrackerAPI.Services.TaskService;

namespace TaskTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("getalltasks/{projectId}")]
        public ActionResult<IEnumerable<Tasks>> GetAllTasksInProject(Guid projectId)
        {
            var allTasksInProject = _taskService.GetAllTasksInProject(projectId);
            if (allTasksInProject.Count() == 0)
                return NotFound();
            return Ok(allTasksInProject);
        }

        [HttpGet("{id}")]
        public ActionResult<Tasks> GetTask(Guid id)
        {
            var result = _taskService.GetTask(id);
            if (result is null)
                return NotFound("Task not found");
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<Tasks> AddTask(Tasks task)
        {
            var addedTask = _taskService.AddTask(task);
            if (addedTask == "ok")
                return Ok();
            return BadRequest();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTask(Tasks task, Guid id)
        {
            var updateResult = _taskService.UpdateTask(task, id);
            if (updateResult == "failed")
                return BadRequest();
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteTask(Guid id)
        {
            var removeResult = _taskService.RemoveTask(id);
            if (removeResult == "failed")
                return BadRequest();
            return Ok();
        }
    }
}
