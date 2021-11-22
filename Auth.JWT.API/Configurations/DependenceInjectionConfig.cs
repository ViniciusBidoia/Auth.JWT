using Auth.JWT.Application.Interfaces;
using Auth.JWT.Application.Services;
using Auth.JWT.Data.Respositories;
using Auth.JWT.Domain.Interfaces.Repositories;
using Auth.JWT.Domain.Interfaces.Services;
using Auth.JWT.Domain.Services;

namespace Auth.JWT.API.Configurations
{
    public static class DependenceInjectionConfig
    {
        public static IServiceCollection AddDependenceInjectionConfig(this IServiceCollection services)
        {
            #region Base_DDD

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
