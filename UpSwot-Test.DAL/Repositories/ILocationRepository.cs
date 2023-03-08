using UpSwot_Test.DAL.Entities;

namespace UpSwot_Test.DAL.Repositories
{
    public interface ILocationRepository
    {
        Task<Location?> GetByUriAsync(string? uri);
    }
}
