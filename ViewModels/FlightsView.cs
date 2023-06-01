using flights.models;

namespace flights.ViewModels
{

    /// <summary>
    /// модель для вывода данных полета, с пагинацией
    /// </summary>
    public class FlightsView
    {
        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="flights"></param>
        /// <param name="pagination"></param>
        public FlightsView(ICollection<Flight> flights, Pagination pagination)
        {
            this.Flights = flights;
            this.Pagination = pagination;
        }

        /// <summary>
        /// список полетов
        /// </summary>
        /// <typeparam name="Flight"></typeparam>
        /// <returns></returns>
        ICollection<Flight> Flights { get; set; } = new List<Flight>();
        /// <summary>
        /// пагинация списка
        /// </summary>
        /// <returns></returns>
        Pagination Pagination { get; set; } = new Pagination();
    }
}