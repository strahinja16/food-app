using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodApp.Model;
using FoodApp.Repository.Interfaces;
using FoodApp.Service.Interfaces;

namespace FoodApp.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task DeleteUser(Guid UserId)
        {
            await userRepository.DeleteUser(UserId);
        }

        public async Task<User> GetUserById(Guid UserId)
        {
            return await userRepository.GetUserById(UserId);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await userRepository.GetUsers();
        }

        public async Task InsertUser(User User)
        {
            await userRepository.InsertUser(User);
        }

        public async Task UpdateUser(User User)
        {
            await userRepository.UpdateUser(User);
        }
    }
}
