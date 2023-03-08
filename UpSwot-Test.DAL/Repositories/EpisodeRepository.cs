using Newtonsoft.Json;
using UpSwot_Test.DAL.Entities.Episodes;

namespace UpSwot_Test.DAL.Repositories
{
    public class EpisodeRepository : RepositoryBase, IEpisodeRepository
    {
        public EpisodeRepository(HttpClient http) : base(http) { }

        public async Task<Episode?> GetByUriAsync(string uri) =>
           await GetDeserializedEpisodeByUriAsync<Episode>(uri).ConfigureAwait(false);

        public async Task<bool> IsExistEpisodeWithNameAsync(string? name)
        {
            return name != null && (await GetEpisodesByNameAsync(name).ConfigureAwait(false)).Count > 0;
        }

        public async Task<List<Episode>> GetEpisodesByNameAsync(string name)
        {
            var episodesList = new List<Episode>();

            var nextPageUri = $"episode?name={name}";

            while (nextPageUri != null)
            {
                var nextPageEpisodeJson =
                    await GetDeserializedEpisodeByUriAsync<EpisodeJson>(nextPageUri)
                    .ConfigureAwait(false);

                if (nextPageEpisodeJson?.Episodes == null)
                {
                    break;
                }

                episodesList.AddRange(nextPageEpisodeJson.Episodes);

                nextPageUri = nextPageEpisodeJson.Info!.Next;
            }

            return episodesList
                .Where(episode => episode.Name == name)
                .ToList();
        }

        private async Task<TEntity?> GetDeserializedEpisodeByUriAsync<TEntity>(string uri)
        {
            var result = await http.GetAsync(uri).ConfigureAwait(false);

            var episode = await result.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<TEntity?>(episode);
        }
    }
}
