using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodApp.Model;

namespace FoodApp.Repository.Interfaces
{
    public interface IUserRepository: IRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(Guid UserId);
        Task<User> GetUserByIdWithRecipes(Guid UserId);
        Task InsertUser(User User);
        Task DeleteUser(Guid UserId);
        Task UpdateUser(User User);
    }
}
