using System;

namespace EpedimiologicReport.Dal.Models;

public class LocationSearch
{
    public Nullable<DateTime> StartDate { get; set; }
    public Nullable<DateTime> EndDate { get; set; }
    public Nullable<int> Age { get; set; }
}