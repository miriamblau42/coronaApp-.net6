using EpedimiologicReport.Dal.Models;
using EpedimiologicReport.Dal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EpedimiologicReport.Services;

public  class PatientRepository : IPatientRepository
{
    IPatientDal _patientDal;
    public PatientRepository(IPatientDal patientDal)
    {
        _patientDal = patientDal;
    }
    public async Task<Patient> Get(string id)
    {
        return await _patientDal.GetPatient(id);   
    }

    public  async Task<bool> Save(Patient patient)
    {
        bool flag= await  _patientDal.AddPatient(patient);
        return flag;
    }
    public async Task<List<Location>> GetLocationsByPatientId(string id)
    {
        return await _patientDal.GetLocationsByPatientId(id);
    }
}
