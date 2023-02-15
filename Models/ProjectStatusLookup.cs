namespace TaskTrackerAPI.Models
{
    public class ProjectStatusLookup
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public string? Description { get; set; }

    }
}
