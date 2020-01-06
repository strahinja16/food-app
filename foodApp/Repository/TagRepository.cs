using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodApp.DbContexts;
using FoodApp.Model;
using FoodApp.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoodApp.Repository
{
    public class TagRepository : ITagRepository
    {
        private readonly AppDbContext _dbContext;

        public TagRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteTag(Guid TagId)
        {
            var Tag = await _dbContext.Tags.FindAsync(TagId);
            _dbContext.Tags.Remove(Tag);
            await Save();
        }

        public async Task<Tag> GetTagById(Guid TagId)
        {
            return await _dbContext.Tags.FindAsync(TagId);
        }

        public async Task<Tag> GetTagByName(string Name)
        {
            return await _dbContext.Tags
                .Include(t => t.RecipeTags)
                .Where(t => t.Name == Name)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Tag>> GetTags()
        {
            return await _dbContext.Tags.ToListAsync();
        }

        public async Task<IEnumerable<Tag>> GetTagsByNames(List<string> tagNames)
        {
            return await _dbContext.Tags
                .Include(t => t.RecipeTags)
                .Where(t => tagNames.Contains(t.Name))
                .ToListAsync();
        }

        public async Task<IEnumerable<Tag>> GetTagsByRecipeId(Guid RecipeId)
        {
            return await _dbContext.Tags
                .Include(tag => tag.RecipeTags)
                .SelectMany(tag => tag.RecipeTags, (tag, recipeTag) => new { tag, recipeTag.RecipeId })
                    .Where(t => t.RecipeId == RecipeId)
                    .Select(t => t.tag)
                    .Distinct()
                    .ToListAsync();
        }

        public async Task InsertTag(Tag Tag)
        {
            await _dbContext.Tags.AddAsync(Tag);
            await Save();
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateTag(Tag Tag)
        {
            _dbContext.Entry(Tag).State = EntityState.Modified;
            await Save();
        }
    }
}
