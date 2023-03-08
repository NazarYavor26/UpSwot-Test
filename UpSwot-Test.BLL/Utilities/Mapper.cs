using UpSwot_Test.BLL.Models;
using UpSwot_Test.DAL.Entities;
using UpSwot_Test.DAL.Entities.Characters;

namespace UpSwot_Test.BLL.Utilities
{
    public class Mapper
    {
        public CharacterModel Map(Character source)
        {
            return new CharacterModel()
            {
                Name = source.Name,
                Status = source.Status,
                Species = source.Species,
                Type = source.Type,
                Gender = source.Gender,
                Origin = Map(source.Origin),
            };
        }

        public LocationModel Map(Location? source)
        {
            return new LocationModel()
            {
                Name = source?.Name,
                Dimension = source?.Dimension,
                Type = source?.Type,
            };
        }
    }
}
