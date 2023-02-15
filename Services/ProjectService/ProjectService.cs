using Microsoft.EntityFrameworkCore;

namespace TaskTrackerAPI.Services.ProjectService
{
    public class ProjectService : IProjectService
    {
        private readonly TaskTrackerContext _context;

        public ProjectService(TaskTrackerContext context)
        {
            _context = context;
        }
        public string AddProject(Project project)
        {
            try
            {
                project.Id = Guid.NewGuid();
                _context.Projects.Add(project);
                _context.SaveChanges();
                return "ok";
            }
            catch
            {
                return "failed";
            }           

        }

        public List<Project> GetAllProjects()
        {
            var projects = _context.Projects.ToList();
            return projects;
        }

        public Project GetProject(Guid projectId)
        {
            var project = _context.Projects.Find(projectId);
            if (project == null)
                return null;
            return project;
        }

        public string RemoveProject(Guid projectId)
        {
            try
            {
                var project = _context.Projects.Find(projectId);
                if (project is null)
                    return "failed";
                _context.Projects.Remove(project);


                var tasks = _context.Tasks.Where(x => x.ProjectId == projectId);
                if (tasks.Any())
                    _context.Tasks.RemoveRange(tasks);

                var saved = _context.SaveChanges();

                return "ok";
            }
            catch
            {
                return "failed";
            }
        }

        public string UpdateProject(Project projectToUpdate, Guid id)
        {
            var project =  _context.Projects.Find(id);
            if (project == null)
                return "failed";
            
            if (projectToUpdate.Name is not null)
                project.Name = projectToUpdate.Name;
            project.StartDate = projectToUpdate.StartDate;
            project.CompletionDate = projectToUpdate.CompletionDate;
            project.CurrentStatus = projectToUpdate.CurrentStatus;
            project.Priority = projectToUpdate.Priority;

            _context.SaveChanges();

            return "ok";
        }
    }
}
