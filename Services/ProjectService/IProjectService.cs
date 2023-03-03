namespace TaskTrackerAPI.Services.ProjectService
{
    public interface IProjectService
    {
        List<Project>? GetAllProjects();
        Project? GetProjectById(Guid projectId);
        List<Project>? GetProjectsByDate(string date, string equalType);
        List<Project>? GetProjectsByDates(string startDate, string endDate);
        List<Project>? GetProjectsByPriority(int priority, string equalType);
        List<Project>? GetProjectsByPriorities(int priorityFrom, int priorityTo);
        string AddProject(Project project);
        string RemoveProject(Guid projectId);
        string UpdateProject(Project project, Guid projectId);
    }
}
