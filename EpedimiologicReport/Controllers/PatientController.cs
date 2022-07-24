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

    PatientRepository _patientRepository;
    public PatientController()
    {
        _patientRepository = new PatientRepository();
    }
    // GET api/<PatientController>/5
    [HttpGet("{id}")]
    public async Task<object> Get(string id)
    {
     return await _patientRepository.Get(id);
    }

    // POST api/<PatientController>
    [HttpPost]
    public  void Post([FromBody] Patient patient)
    {
        _patientRepository.Save(patient);
    }
    [HttpGet]
    public async Task<List<Location>> GetLocations(string id)
    {
        return await _patientRepository.GetLocationsByPatientId(id);
    }


 
}
