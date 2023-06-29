using Haruki.Api.Commons.Interfaces;

namespace Haruki.Api.Services;

public class DateTimeService : IDateTimeService
{
    public DateTime Now => DateTime.Now;
}