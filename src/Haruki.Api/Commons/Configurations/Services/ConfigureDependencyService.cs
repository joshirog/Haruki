using System.Globalization;
using System.Reflection;
using FluentValidation;
using Haruki.Api.Commons.Behaviours;
using Haruki.Api.Commons.Interfaces;
using Haruki.Api.Services;
using MediatR;

namespace Haruki.Api.Commons.Configurations.Services;

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
        services.AddScoped<INotificationService, SendInBlueService>();
        services.AddScoped<ICacheService, LazyCacheService>();
        services.AddScoped<ICaptchaService, GoogleCaptchaService>();
        services.AddScoped<IDomainEventService, DomainEventService>();
    }
}