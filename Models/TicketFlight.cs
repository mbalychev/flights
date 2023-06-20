using System;
using System.Collections.Generic;

namespace flights.models;

/// <summary>
/// Flight segment
/// </summary>
public partial class TicketFlight
{
    /// <summary>
    /// Ticket number
    /// </summary>
    public string TicketNo { get; set; } = null!;

    /// <summary>
    /// Flight ID
    /// </summary>
    public int FlightId { get; set; }

    /// <summary>
    /// Travel class
    /// </summary>
    public string FareConditions { get; set; } = null!;

    /// <summary>
    /// Travel cost
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// посадочный талон
    /// </summary>
    /// <value></value>
    public virtual BoardingPass? BoardingPass { get; set; }

    /// <summary>
    /// полет
    /// </summary>
    /// <value></value>
    public virtual Flight Flight { get; set; } = null!;

    /// <summary>
    /// билет навигация
    /// </summary>
    /// <value></value>
    public virtual Ticket TicketNoNavigation { get; set; } = null!;
}
