using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UpSwot_Test.BLL.Services;
using UpSwot_Test.BLL.Utilities;
using UpSwot_Test.DAL;

namespace UpSwot_Test.BLL
{
    public class BLLModule
    {
        public static void Load(IServiceCollection services, IConfiguration configuration)
        {
            // Entities services
            services.AddTransient<IPersonService, PersonService>();

            // Utilities
            services.AddTransient<Mapper>();

            DALModule.Load(services, configuration);
        }
    }
}