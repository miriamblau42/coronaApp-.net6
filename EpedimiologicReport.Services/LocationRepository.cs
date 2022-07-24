using EpedimiologicReport.Dal;
using EpedimiologicReport.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EpedimiologicReport.Services;

public class LocationRepository : ILocationRepository
{
    private readonly LocationDal _locationDal;
    public LocationRepository()
    {
        _locationDal = new LocationDal();   
    }
    public Task<List<Location>> Get(string city="")
    {
        return _locationDal.GetLocations(city);
    }
    public void AddLocation(Location location)
    {
        _locationDal.AddLocation(location);
    }

    //needs to do a diffrent filtering...
   public Task<List<Location>> GetAndFilter(LocationSearch locationSearch)
    {
        return _locationDal.GetLocationsAndFilter(locationSearch);
    }


}
