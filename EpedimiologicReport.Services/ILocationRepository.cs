
using EpedimiologicReport.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EpedimiologicReport.Services;

public interface ILocationRepository
{
    Task<List<Location>> Get(string city);
    public void AddLocation(Location location);
    public Task<List<Location>> GetAndFilter(LocationSearch locationSearch);
}
