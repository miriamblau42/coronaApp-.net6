using AutoMapper;
using EpedimiologicReport.Dal;
using EpedimiologicReport.Dal.Models;
using EpedimiologicReport.Services.Dtos;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EpedimiologicReport.Services
{
    public class UserService : IUserService
    {
        private IUserDal _userDal;
        private IMapper _mapper;

        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapper>();
            });
            _mapper = config.CreateMapper();
            
        }
        public async Task<string> LoginWithDto(UserLoginDto user)
        {
            var newUser = _mapper.Map<User>(user);
            return await Login(newUser);
        }
        public async Task<string> Login(User user)
        {
         
            User Myuser = await _userDal.Login(user);
            JwtSecurityToken token;

            if (user != null)
            {
                token = CreateToken(Myuser);

            }
            else
            {
                return null;
            }

            return new JwtSecurityTokenHandler().WriteToken(token).ToString();
        }

        private static JwtSecurityToken CreateToken(User user)
        {
            JwtSecurityToken token;
            var claims = new[] {
                          new Claim("UserId", user.ID.Value.ToString()),
                          new ("UserName", user.Name),
                          new Claim("type","user")
                    };

            var issuer = "https://example.com";

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("thisIsASecretKey"));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            token = new JwtSecurityToken(
                issuer,
                issuer,
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn);
            return token;
        }

        public async Task<string> SignUp(UserLoginDto newUser)
        {
            User user = await _userDal.getUser(newUser.Name, newUser.Password);
            bool flag;
            string token = "";
            if (user == null)
            {
               User  myUser = _mapper.Map<User>(newUser);
              flag = await _userDal.AddUser(myUser);
               token = await Login(myUser);
            }
            return token;
        }
      /*   public string getNameFromToken(IEnumerable<Claim> claims)
        {
            string userName = claims.FirstOrDefault(
                            x => x.Type.ToString().Equals("UserName", StringComparison.InvariantCultureIgnoreCase)).Value;
            return userName;
        }*/
    }
}

