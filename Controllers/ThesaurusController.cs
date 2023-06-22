using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using flights.models;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repository;

namespace flights.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ThesaurusController : Controller
    {

        /// <summary>
        /// справочник
        /// </summary>
        ThesaurusRepository repository;
        /// <summary>
        /// demo context
        /// </summary>
        /// <param name="context"></param>
        /// <param name="repo"></param>
        public ThesaurusController(DemoContext context, ThesaurusRepository repo)
        {
            this.repository = repo;
        }


        /// <summary>
        /// справочник аэропортов
        /// </summary>
        /// <returns></returns>
        [HttpGet("Airports")]
        public async Task<ActionResult<ICollection<TAirport>>> GetTModels()
        {
            ICollection<TAirport> airports = await repository.GetAirports();

            return Ok(airports);
        }


    }
}