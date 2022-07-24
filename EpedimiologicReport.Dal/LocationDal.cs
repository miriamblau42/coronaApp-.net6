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
    public LocationDal()
    {
        _context = new CoronaContext();
    }
    public async Task<List<Location>> GetLocations(string city = "")
    {
        return await _context.Locations.Where(l => l.City.Contains(city)).ToListAsync();
    }
    public async void AddLocation(Location location)
    {
        await _context.Locations.AddAsync(location);
        await _context.SaveChangesAsync();
        return;
    }
    public async Task<List<Location>> GetLocationsAndFilter(LocationSearch locationSearch)
    {

        List<Location> filteredLocations = await _context.Locations.Include(l=>l.Patient).ToListAsync();
        if (locationSearch == null || (locationSearch.Age == null && locationSearch.StartDate == null && locationSearch.EndDate == null))
            return filteredLocations; 
        if (locationSearch.Age!=null)
        {
            filteredLocations = filteredLocations
                           .Where(location => location.Patient.Age == locationSearch.Age).ToList();
        }
        if (locationSearch.StartDate != null)
            filteredLocations = filteredLocations.Where(l => DateTime.Compare((DateTime)locationSearch.StartDate, l.FromDate) < 0).ToList();
        if (locationSearch.EndDate!=null)
        {
            filteredLocations = filteredLocations.Where(lo=>DateTime.Compare((DateTime)locationSearch.EndDate, lo.ToDate) > 0).ToList();

        }
        return filteredLocations;
    }




}
