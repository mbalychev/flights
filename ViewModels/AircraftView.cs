using flights.models;

namespace flights.ViewModels
{
    /// <summary>
    /// модель представления воздушными судами
    /// </summary>
    public class AircraftView
    {
        public AircraftView(ICollection<Aircraft> aircrafts, Pagination paginations)
        {
            this.Aircrafts = aircrafts;
            this.Pagination = paginations;
        }

        /// <summary>
        /// список моделей возд судов
        /// </summary>
        /// <typeparam name="Aircraft"></typeparam>
        /// <returns></returns>
        public ICollection<Aircraft> Aircrafts { get; set; } = new List<Aircraft>();
        /// <summary>
        /// пагинация
        /// </summary>
        /// <returns></returns>
        public Pagination Pagination { get; set; } = new Pagination();
    }
}