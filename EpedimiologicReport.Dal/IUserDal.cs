using EpedimiologicReport.Dal.Models;

namespace EpedimiologicReport.Dal
{
    public interface IUserDal
    {
        public Task<User> Login(User NewUser);
        public Task<User> getUser(string name, string password);
        public Task<bool> AddUser(User User); 
    }
}