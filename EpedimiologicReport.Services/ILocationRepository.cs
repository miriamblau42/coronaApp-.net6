
using EpedimiologicReport.Dal.Models;
using EpedimiologicReport.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EpedimiologicReport.Services;

public interface ILocationRepository
{
    Task<List<Location>> Get(string city);
    public Task<bool> AddLocation(LocationDto location);
    public Task<List<Location>> GetAndFilter(LocationSearch locationSearch);
}
