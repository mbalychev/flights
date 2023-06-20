using System.ComponentModel.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using flights.models;
using flights.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using flights.ViewModels;
//using flights.Models;

namespace flights.Controllers
{
    /// <summary>
    /// информация/упралвение воздушными судами
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftController : ControllerBase
    {
        /// <summary>
        ///  demo context
        /// </summary>
        public DemoContext _context;
        /// <summary>
        /// инициализация 
        /// </summary>
        public AircraftController(DemoContext context)
        {
            _context = context;
        }

        /// <summary>
        /// список воздушных судов
        /// </summary>
        /// <param name="pagination">пагинация</param>
        /// <param name="minRange">мин радиус полета</param>
        /// <param name="maxRange">макс радиус полета</param>
        /// <returns></returns>
        [HttpPost("")]
        public async Task<ActionResult<IEnumerable<Aircraft>>> GetTModels(Pagination? pagination, int? minRange, int? maxRange)
        {
            if (!pagination.CheckPagination())
                return BadRequest(PaginationsExtensions.BadPaginationMessage());

            if (pagination is null)
                pagination = new Pagination();

            //если значения пустые - ставим по умолчнию
            minRange = (minRange is null) ? 0 : minRange;
            maxRange = (maxRange is null) ? await _context.Aircrafts.Select(x => x.Range).MaxAsync() : maxRange;

            ICollection<Aircraft> aircrafts = await _context.Aircrafts
            .OrderBy(x => x.AircraftCode)
            .Where(x => x.Range >= minRange && x.Range <= maxRange)
            .Skip(pagination.OnPage * (pagination.Page - 1))
            .Take(pagination.OnPage)
            .ToListAsync();

            pagination.Total = aircrafts.Count();

            AircraftView model = new AircraftView(aircrafts, pagination);

            return Ok(model);
        }

        /// <summary>
        /// информация о воздушном судне
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Aircraft>> GetTModelById(int id)
        {
            Aircraft? aircraft = await _context.Aircrafts.FindAsync(id);

            if (aircraft is null)
                return NotFound(new ErrorView("не найдено", id.ToString()));

            return Ok(aircraft);
        }

        // [HttpPost("")]
        // public async Task<ActionResult<TModel>> PostTModel(TModel model)
        // {
        //     // TODO: Your code here
        //     await Task.Yield();

        //     return null;
        // }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutTModel(int id, TModel model)
        // {
        //     // TODO: Your code here
        //     await Task.Yield();

        //     return NoContent();
        // }

        // [HttpDelete("{id}")]
        // public async Task<ActionResult<TModel>> DeleteTModelById(int id)
        // {
        //     // TODO: Your code here
        //     await Task.Yield();

        //     return null;
        // }
    }
}