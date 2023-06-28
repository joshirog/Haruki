using System.Globalization;
using System.Reflection;
using FluentValidation;
using MediatR;
using Pasquale.Planta.Api.Commons.Behaviours;
using Pasquale.Planta.Api.Commons.Interfaces;
using Pasquale.Planta.Api.Services;

namespace Pasquale.Planta.Api.Commons.Configurations.Services;

public static class ConfigureDependencyService
{
    public static void AddDependencyService(this IServiceCollection services)
    {
        ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("es");

        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));

        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddScoped<IDateTimeService, DateTimeService>();
        services.AddScoped<IJsonSerializerService, JsonSerializerService>();
        services.AddScoped<IDomainEventService, DomainEventService>();
    }
}