
namespace TaskTrackerAPI.Services.TaskService
{
    public interface ITaskService
    {
        IEnumerable<Tasks> GetAllTasksInProject(Guid projectId);
        Tasks GetTask(Guid taskId);
        string AddTask(Tasks tasks);
        string RemoveTask(Guid taskId);
        string UpdateTask(Tasks task, Guid taskId);
    }
}
