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

        /// <summary>
        /// для справочников возд судов
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<TAircrafts>> GetAircrafts()
        {
            ICollection<TAircrafts> models = await context.Aircrafts.Select(x => new TAircrafts { Code = x.AircraftCode, Model = x.Model }).ToListAsync();

            return models;
        }

        /// <summary>
        /// поиск по номеру рейса
        /// </summary>
        /// <param name="contains"></param>
        /// <returns></returns>
        public async Task<ICollection<string>> FindFlightsNum(string contains)
        {
            ICollection<string> numbers = await context.Flights
            .Where(x => x.FlightNo
            .Contains(contains.ToUpper()))
            .Select(x => x.FlightNo)
            .Distinct()
            .Take(10)
            .ToListAsync();

            return numbers;
        }

    }
}