using Auth.JWT.API.AutoMapper;
using Auth.JWT.Application.Interfaces;
using Auth.JWT.Application.Services;
using Auth.JWT.Data.Respositories;
using Auth.JWT.Domain.Interfaces.Repositories;
using Auth.JWT.Domain.Interfaces.Services;
using Auth.JWT.Domain.Services;
using AutoMapper;

namespace Auth.JWT.API.Configurations
{
    public static class DependenceInjectionConfig
    {
        public static IServiceCollection AddDependenceInjectionConfig(this IServiceCollection services)
        {
            #region AutoMapper
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperConfig());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            #endregion

            #region Usuario
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            #endregion

            return services;
        }
    }
}
