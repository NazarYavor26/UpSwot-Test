using Newtonsoft.Json;

namespace UpSwot_Test.DAL.Entities.Episodes
{
    public class Episode
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        [JsonProperty("air_date")]
        public string? AirDate { get; set; }

        [JsonProperty("episode")]
        public string? EpisodeNumber { get; set; }
    }
}
