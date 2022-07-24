
using EpedimiologicReport.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EpedimiologicReport.Services;

public interface IPatientRepository
{
    Task<Patient> Get(string id);

    void Save(Patient patient);
}
