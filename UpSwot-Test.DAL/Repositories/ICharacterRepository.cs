using UpSwot_Test.DAL.Entities.Characters;

namespace UpSwot_Test.DAL.Repositories
{
    public interface ICharacterRepository
    {
        Task<bool> IsExistCharacterWithNameAsync(string? name);

        Task<List<Character>> GetCharactersByNameAsync(string name);
    }
}
