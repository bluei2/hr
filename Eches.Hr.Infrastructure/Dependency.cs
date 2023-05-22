using Eches.Hr.Infrastructure.Abstract;
using Eches.Hr.Infrastructure.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Eches.Hr.Infrastructure.Configuration;
public static class Dependency
{
    public static void ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<ICalendarService, CalendarService>();
    }
}

