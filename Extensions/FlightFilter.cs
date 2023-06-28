
using System.Reflection.Metadata.Ecma335;
using System.Linq;
using flights.models;
using flights.ViewModels;

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

        /// <summary>
        /// филтрация по номеру рейса
        /// </summary>
        /// <param name="q"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static IQueryable<Flight> Number(this IQueryable<Flight> q, string? number)
            => (number is null)
                ? q
                : q.Where(x => x.FlightNo == number);

        /// <summary>
        /// сортировка по полю
        /// </summary>
        /// <param name="q"></param>
        /// <param name="sort">тип сортировки SortType</param>
        /// <returns></returns>
        public static IQueryable<Flight> Sort(this IQueryable<Flight> q, SortType? sort)
        {
            if (sort is null)
                return q;


            switch (sort)
            {
                case SortType.status:
                    return q.OrderBy(x => x.Status);

                case SortType.arrivalTime:
                    return q.OrderBy(x => x.ScheduledArrival);

                case SortType.departureTime:
                    return q.OrderBy(x => x.ActualDeparture);

                default:
                    return q;
            }
        }

    }

}

