using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpedimiologicReport.Dal.Models;
using EpedimiologicReport.Services;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EpedimiologicReport.api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LocationController : ControllerBase
{
    ILocationRepository _locationRepository;
    public LocationController()
    {
        _locationRepository = new LocationRepository();
    }
    // GET: api/<LocationController>
    //filter
 
    
    // GET api/<LocationController>/"yerushalaim
    [HttpGet("GetByCity/{city}")]
    public async Task<ActionResult<List<Location>>> GetByCity(string city)
    {
        List<Location> locations =await _locationRepository.Get(city);
        if (locations != null)
        {
            return Ok(locations);
        }
        return NotFound();
    }
    [HttpPost]
    public void PostLocation([FromBody] Location location)
    {
        _locationRepository.AddLocation(location);
    }
    
    [HttpGet]
    [Route("GetAll")]
    public async Task<List<Location>> GetAll()
    {
        return await _locationRepository.Get("");
    }
    //filter with city
    [HttpGet]
    [Route("GetFilter")]
    public Task<List<Location>> GetCityFilter([FromBody] Dal.Models.LocationSearch locationSearch)
    {
        return _locationRepository.GetAndFilter(locationSearch);
    }





}
