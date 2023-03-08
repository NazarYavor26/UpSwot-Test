namespace UpSwot_Test.DAL.Repositories
{
    public class RepositoryBase
    {
        protected readonly HttpClient http;
        private const string BASE_URI = "https://rickandmortyapi.com/api/";

        public RepositoryBase(HttpClient httpClient)
        {
            http = httpClient;
            http.BaseAddress = new Uri(BASE_URI);
        }
    }
}
