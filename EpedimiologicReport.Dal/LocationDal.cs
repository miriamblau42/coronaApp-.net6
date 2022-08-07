using EpedimiologicReport.Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpedimiologicReport.Dal;

public class LocationDal: ILocationDal
{
    private CoronaContext _context;
    public LocationDal(CoronaContext coronaContext)
    {
        _context = coronaContext;
    }

    public async Task<List<Location>> GetLocations(string city = "")
    {
        return await _context.Locations.Where(l => l.City.Contains(city)).ToListAsync();
    }

    public async Task<bool> AddLocation(Location location)
    {
        await _context.Locations.AddAsync(location);
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
    public async Task<List<Location>> GetLocationsAndFilter(LocationSearch locationSearch)
    {

        List<Location> filteredLocations = await _context.Locations.Include(l=>l.Patient).ToListAsync();

        if (locationSearch == null || (locationSearch.Age == null && locationSearch.StartDate == null && locationSearch.EndDate == null))
            return filteredLocations; 

        if (locationSearch.Age.HasValue)
        {
            filteredLocations = filteredLocations
                           .Where(location => location.Patient.Age == locationSearch.Age.Value).ToList();
        }

        if (locationSearch.StartDate.HasValue)
            filteredLocations = filteredLocations.Where(l => DateTime.Compare(locationSearch.StartDate.Value, l.FromDate.Value) < 0).ToList();
        if (locationSearch.EndDate.HasValue)
        {
            filteredLocations = filteredLocations.Where(lo=>DateTime.Compare(locationSearch.EndDate.Value, lo.ToDate) > 0).ToList();

        }
        return filteredLocations;
    }
/*    public async Task<List<Location>> GetLocationByAge(LocationSearch location)
    {
        List<Location> result = new List<Location>();
        List<Location> locations = await _context.Locations.ToListAsync();
        List<Patient> allPatients = await _context.Patients.ToListAsync();
        List<string> patientsId = new List<string>();
        patientsId.AddRange(allPatients.FindAll(x => x.Age == location.Age).Select(x => x.PatientId));
        result = locations.FindAll(x => patientsId.IndexOf(x.PatientId) != -1);
        return result;
    }*/





}
