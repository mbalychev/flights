using System.Text.Json.Serialization;
using flights.models;

namespace flights.ViewModels
{

    /// <summary>
    /// модель для вывода данных полета, с пагинацией
    /// </summary>
    public class FlightsView : Pagination
    {
        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="flights"></param>
        /// <param name="filter"></param>
        public FlightsView(ICollection<Flight> flights, FlightFilter filter) : base(filter.Pagination.Page, filter.Pagination.OnPage, filter.Pagination.Total)
        {
            this.Flights = flights;
        }

        /// <summary>
        /// список полетов
        /// </summary>
        /// <typeparam name="Flight"></typeparam>
        /// <returns></returns>
        [JsonPropertyName("flights")]
        public ICollection<Flight> Flights { get; set; } = new List<Flight>();
    }
}