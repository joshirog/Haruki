namespace Haruki.Api.Commons.Interfaces;

public interface IJsonSerializerService
{
    string Serialize<T>(T input);

    T Deserialize<T>(string input);
}