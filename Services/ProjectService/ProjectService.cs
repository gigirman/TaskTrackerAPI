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
                if (project.CompletionDate <= project.StartDate)
                    return "Completion date cannot be less then start date";
                if (_context.Projects.FirstOrDefault(x => x.Name == project.Name) == default)
                {
                    project.Id = Guid.NewGuid();
                    project.CreatedOn = DateTime.Now.ToUniversalTime();
                    project.UpdatedOn = DateTime.Now.ToUniversalTime();
                    _context.Projects.Add(project);
                    _context.SaveChanges();
                    return "ok";
                }
                else
                    return "Project with this name is already exsits";
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

        public Project? GetProjectById(Guid projectId)
        {
            var project = _context.Projects.Find(projectId);
            if (project == null)
                return null;
            return project;
        }
        public List<Project>? GetProjectsByDate(string date, string equalType)
        {
            List<Project>? project = null;

            if (equalType.Equals("less"))
            {
                project = _context.Projects.Where(x => x.StartDate <= DateTime.Parse(date).ToUniversalTime()).ToList();
            }
            if (equalType.Equals("more"))
            {
                project = _context.Projects.Where(x => x.StartDate >= DateTime.Parse(date).ToUniversalTime()).ToList();
            }
            if (project == null)
                return null;
            return project;
        }

        List<Project>? IProjectService.GetProjectsByDates(string startDate, string endDate)
        {
            var project = _context.Projects.Where(x => x.StartDate >= DateTime.Parse(startDate).ToUniversalTime() 
                                                && x.CompletionDate <= DateTime.Parse(endDate).ToUniversalTime()).ToList();
            if (project == null)
                return null;
            return project;
        }

        List<Project>? IProjectService.GetProjectsByPriorities(int priorityFrom, int priorityTo)
        {
            var project = _context.Projects.Where(x => x.Priority >= priorityFrom 
                                                && x.Priority <= priorityTo).ToList();
            if (project == null)
                return null;
            return project;
        }

        List<Project>? IProjectService.GetProjectsByPriority(int priority, string equalType)
        {
            List<Project>? project = null;

            if (equalType.Equals("less"))
            {
                project = _context.Projects.Where(x => x.Priority <= priority).ToList();
            }
            if (equalType.Equals("more"))
            {
                project = _context.Projects.Where(x => x.Priority >= priority).ToList();
            }
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
            try
            {
                var project = _context.Projects.Find(id);

                if (project == null)
                    return "Project with this id not found";

                if (_context.Projects.FirstOrDefault(x => x.Name != project.Name && x.Name == projectToUpdate.Name) != default)
                    return "Project with this name is already exists";


                project.Name = projectToUpdate.Name;
                project.StartDate = projectToUpdate.StartDate;
                project.CompletionDate = projectToUpdate.CompletionDate;
                project.CurrentStatus = projectToUpdate.CurrentStatus;
                project.Priority = projectToUpdate.Priority;
                project.UpdatedOn = DateTime.Now.ToUniversalTime();

                _context.SaveChanges();



                return "ok";
            }
            catch
            {
                return "failed";
            }
        }        
    }
}
