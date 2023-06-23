using flights.models;
using flights.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repository
{

    /// <summary>
    /// справочник
    /// </summary>
    public class ThesaurusRepository
    {
        /// <summary>
        /// конетекст БД
        /// </summary>
        private DemoContext context;

        /// <summary>
        /// щконструктор с БД контекстом
        /// </summary>
        /// <param name="context">демо контекст</param>
        public ThesaurusRepository(DemoContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// справочник аэропортов
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<TAirport>> GetAirports()
        {
            ICollection<TAirport> airports = await context.Airports.Select(x => new TAirport { Code = x.AirportCode, Name = x.AirportName }).ToListAsync();

            return airports;
        }

    }
}