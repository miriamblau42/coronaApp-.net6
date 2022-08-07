using EpedimiologicReport.Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpedimiologicReport.Dal
{
    public class UserDal : IUserDal
    {
        private readonly CoronaContext _coronaContext;

        public UserDal(CoronaContext corona)
        {
            _coronaContext = corona;
        }
        public async Task<User> Login(User NewUser)
        {
            return await getUser(NewUser.Name,NewUser.Password);       
        }

        public async Task<User> getUser(string name, string password)
        {
            User user= await _coronaContext.Users.FirstOrDefaultAsync
                (u => u.Name.Equals(name) && u.Password.Equals(password)); 
            return user;
        }

        public  async Task<bool> AddUser(User user)
        {
            await _coronaContext.Users.AddAsync(user);
            try
            {
                await _coronaContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
         
        }

        
    }
}
