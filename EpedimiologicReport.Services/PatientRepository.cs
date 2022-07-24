using EpedimiologicReport.Dal.Models;
using EpedimiologicReport.Dal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EpedimiologicReport.Services;

public  class PatientRepository : IPatientRepository
{
    PatientDal _patientDal;
    public PatientRepository()
    {
        _patientDal = new PatientDal();
    }
    public async Task<Patient> Get(string id)
    {
        return await _patientDal.GetPatient(id);   
    }

    public  void Save(Patient patient)
    {
          _patientDal.AddPatient(patient);
    }
    public async Task<List<Location>> GetLocationsByPatientId(string id)
    {
        return await _patientDal.GetLocationsByPatientId(id);
    }
}
