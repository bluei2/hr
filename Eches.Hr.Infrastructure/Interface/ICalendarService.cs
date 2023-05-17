using System;
using System.Globalization;
using Eches.Hr.Infrastructure.Model;

namespace Eches.Hr.Infrastructure.Interface
{
	public interface ICalendarService
	{
        Task                        CreateAsync(CalendarModel model);
        Task                        UpdateAsync(CalendarModel model);
        Task<CalendarModel>          GetAsync(int? id);
        Task<List<CalendarModel>>    GetAllAsync();
        Task                        DeleteAsync(int? id);
    }       
}

