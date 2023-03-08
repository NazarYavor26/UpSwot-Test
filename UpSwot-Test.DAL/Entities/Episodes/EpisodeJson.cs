using Newtonsoft.Json;

namespace UpSwot_Test.DAL.Entities.Episodes
{
    public class EpisodeJson
    {
        [JsonProperty("info")]
        public EpisodeInfo? Info { get; set; }

        [JsonProperty("results")]
        public List<Episode>? Episodes { get; set; }
    }
}
