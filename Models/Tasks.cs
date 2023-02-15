using System.Text.Json.Serialization;

namespace TaskTrackerAPI.Models
{
    public class Tasks
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        [JsonIgnore]
        public Project? Project { get; set; }
        public string Name { get; set; }
        public Guid? CurrentTaskStatusId { get; set; } = Guid.Parse("2df17c92-28ac-4739-aa75-da4c21b3ec57");
        [JsonIgnore]
        public TaskStatusLookup? CurrentTaskStatus { get; set; }
        public string? Description { get; set; }
        public int? Priority { get; set; }

    }
}
