using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eches.Hr.Infrastructure.Interface;
using Eches.Hr.Infrastructure.Model;
using Eches.Hr.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace Eches.Hr.Test
{
    public class CalendarServiceTest
    {
        public class Startup
        {
            public void ConfigureServices(IServiceCollection services) { }
        }

        private readonly ICalendarService _calendarService;
        public CalendarServiceTest()
        {
            _calendarService = new Mock<ICalendarService>().Object;
        }

        [Fact]
        public async void CreateCalendar()
        {
            try
            {
                var model = new CalendarModel
                {
                    Name = "W1",
                    WeekStartDay = "Monday",
                    Year = 2023,
                    DivisionId = "N/A",
                    State = 1
                };

                await _calendarService.CreateAsync(model);
                Assert.NotNull(model);
            }

            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }

        [Fact]
        public async void GetCalendar()
        {
            var calendar = await _calendarService.GetAsync(1);
            Assert.NotNull(calendar);
        }
    }
}
