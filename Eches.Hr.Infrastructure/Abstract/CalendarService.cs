using System;
using Eches.Hr.Infrastructure.Dao;
using Eches.Hr.Infrastructure.Interface;
using Eches.Hr.Infrastructure.Mapping;
using Eches.Hr.Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace Eches.Hr.Infrastructure.Abstract
{
	public class CalendarService: ICalendarService
	{
        protected EchesDbContext _context { get; set; }
        public CalendarService(EchesDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(CalendarModel model)
        {
            var repository = model.ToRepository();

            _context.Calendars.Add(repository);
            await _context.SaveChangesAsync(); 
        }

        public async Task UpdateAsync(CalendarModel model)
        {
            var repository = _context.Calendars.SingleOrDefault(x => x.Id == model.Id);

            _context.Entry(repository).CurrentValues.SetValues(model);
            await _context.SaveChangesAsync();
        }

        public async Task<CalendarModel> GetAsync(int? id)
        {
            var repository = await _context.Calendars.SingleOrDefaultAsync(x => x.Id == id);
            return repository.ToModel();
        }

        public async Task<List<CalendarModel>> GetAllAsync()
        {
            var repository = await _context.Calendars.ToListAsync();
            return repository.ToViewModel();
        }

        public async Task DeleteAsync(int? id)
        {
            var repository = _context.Calendars.SingleOrDefault(x => x.Id == id);

            _context.Remove(repository);
            await _context.SaveChangesAsync();
        }
    }
}

