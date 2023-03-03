using System.Text.Json.Serialization;

namespace TaskTrackerAPI.Models
{
    public class Project
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        [JsonIgnore]
        public DateTime CreatedOn { get; set; }
        [JsonIgnore]
        public DateTime UpdatedOn { get; set; }
        public Guid? CurrentStatusId { get; set; } = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
        [JsonIgnore]
        public ProjectStatusLookup? CurrentStatus { get; set; }
        public int Priority { get; set; }
        [JsonIgnore]
        public List<Tasks>? Tasks { get; set; }

    }
}
