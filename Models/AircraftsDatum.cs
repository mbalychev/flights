using System;
using System.Collections.Generic;

namespace flights.models;

/// <summary>
/// Aircrafts (internal data)
/// </summary>
public partial class AircraftsDatum
{
    /// <summary>
    /// Aircraft code, IATA
    /// </summary>
    public string AircraftCode { get; set; } = null!;

    /// <summary>
    /// Aircraft model
    /// </summary>
    public string Model { get; set; } = null!;

    /// <summary>
    /// Maximal flying distance, km
    /// </summary>
    public int Range { get; set; }

    /// <summary>
    /// полеты
    /// </summary>
    /// <returns></returns>
    public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();

    /// <summary>
    /// места
    /// </summary>
    /// <returns></returns>
    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();
}
