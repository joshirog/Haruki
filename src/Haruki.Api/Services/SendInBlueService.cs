using System.Net.Mime;
using System.Text;
using System.Text.Json;
using Haruki.Api.Commons.Constants;
using Haruki.Api.Commons.Dtos;
using Haruki.Api.Commons.Interfaces;

namespace Haruki.Api.Services;

public class SendInBlueService : INotificationService
{
    private readonly ILogger<SendInBlueService> _logger;
    private readonly IHttpClientFactory _clientFactory;

    public SendInBlueService(ILogger<SendInBlueService> logger, IHttpClientFactory clientFactory)
    {
        _logger = logger;
        _clientFactory = clientFactory;
    }

    public async Task<string> SendEmail(EmailDto entity)
    {
        _logger.LogInformation("SendInBlueClient : Sending email ... to {@Subject}", entity.Subject);
            
        var client = _clientFactory.CreateClient(EndpointConstant.SendInBlue);
            
        var response = await client.PostAsync(EndpointConstant.SendInBlueUriEmail, 
            new StringContent(JsonSerializer.Serialize(entity, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            }), Encoding.UTF8, MediaTypeNames.Application.Json));
            
        var result = await response.Content.ReadAsStringAsync();
            
        if (response.IsSuccessStatusCode)
        {
            _logger.LogInformation("SendInBlueClient : {@Id}", result);
        }
        else
        {
            _logger.LogError("SendInBlueClient : error {@Id}", result);
        }

        return result;
    }
}