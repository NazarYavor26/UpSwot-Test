using UpSwot_Test.DAL.Entities.Episodes;

namespace UpSwot_Test.DAL.Repositories
{
    public interface IEpisodeRepository
    {
        Task<bool> IsExistEpisodeWithNameAsync(string? name);

        Task<Episode?> GetByUriAsync(string uri);
    }
}
