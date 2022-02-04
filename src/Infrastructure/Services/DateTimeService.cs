using CleanArchitecth.Application.Common.Interfaces;

namespace CleanArchitecth.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
