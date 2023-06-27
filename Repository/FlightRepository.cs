using flights.models;
using flights.ViewModels;
using Microsoft.EntityFrameworkCore;
using flights.Filter;
namespace Repository
{
    /// <summary>
    /// репозиторий полетов
    /// </summary>
    public class FlightRepository
    {
        /// <summary>
        /// конетекст БД
        /// </summary>
        public DemoContext context;

        /// <summary>
        /// щконструктор с БД контекстом
        /// </summary>
        /// <param name="context">демо контекст</param>
        public FlightRepository(DemoContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// список полетов (пагинация, фильтры)
        /// </summary>
        /// <param name="filter">фильтр</param>
        /// <returns></returns>
        public async Task<(ICollection<Flight>, FlightFilter)> GetFlightsAsync(FlightFilter filter)
        {

            List<Flight> flights = await context.Flights
                .AsNoTracking()
                .OrderBy(x => x.FlightId)
                .Arrival(filter.Arrival)
                .Status(filter.Status)
                .ArriveMin(filter.ScheduledArriveMin)
                .ArriveMax(filter.ScheduledArriveMax)
                .Number(filter.Number)
                .Skip(filter.Pagination.OnPage * (filter.Pagination.Page - 1))
                .Take(filter.Pagination.OnPage)
                .ToListAsync();


            filter.Pagination.Total = await context.Flights
               .Arrival(filter.Arrival)
                .Status(filter.Status)
                .ArriveMin(filter.ScheduledArriveMin)
                .ArriveMax(filter.ScheduledArriveMax)
                .Number(filter.Number)
                .CountAsync();

            return (flights, filter);

        }

        /// <summary>
        /// информация о полете
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        public async Task<Flight?> GetFlightAsync(int id)
        {

            Flight? flight = await context.Flights.FindAsync(id);

            return flight;
        }
    }
}