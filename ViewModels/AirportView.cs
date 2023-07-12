using flights.models;

/// <summary>
/// модель отображения данных об аэропорте
/// </summary>
public class AirportView : Airport
{

    /// <summary>
    /// 
    /// </summary>
    /// <param name="airport"></param>
    /// <param name="pagination"></param>
    public AirportView(ICollection<Airport> airport, Pagination? pagination)
    {
        this.Airport = airport;
        this.Pagination = (pagination is null) ? new Pagination() : pagination;
    }

    /// <summary>
    /// аэропорт
    /// </summary>
    /// <returns></returns>
    public ICollection<Airport> Airport { get; set; } = new List<Airport>();

    /// <summary>
    ///  пагинация
    /// </summary>
    /// <returns></returns>
    public Pagination Pagination { get; set; } = new Pagination();
}