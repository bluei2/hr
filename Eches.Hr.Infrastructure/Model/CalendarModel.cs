using System;
namespace Eches.Hr.Infrastructure.Model
{
	public class CalendarModel
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string WeekStartDay { get; set; }
        public int? Year { get; set; }
        public string DivisionId { get; set; }
        public int? State { get; set; }
    }
}

