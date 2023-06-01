using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using flights.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace flights.Controllers
{
    /// <summary>
    /// Аэропорты
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        DemoContext _context;

        public AirportController(DemoContext context)
        {
            _context = context;
        }

        /// <summary>
        /// список аэропортов
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpPost("read")]
        public async Task<ActionResult<IEnumerable<Airport>>> GetTModels(Pagination? pagination)
        {
            if (!CheckPagination(pagination))
                return BadRequest(new ErrorView("ошибка", "не верная модель пагинации"));

            if (pagination is null)
                pagination = new Pagination();

            ICollection<Airport> airports = await _context.Airports
                .Skip(pagination.OnPage * (pagination.Page - 1))
                .Take(pagination.OnPage)
                .ToListAsync();

            pagination.total = await _context.Airports.CountAsync();

            AirportView model = new AirportView(airports, pagination);

            return Ok(model);
        }

        /// <summary>
        /// проверка модели пагинации на корректность
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        private bool CheckPagination(Pagination? pagination)
        {

            if (pagination is null) return true;

            if (pagination.OnPage <= 0 || pagination.Page <= 0) return false;

            return true;
        }

        /// <summary>
        /// сведения о аэропорте
        /// </summary>
        /// <param name="id">id аэропорта</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Airport>> GetTModelById(int id)
        {
            Airport? model = await _context.Airports.FindAsync(id);

            if (model is null)
                return NotFound(new ErrorView("не найдено", id.ToString()));

            return Ok(model);
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