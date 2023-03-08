using UpSwot_Test.BLL.Models;

namespace UpSwot_Test.BLL.Services
{
    public interface IPersonService
    {
        Task<bool?> CheckPersonAsync(CheckPersonModel names);

        Task<CharacterModel?> GetPersonAsync(string name);
    }
}
