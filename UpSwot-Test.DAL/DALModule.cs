using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UpSwot_Test.DAL.Repositories;

namespace UpSwot_Test.DAL
{
    public class DALModule
    {
        public static void Load(IServiceCollection services, IConfiguration configuration)
        {
            // Entities repositories
            services.AddTransient<ICharacterRepository, CharacterRepository>();
            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<IEpisodeRepository, EpisodeRepository>();
        }
    }
}