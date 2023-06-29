using Haruki.Api.Commons.Configurations.Applications;
using Haruki.Api.Commons.Configurations.Builders;
using Haruki.Api.Commons.Configurations.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.AddSerilogBuilder();
builder.Services.AddConfigurationService(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddIdentityService(builder.Configuration);
builder.Services.AddDependencyService();
builder.Services.AddAuthenticationService();
builder.Services.AddControllerService();
builder.Services.AddCorsService(builder.Configuration);
builder.Services.AddVersionService();
builder.Services.AddSwaggerService();
builder.Services.AddProblemDetails();
builder.Services.AddContextService(builder.Configuration);
builder.Services.AddHangfireService(builder.Configuration);
builder.Services.AddHealthCheckService();
builder.Services.AddTaskService();

var app = builder.Build();
app.AddEnvironmentApplication();
app.UseCors(builder.Configuration.GetSection("AppSettings:Cors").ToString()!);
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.AddHangfireApplication(builder.Configuration);
app.MapControllers();
app.AddHealthCheckApplication();
app.Run();