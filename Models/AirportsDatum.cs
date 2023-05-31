﻿using System;
using System.Collections.Generic;
using NpgsqlTypes;

namespace flights.models;

/// <summary>
/// Airports (internal data)
/// </summary>
public partial class AirportsDatum
{
    /// <summary>
    /// Airport code
    /// </summary>
    public string AirportCode { get; set; } = null!;

    /// <summary>
    /// Airport name
    /// </summary>
    public string AirportName { get; set; } = null!;

    /// <summary>
    /// City
    /// </summary>
    public string City { get; set; } = null!;

    /// <summary>
    /// Airport coordinates (longitude and latitude)
    /// </summary>
    public NpgsqlPoint Coordinates { get; set; }

    /// <summary>
    /// Airport time zone
    /// </summary>
    public string Timezone { get; set; } = null!;

    public virtual ICollection<Flight> FlightArrivalAirportNavigations { get; set; } = new List<Flight>();

    public virtual ICollection<Flight> FlightDepartureAirportNavigations { get; set; } = new List<Flight>();
}
