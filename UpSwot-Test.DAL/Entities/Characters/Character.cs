using Newtonsoft.Json;
using UpSwot_Test.DAL.Entities.Episodes;

namespace UpSwot_Test.DAL.Entities.Characters
{
    public class Character
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Status { get; set; }

        public string? Species { get; set; }

        public string? Type { get; set; }

        public string? Gender { get; set; }

        public Location? Origin { get; set; }

        [JsonProperty("episode")]
        public string[]? LinkEpisode { get; set; }

        public List<Episode> ObjectEpisodes { get; set; } = new();
    }
}
