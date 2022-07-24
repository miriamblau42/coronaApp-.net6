using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EpedimiologicReport.Dal.Models;

public class Location
{
    public Location()
    {
        Patient = null;
    }
    public int LocationId { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public string City { get; set; }
    public string Adress { get; set; }

    [ForeignKey("PatientId")]
    public virtual Patient Patient { get; set; }
    public string PatientId { get; set; }
}