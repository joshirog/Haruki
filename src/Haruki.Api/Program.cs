using Haruki.Api.Commons.Configurations.Applications;
using Haruki.Api.Commons.Configurations.Builders;
using Haruki.Api.Commons.Configurations.Services;
using Haruki.Api.Commons.Constants;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.AddSettingBuilder();
builder.AddSerilogBuilder();

builder.Services.AddHttpContextAccessor();
builder.Services.AddIdentityService();
builder.Services.AddDependencyService();
builder.Services.AddAuthenticationService();
builder.Services.AddControllerService();
builder.Services.AddCorsService();
builder.Services.AddVersionService();
builder.Services.AddSwaggerService();
builder.Services.AddProblemDetails();
builder.Services.AddContextService();
builder.Services.AddHttpClientService();
builder.Services.AddLazyCache();
builder.Services.AddHangfireService();
builder.Services.AddHealthCheckService();
builder.Services.AddTaskService();

var app = builder.Build();
app.AddEnvironmentApplication();
app.UseCors(SettingConstant.Cors);
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.AddHangfireApplication();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.AddHealthCheckApplication();
app.Run();