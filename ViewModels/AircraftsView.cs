using System.Text.Json.Serialization;
using flights.models;

namespace flights.ViewModels
{

    /// <summary>
    /// модель для вывода данных возд судов, с пагинацией
    /// </summary>
    public class AircraftsView : Pagination
    {
        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="aircrafts"></param>
        /// <param name="pagination"></param>
        public AircraftsView(ICollection<Aircraft> aircrafts, Pagination pagination)
            : base(pagination.Page, pagination.OnPage, pagination.Total)
        {
            this.Aircrafts = aircrafts;
        }

        /// <summary>
        /// список возд судов
        /// </summary>
        /// <returns></returns>
        [JsonPropertyName("aircrafts")]
        public ICollection<Aircraft> Aircrafts { get; set; } = new List<Aircraft>();
    }
}