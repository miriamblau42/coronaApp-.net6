using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpedimiologicReport.Dal.Models;
using EpedimiologicReport.Services;
using EpedimiologicReport.Services.Dtos;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EpedimiologicReport.api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LocationController : ControllerBase
{
    ILocationRepository _locationRepository;
    public LocationController(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
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
    public async Task<ActionResult<bool>> PostLocationAsync([FromBody] LocationDto location)
    {
        if (location!=null && location.FromDate.Value.CompareTo(location.ToDate)<=0)
        {
            
          bool flag = await _locationRepository.AddLocation(location);
            if (flag)
            {
                return Ok();
            }
            return NotFound();
           
        }
        else
        {
            return BadRequest();
        }
       
    }
    
    [HttpGet]
    [Route("GetAll")]
    public async Task<ActionResult<List<Location>>> GetAll()
    {
        var locations =  await _locationRepository.Get("");
        if (locations == null || locations.Count < 1)
        {
            return NoContent();
        }
        return Ok(locations);
    }
    //filter with city
    [HttpPost]
    [Route("GetFilter")]
    public async Task<ActionResult<List<Location>>> GetCityFilter([FromBody] Dal.Models.LocationSearch locationSearch)
    {
        if (locationSearch == null)
        {
            throw new ArgumentNullException(nameof(locationSearch));
        }
        var locations =await _locationRepository.GetAndFilter(locationSearch);
        if (locations==null || locations.Count<1)
        {
            return NoContent();
        }
        return Ok(locations);   
    }





}
