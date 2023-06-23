
using flights.models;

namespace flights.Filter
{


    /// <summary>
    /// 
    /// </summary>
    public static class FlightFilterExt
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="q"></param>
        /// <param name="arrival"></param>
        /// <returns></returns>
        public static IQueryable<Flight> Arrival(this IQueryable<Flight> q, string? arrival)
                    => string.IsNullOrWhiteSpace(arrival)
                        ? q
                        : q.Where(x => x.ArrivalAirport == arrival);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="q"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static IQueryable<Flight> Status(this IQueryable<Flight> q, string? status)
                    => string.IsNullOrWhiteSpace(status)
                        ? q
                        : q.Where(x => x.Status == status);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="q"></param>
        /// <param name="scheduledArriveMin"></param>
        /// <returns></returns>
        public static IQueryable<Flight> ArriveMin(this IQueryable<Flight> q, DateTime? scheduledArriveMin)
                    => (scheduledArriveMin is null)
                        ? q
                        : q.Where(x => x.ScheduledArrival >= scheduledArriveMin);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="q"></param>
        /// <param name="scheduledArriveMax"></param>
        /// <returns></returns>
        public static IQueryable<Flight> ArriveMax(this IQueryable<Flight> q, DateTime? scheduledArriveMax)
                    => (scheduledArriveMax is null)
                        ? q
                        : q.Where(x => x.ScheduledArrival >= scheduledArriveMax);


    }
}

