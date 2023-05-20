using Microsoft.AspNetCore.Mvc;
using Eches.Hr.Infrastructure.Model;
using Eches.Hr.Infrastructure.Interface;

namespace Eches.Hr.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[MiddlewareFilter(typeof(ExceptionMiddleware))]
    public class CalendarController : ControllerBase
    {
        private readonly ICalendarService _calendarService;

        public CalendarController(ICalendarService calendarService)
        {
            _calendarService = calendarService;
        }


        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync(CalendarModel model)
        {
            try
            {
               await _calendarService.CreateAsync(model);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(CalendarModel model)
        {
            try
            {
                await _calendarService.UpdateAsync(model);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet("Get")]
        public async Task<CalendarModel> GetAsync(int? id)
        {
            return await _calendarService.GetAsync(id);
        }

        [HttpDelete("Delete")]
        public async Task DeleteAsync(int? id)
        {
            await _calendarService.DeleteAsync(id);
        }
    }
}

