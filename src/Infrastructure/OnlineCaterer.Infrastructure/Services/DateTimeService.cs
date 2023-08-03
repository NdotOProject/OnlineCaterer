
using OnlineCaterer.Application.Common.Interfaces;

namespace OnlineCaterer.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
