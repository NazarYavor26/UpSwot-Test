using UpSwot_Test.BLL.Models;
using UpSwot_Test.BLL.Utilities;
using UpSwot_Test.DAL.Repositories;

namespace UpSwot_Test.BLL.Services
{
    public class PersonService : IPersonService
    {
        private readonly ICharacterRepository characterRepository;
        private readonly IEpisodeRepository episodeRepository;
        private readonly Mapper mapper;

        public PersonService(
            ICharacterRepository character,
            IEpisodeRepository episode,
            Mapper objectMapper)
        {
            characterRepository = character;
            episodeRepository = episode;
            mapper = objectMapper;
        }

        public async Task<bool?> CheckPersonAsync(CheckPersonModel names)
        {
            if (!(await characterRepository.IsExistCharacterWithNameAsync(names.PersonName).ConfigureAwait(false)) ||
                !(await episodeRepository.IsExistEpisodeWithNameAsync(names.EpisodeName).ConfigureAwait(false)))
            {
                return null;
            }

            var characters = await characterRepository.GetCharactersByNameAsync(names.PersonName!)
                .ConfigureAwait(false);

            return characters
                .Any(character => character.ObjectEpisodes
                .Any(episode => episode.Name == names.EpisodeName));
        }

        public async Task<CharacterModel?> GetPersonAsync(string name)
        {
            var person = (await characterRepository.GetCharactersByNameAsync(name).ConfigureAwait(false))?
                .FirstOrDefault(person => person.Name == name);

            return person == null ? null : mapper.Map(person);
        }
    }
}
