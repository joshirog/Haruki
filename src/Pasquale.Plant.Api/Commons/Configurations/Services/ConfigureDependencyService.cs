using System.Globalization;
using System.Reflection;
using FluentValidation;
using MediatR;
using Pasquale.Plant.Api.Commons.Behaviours;
using Pasquale.Plant.Api.Commons.Interfaces;
using Pasquale.Plant.Api.Services;

namespace Pasquale.Plant.Api.Commons.Configurations.Services;

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