using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodApp.DbContexts;
using FoodApp.Model;
using FoodApp.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoodApp.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteUser(Guid UserId)
        {
            var user = await _dbContext.Users.FindAsync(UserId);
            _dbContext.Users.Remove(user);
            await Save();
        }

        public async Task<User> GetUserById(Guid UserId)
        {
            return await _dbContext.Users.FindAsync(UserId);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task InsertUser(User User)
        {
            await _dbContext.Users.AddAsync(User);
            await Save();
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUser(User User)
        {
            _dbContext.Entry(User).State = EntityState.Modified;
            await Save();
        }
    }
}
