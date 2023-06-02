namespace flights.ViewModels
{
    /// <summary>
    /// фильтр для поиска моделей упралвения полетами
    /// </summary>
    public class FlightFilter
    {
        /// <summary>
        /// нинициализация по умолчанию
        /// </summary>
        public FlightFilter()
        {
        }

        /// <summary>
        /// инициялизация параметрами
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="arrival"></param>
        /// <param name="status"></param>
        /// <param name="scheduledArriveMin"></param>
        /// <param name="scheduledArriveMax"></param>
        public FlightFilter(
            Pagination pagination,
            string? arrival,
            string? status,
            DateTime? scheduledArriveMin,
            DateTime? scheduledArriveMax)
        {
            Pagination = pagination;
            Arrival = arrival;
            Status = status;
            ScheduledArriveMin = scheduledArriveMin;
            ScheduledArriveMax = scheduledArriveMax;
        }


        /// <summary>
        /// пагинация
        /// </summary>
        /// <returns></returns>
        public Pagination Pagination { get; set; } = new Pagination();
        /// <summary>
        /// аэропорт назаначения
        /// </summary>
        /// <value></value>
        public string? Arrival { get; set; } = string.Empty;
        /// <summary>
        /// статус рейса
        /// </summary>
        /// <value></value>
        public string? Status { get; set; } = string.Empty;
        /// <summary>
        /// мин время прибытия
        /// </summary>
        /// <value></value>
        public DateTime? ScheduledArriveMin { get; set; } = DateTime.UtcNow;
        /// <summary>
        /// макс время прибытия
        /// </summary>
        /// <value></value>
        public DateTime? ScheduledArriveMax { get; set; } = DateTime.UtcNow;
    }
}