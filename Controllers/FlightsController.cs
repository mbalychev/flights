using flights.models;
using Microsoft.AspNetCore.Mvc;
using flights.Extensions;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using flights.ViewModels;

/// <summary>
/// управление/информация полетам
/// </summary>
namespace flights.Controllers
{

    /// <summary>
    /// управление/информация полетам
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        /// <summary>
        /// контекст БД
        /// </summary>
        DemoContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public FlightsController(DemoContext context)
        {
            _context = context;
        }

        /// <summary>
        /// список полетов (пагинация, фильтры)
        /// </summary>
        /// <param name="pagination">пагинация</param>
        /// <param name="arrival">место прибытия</param>
        /// <param name="status">статус рейса</param>
        /// <param name="scheduledArriveMin">мин время прибытия</param>
        /// <param name="scheduledArriveMax">макс время прибытия</param>
        /// <returns></returns>
        [HttpPost("")]
        public async Task<ActionResult<IEnumerable<Flight>>> GetTModels(
            Pagination? pagination,
            string? arrival,
            string? status,
            DateTime? scheduledArriveMin,
            DateTime? scheduledArriveMax)
        {
            if (!pagination.CheckPagination())
                return NotFound(PaginationsExtensions.BadPaginationMessage());

            if (pagination is null)
                pagination = new Pagination();

            //значения по умолчанию
            scheduledArriveMin = (scheduledArriveMin is null) ? await _context.Flights.Select(x => x.ScheduledArrival).MinAsync() : scheduledArriveMin;
            scheduledArriveMax = (scheduledArriveMax is null) ? await _context.Flights.Select(x => x.ScheduledArrival).MaxAsync() : scheduledArriveMax;

            ICollection<Flight> flights = await _context.Flights
                .OrderBy(x => x.FlightId)
                .Where(x => x.ScheduledArrival >= scheduledArriveMin &&
                        x.ScheduledArrival <= scheduledArriveMax &&
                        x.ArrivalAirport == arrival &&
                        x.Status == status)
                .Skip(pagination.OnPage * (pagination.Page - 1))
                .Take(pagination.OnPage)
                .ToListAsync();

            pagination.Total = flights.Count();

            FlightsView model = new FlightsView(flights, pagination);

            return Ok(model);
        }

        /// <summary>
        /// данные о полете
        /// </summary>
        /// <param name="id">id полета</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Flight>> GetTModelById(int id)
        {
            Flight? flight = await _context.Flights.FindAsync(id);

            if (flight is null)
                return NotFound(new ErrorView("не найдено", id.ToString()));

            return Ok(JsonSerializer.Serialize(flight));
        }

        // [HttpPost("")]
        // public ActionResult<TModel> PostTModel(TModel model)
        // {
        //     return null;
        // }

        // [HttpPut("{id}")]
        // public IActionResult PutTModel(int id, TModel model)
        // {
        //     return NoContent();
        // }

        // [HttpDelete("{id}")]
        // public ActionResult<TModel> DeleteTModelById(int id)
        // {
        //     return null;
        // }
    }
}