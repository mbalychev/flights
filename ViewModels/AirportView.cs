using flights.models;

public class AirportView : Airport
{
    public AirportView(ICollection<Airport> airport, Pagination? pagination)
    {
        this.Airport = airport;
        this.Pagination = (pagination is null) ? new Pagination() : pagination;
    }

    public ICollection<Airport> Airport { get; set; } = new List<Airport>();
    public Pagination Pagination { get; set; } = new Pagination();
}