namespace ToDo.Api.Configurations;

public static partial class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder.AddBusinessLogicInfrastructure().AddExposers().AddDevTools();

        return new();
    }

    public static ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        app.UseExposers().UseDevTools();

        return new(app);
    }
}