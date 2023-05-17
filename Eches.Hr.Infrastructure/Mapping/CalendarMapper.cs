using System;
using Eches.Hr.Infrastructure.Model;
using Eches.Hr.Infrastructure.Repository;

namespace Eches.Hr.Infrastructure.Mapping
{
    public static class CalendarMapper
    {
        public static CalendarRepository ToRepository(this CalendarModel model)
        {
            return new CalendarRepository
            {
                Id = model.Id,
                Name = model.Name,
                WeekStartDay = model.WeekStartDay,
                Year = model.Year,
                DivisionId = model.DivisionId,
                State = model.State
            };
        }
        public static CalendarModel ToModel(this CalendarRepository repository)
        {
            return new CalendarModel
            {
                Id = repository.Id,
                Name = repository.Name,
                WeekStartDay = repository.WeekStartDay,
                Year = repository.Year,
                DivisionId = repository.DivisionId,
                State = repository.State
            };
        }

        public static List<CalendarModel> ToViewModel(this List<CalendarRepository> repositories)
        {
            return repositories.Select(x => x.ToModel()).ToList();
        }

        public static List<CalendarRepository> ToRepositories(this List<CalendarModel> viewModel)
        {
            return viewModel.Select(x => x.ToRepository()).ToList();
        }
    }
}

