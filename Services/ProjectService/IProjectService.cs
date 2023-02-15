namespace TaskTrackerAPI.Services.ProjectService
{
    public interface IProjectService
    {
        List<Project>? GetAllProjects();
        Project? GetProject(Guid projectId);
        string AddProject(Project project);
        string RemoveProject(Guid projectId);
        string UpdateProject(Project project, Guid projectId);
    }
}
