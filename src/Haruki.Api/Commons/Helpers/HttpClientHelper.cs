namespace Haruki.Api.Commons.Helpers;

public static class HttpClientHelper
{
    public static string DownloadString(HttpClient client, string url)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        var response = client.Send(request);
        using var reader = new StreamReader(response.Content.ReadAsStream());
        return reader.ReadToEnd();
    }
}