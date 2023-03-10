using Newtonsoft.Json;
using UpSwot_Test.DAL.Entities.Characters;

namespace UpSwot_Test.DAL.Repositories
{
    public class CharacterRepository : RepositoryBase, ICharacterRepository
    {
        private readonly ILocationRepository locationRepository;
        private readonly IEpisodeRepository episodeRepository;

        public CharacterRepository(
            HttpClient httpClient,
            ILocationRepository location,
            IEpisodeRepository episode)
            : base(httpClient)
        {
            locationRepository = location;
            episodeRepository = episode;
        }

        public async Task<bool> IsExistCharacterWithNameAsync(string? name)
        {
            return name != null && (await GetCharactersByNameAsync(name).ConfigureAwait(false)).Count > 0;
        }

        public async Task<List<Character>> GetCharactersByNameAsync(string name)
        {
            var charactersList = new List<Character>();

            var nextPageUri = $"character?name={name}";

            while (nextPageUri != null)
            {
                var nextPageCharacterJson =
                    await GetDeserializedCharacterJsonByUriAsync(nextPageUri)
                    .ConfigureAwait(false);

                if (nextPageCharacterJson?.Characters == null)
                {
                    break;
                }

                charactersList.AddRange(nextPageCharacterJson.Characters);

                nextPageUri = nextPageCharacterJson.Info!.Next;
            }

            foreach (var character in charactersList)
            {
                character.Origin = await locationRepository.GetByUriAsync(character.Origin?.Url)
                    .ConfigureAwait(false);

                if (character.LinkEpisode == null)
                {
                    continue;
                }

                var result = await Task.WhenAll(character.LinkEpisode
                    .Select(async episodeLink => await episodeRepository
                    .GetByUriAsync(episodeLink)
                    .ConfigureAwait(false)));

                character.ObjectEpisodes.AddRange(result!);
            }

            return charactersList
                .Where(character => character.Name == name)
                .ToList();
        }

        private async Task<CharacterJson?> GetDeserializedCharacterJsonByUriAsync(string uri)
        {
            var result = await http.GetAsync(uri).ConfigureAwait(false);

            var charactersJson = await result.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<CharacterJson?>(charactersJson);
        }
    }
}
