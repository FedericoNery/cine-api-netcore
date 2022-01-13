using Application.Profiles;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    //Para agregar más perfiles
    public static class CustomAutoMapper
    {
        public static void AddCustomConfiguredAutoMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfiles());
            });

            var mapper = config.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
