using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Exceptions;

namespace Pasquale.Planta.Api.Commons.Configurations.Builders;

public static class ConfigureSerilogBuilder
{
    private const string template = "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff}] [{Level:u3}] [{SourceContext}] {Message:lj}{NewLine}{Exception}";
    
    public static void AddSerilogBuilder(this WebApplicationBuilder builder)
    {
        builder.Logging.ClearProviders();
        
        builder.Host.UseSerilog((context, configuration) =>
            {
                configuration.ReadFrom.Configuration(context.Configuration);
                configuration
                    .Enrich.FromLogContext()
                    .Enrich.WithExceptionDetails()
                    .Enrich.WithMachineName()
                    .Enrich.WithProperty("Environment", builder.Environment.EnvironmentName)
                    .MinimumLevel.ControlledBy(new LoggingLevelSwitch())
                    .MinimumLevel.Override("Microsoft", new LoggingLevelSwitch(LogEventLevel.Warning))
                    .MinimumLevel.Override("Microsoft.EntityFrameworkCore", new LoggingLevelSwitch(LogEventLevel.Warning))
                    .MinimumLevel.Override("Microsoft.Hosting.Lifetime", new LoggingLevelSwitch(LogEventLevel.Warning))
                    .WriteTo.Debug()
                    .WriteTo.File(Path.Combine(Directory.GetCurrentDirectory(), "Logs/Api-.log"),
                        shared: false,
                        rollingInterval: RollingInterval.Day,
                        levelSwitch: new LoggingLevelSwitch(),
                        outputTemplate: template)
                    .WriteTo.Console(outputTemplate: template);
            }
        );
    }
}