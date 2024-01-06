namespace ToDo.Api.Configurations;

public static partial class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
       builder
            .AddBusinessLogicInfrastructure()
            .AddExposers()
            .AddDevTools()
            .AddCors()
            .AddMappers()
            .AddValidators();

        return new();
    }

    public static ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        app.UseCors();
        app.UseExposers().UseDevTools();

        return new(app);
    }
}