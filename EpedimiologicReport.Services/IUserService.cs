using EpedimiologicReport.Dal.Models;
using EpedimiologicReport.Services.Dtos;

namespace EpedimiologicReport.Services
{
    public interface IUserService
    {
        Task<string> LoginWithDto(UserLoginDto user);
        Task<string> Login(User newUser);
        Task<string> SignUp(UserLoginDto newUser);
/*        string getNameFromToken(string token);*/
    }
}