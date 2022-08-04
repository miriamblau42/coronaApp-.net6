
using EpedimiologicReport.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EpedimiologicReport.Services;

public interface IPatientRepository
{
    Task<Patient> Get(string id);

    Task<bool> Save(Patient patient);
    Task<List<Location>> GetLocationsByPatientId(string id);

}
