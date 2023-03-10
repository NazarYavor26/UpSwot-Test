using Newtonsoft.Json;
using UpSwot_Test.DAL.Entities;

namespace UpSwot_Test.DAL.Repositories
{
    public class LocationRepository : RepositoryBase, ILocationRepository
    {
        public LocationRepository(HttpClient http) : base(http) { }

        public async Task<Location?> GetByUriAsync(string? uri) =>
            await GetDeserializedLocationByUriAsync(uri).ConfigureAwait(false);

        private async Task<Location?> GetDeserializedLocationByUriAsync(string? uri)
        {
            var result = await http.GetAsync(uri).ConfigureAwait(false);

            var location = await result.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<Location?>(location);
        }
    }
}
