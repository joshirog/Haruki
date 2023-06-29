using Newtonsoft.Json;
using Pasquale.Plant.Api.Commons.Interfaces;

namespace Pasquale.Plant.Api.Services;

public class JsonSerializerService : IJsonSerializerService
{
    public string Serialize<T>(T input)
    {
        return JsonConvert.SerializeObject(input);
    }

    public T Deserialize<T>(string input)
    {
        return JsonConvert.DeserializeObject<T>(input);
    }
}