using EpedimiologicReport.Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;

namespace EpedimiologicReport.Dal
{
    public class PatientDal : IPatientDal
    {
        private CoronaContext _context;

        public PatientDal(CoronaContext corona)
        {
            _context = corona;
        }
        public async Task<bool> AddPatient(Patient patient)
        {
            Patient p = patient;
           _context.Patients.Add(p);    
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<List<Location>> GetLocationsByPatientId(string patientId)
        {
            List<Location> locations= await _context.Locations.Where(l => l.PatientId.Equals(patientId)).ToListAsync();

            return  locations;
        }
        public async Task<Patient> GetPatient(string patientId)
        {
            return await _context.Patients.FirstOrDefaultAsync(p => p.PatientId.Equals(patientId));
        }
    }
}
