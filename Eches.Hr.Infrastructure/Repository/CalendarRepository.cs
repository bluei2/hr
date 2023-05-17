using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eches.Hr.Infrastructure.Repository;
[Table("Calendars")]
public class CalendarRepository
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string WeekStartDay { get; set; }
    public int? Year { get; set; }
    public string DivisionId { get; set; }
    public int? State { get; set; }
}


