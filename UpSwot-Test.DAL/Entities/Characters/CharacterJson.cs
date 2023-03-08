using Newtonsoft.Json;

namespace UpSwot_Test.DAL.Entities.Characters
{
    public class CharacterJson
    {
        [JsonProperty("info")]
        public CharacterInfo? Info { get; set; }

        [JsonProperty("results")]
        public List<Character>? Characters { get; set; }
    }
}
