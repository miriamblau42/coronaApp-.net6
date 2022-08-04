using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpedimiologicReport.Services.Dtos
{
    public record  LocationDto(DateTime? FromDate, DateTime ToDate, string Adress, string City, string PatientId);

}
