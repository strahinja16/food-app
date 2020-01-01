using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodApp.Model;

namespace FoodApp.Service.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(Guid UserId);
        Task InsertUser(User User);
        Task DeleteUser(Guid UserId);
        Task UpdateUser(User User);
    }
}
