using AutoMapper;
using EpedimiologicReport.Dal;
using EpedimiologicReport.Dal.Models;
using EpedimiologicReport.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EpedimiologicReport.Services;

public class LocationRepository : ILocationRepository
{
    private readonly ILocationDal _locationDal;
    private IMapper _mapper;

    public LocationRepository(ILocationDal locationDal)
    {
        _locationDal = locationDal;
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<AutoMapper>();
        });
        _mapper = config.CreateMapper();
    }
    public Task<List<Location>> Get(string city="")
    {
        return _locationDal.GetLocations(city);
    }
    public async Task<bool> AddLocation(LocationDto location)
    {
        Location myLocation = _mapper.Map<Location>(location);
       return await _locationDal.AddLocation(myLocation);
    }

    //needs to do a diffrent filtering...
   public Task<List<Location>> GetAndFilter(LocationSearch locationSearch)
    {
        return _locationDal.GetLocationsAndFilter(locationSearch);
    }


}
