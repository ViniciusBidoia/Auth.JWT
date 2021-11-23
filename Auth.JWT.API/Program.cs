using Auth.JWT.API.Configurations;

//Antigo ConfigureServices
#region Services
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHealthChecks();
builder.Services.AddSwaggerConfig();
builder.Services.AddSqlCongiguration(builder.Configuration);
builder.Services.AddDependenceInjectionConfig();
builder.Services.AddAuthenticationConfig(builder.Configuration);
#endregion

//Antigo Configure
#region App
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseHealthChecks(new PathString("/HealthCheck"));
app.Run();
#endregion
