namespace TaskTrackerAPI.Services.TaskService
{
    public class TaskService : ITaskService
    {

        private readonly TaskTrackerContext _context;

        public TaskService(TaskTrackerContext context)
        {
            _context = context;
        }
        public string AddTask(Tasks task)
        {
            try
            {
                task.Id = Guid.NewGuid();
                _context.Tasks.Add(task);
                _context.SaveChanges();
                return "ok";
            }
            catch
            {
                return "failed";
            }
        }

        public IEnumerable<Tasks> GetAllTasksInProject(Guid projectId)
        {
            return _context.Tasks.Where(task => task.ProjectId == projectId);
        }

        public Tasks GetTask(Guid taskId)
        {
            var task = _context.Tasks.Find(taskId);
            if (task == null)
                return null;
            return task;
        }

        public string RemoveTask(Guid taskId)
        {
            try
            {
                var task = _context.Tasks.Find(taskId);
                if (task is null)
                    return "failed";
                _context.Tasks.Remove(task);

                var saved = _context.SaveChanges();

                return "ok";
            }
            catch
            {
                return "failed";
            }
            
        }

        public string UpdateTask(Tasks taskToUpdate, Guid id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
                return "failed";

            task.Name = taskToUpdate.Name;
            task.Description = taskToUpdate.Description;
            task.Priority = taskToUpdate.Priority;
            task.ProjectId = taskToUpdate.ProjectId;
            task.CurrentTaskStatusId = taskToUpdate.CurrentTaskStatusId;

            _context.SaveChanges();

            return "ok";
        }
    }
}
