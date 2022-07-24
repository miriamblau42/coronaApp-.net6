using EpedimiologicReport.Dal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EpedimiologicReport.Dal
{
    public interface IPatientDal
    {
        void AddPatient(Patient patient);
        public  Task<List<Location>> GetLocationsByPatientId(string patientId);
        public Task<Patient> GetPatient(string patientId);

    }
}