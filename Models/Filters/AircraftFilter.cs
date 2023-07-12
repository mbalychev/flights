namespace flights.models
{

    /// <summary>
    /// фильтр для списка возд судов
    /// </summary>
    public class AircraftFilter
    {

        /// <summary>
        /// пагинация
        /// </summary>
        /// <returns></returns>
        public Pagination Pagination { get; set; } = new Pagination();

        /// <summary>
        /// мин дальность полета
        /// </summary>
        /// <value></value>
        public int RangeMin { get; set; } = 0;

        /// <summary>
        /// макс дальность полета
        /// </summary>
        /// <value></value>
        public int RangeMax { get; set; } = 10000;

    }
}