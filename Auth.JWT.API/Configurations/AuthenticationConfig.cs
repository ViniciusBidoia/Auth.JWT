using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Auth.JWT.API.Configurations
{
    public static class AuthenticationConfig
    {
        public static IServiceCollection AddAuthenticationConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        //options.RequireHttpsMetadata = false;
                        //options.SaveToken = true;
                        //options.Audience = configuration.GetSection("Jwt:Audience").Value;                              
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = false,
                            ValidateAudience = false,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ClockSkew = TimeSpan.Zero,
                            //ValidAudience = configuration.GetSection("Tokens:Audience").Value,
                            //ValidIssuer = configuration.GetSection("Tokens:Issuer").Value,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("Jwt:Key").Value))
                        };
                    });

            return services;
        }
    }
}
