using System.Collections.Generic;

namespace EpedimiologicReport.Dal.Models;

public class Patient
{
    public string? PatientId { get; set; }
    public string? PatientName { get; set; }
    public int? Age { get; set; }

}