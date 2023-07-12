using flights.models;
using flights.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    /// <summary>
    /// репозиторий возд судов
    /// </summary>
    public class AircraftRepository
    {
        private DemoContext context;

        /// <summary>
        /// костр по умолчанию
        /// /// </summary>
        /// <param name="context"></param>
        public AircraftRepository(DemoContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// список возд  судов с пагинацией
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<AircraftsView> GetAircrafts(AircraftFilter filter)
        {
            ICollection<Aircraft> aircrafts = await context
                .Aircrafts
                .Where(x => x.Range >= filter.RangeMin && x.Range <= filter.RangeMax)
                .Skip(filter.Pagination.OnPage * --filter.Pagination.Page)
                .Take(filter.Pagination.OnPage)
                .ToListAsync();

            filter.Pagination.Total = await context
                .Aircrafts
                .Where(x => x.Range >= filter.RangeMin && x.Range <= filter.RangeMax)
                .CountAsync();

            AircraftsView model = new AircraftsView(aircrafts, filter.Pagination);

            return model;
        }

    }
}