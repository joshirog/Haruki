using Pasquale.Planta.Api.Commons.Interfaces;

namespace Pasquale.Planta.Api.Services;

public class DateTimeService : IDateTimeService
{
    public DateTime Now => DateTime.Now;
}