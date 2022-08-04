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
public class PatientController : ControllerBase
{

    IPatientRepository _patientRepository;
    public PatientController(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }
    // GET api/<PatientController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Patient>> Get(string id)
    {
        
        Patient p= await _patientRepository.Get(id);
        if (p == null)
        {
            return NotFound();
        }
        return Ok(p);
    }

    // POST api/<PatientController>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Patient patient)
    {
        if (patient==null || patient.PatientId == null || patient.Age>120 || patient.Age<0 )
        {
            return BadRequest();
        }
        bool flag =await _patientRepository.Save(patient);
        if(flag)
        {
            return Ok();
        }
        return NotFound();
        
    }
    [HttpGet]
    public async Task<ActionResult<List<Location>>> GetLocations(string id)
    {
        List<Location> locations =await _patientRepository.GetLocationsByPatientId(id);
        if (locations==null || locations.Count<1)
        {
            return NoContent();
        }
        return Ok(locations);   
    }


 
}
