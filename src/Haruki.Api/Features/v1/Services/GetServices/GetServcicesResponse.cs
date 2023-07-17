using Haruki.Api.Commons.Mappings;
using Haruki.Api.Domains.Entities;

namespace Haruki.Api.Features.v1.Services.GetServices;

public class GetServicesResponse : IMapFrom<Service>
{
    public Guid Id { get; set; }

    public string Name { get; set; }
}