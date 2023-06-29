using Pasquale.Plant.Api.Commons.Interfaces;

namespace Pasquale.Plant.Api.Services;

public class DateTimeService : IDateTimeService
{
    public DateTime Now => DateTime.Now;
}