using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using flights.models;
using Microsoft.AspNetCore.Mvc;
using flights.Extensions;
using System.Text.Json;
using System.Text.Json.Serialization;
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
        /// список полетов
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Flight>>> GetTModels(Pagination? pagination)
        {
            if (!pagination.CheckPagination())
                return NotFound(PaginationsExtensions.BadPaginationMessage());

            if (pagination is null)
                pagination = new Pagination();

            ICollection<Flight> flights = await _context.Flights
                .Skip(pagination.OnPage * (pagination.Page - 1))
                .Take(pagination.OnPage)
                .ToListAsync();

            pagination.Total = flights.Count();

            FlightsView model = new FlightsView(flights, pagination);

            return Ok(JsonSerializer.Serialize(model));
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