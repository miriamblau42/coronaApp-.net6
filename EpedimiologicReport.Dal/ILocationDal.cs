using EpedimiologicReport.Dal.Models;

namespace EpedimiologicReport.Dal
{
    public interface ILocationDal
    {
        public Task<List<Location>> GetLocationsAndFilter(LocationSearch locationSearch);
        public Task<bool> AddLocation(Location location);
        public Task<List<Location>> GetLocations(string city = "");

    }
}