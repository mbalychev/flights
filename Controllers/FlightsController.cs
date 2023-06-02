using flights.models;
using Microsoft.AspNetCore.Mvc;
using flights.Extensions;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using flights.ViewModels;
using flights.Repository;
using Newtonsoft.Json;

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
        /// репозиторий полетов
        /// </summary>
        FlightRepository repository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        public FlightsController(FlightRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// список полетов (пагинация, фильтры)
        /// </summary>
        /// <param name="filter">фильтраци</param>
        /// <returns></returns>
        [HttpPost("")]
        public async Task<IActionResult> GetTModels(FlightFilter? filter)
        {

            if (filter?.Pagination is not null && !filter.Pagination.CheckPagination())
                return NotFound(PaginationsExtensions.BadPaginationMessage());

            filter = (filter is null) ? new FlightFilter() : filter;

            (ICollection<Flight> flights, FlightFilter filterUpdate) = await repository.GetFlightsAsync(filter);

            FlightsView model = new FlightsView(flights, filterUpdate);

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
            Flight? flight = await repository.GetFlightAsync(id);

            if (flight is null)
                return NotFound(new ErrorView("не найдено", id.ToString()));

            return Ok((flight));
        }

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