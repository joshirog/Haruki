using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Pasquale.Plant.Api.Services;

public class IdentityEmailService<T> : DataProtectorTokenProvider<T> where T : class
{
    public IdentityEmailService(IDataProtectionProvider provider, IOptions<IdentityEmailServiceOptions> options, ILogger<IdentityEmailService<T>> logger)
        : base(provider, options, logger)
    {

    }
}

public class IdentityEmailServiceOptions : DataProtectionTokenProviderOptions
{

}