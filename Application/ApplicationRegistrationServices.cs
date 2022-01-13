using Application.Profiles;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ApplicationRegistrationServices
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            /*var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfiles());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);*/
            //services.AddAutoMapper(Assembly.GetExecutingAssembly()); //Assembly.GetExecutingAssembly()
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddAutoMapper(Assembly.Load("Profiles"));

            //services.AddCustomConfiguredAutoMapper();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
