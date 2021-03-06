﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using FoodApp.DbContexts;
using FoodApp.Model;
using FoodApp.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace FoodApp.Repository
{
    public class RecipeRepository: IRecipeRepository
    {
        private readonly AppDbContext _dbContext;

        public RecipeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteRecipe(Guid RecipeId)
        {
            var Recipe = await _dbContext.Recipes.FindAsync(RecipeId);
            _dbContext.Recipes.Remove(Recipe);
            await Save();
        }

        public async Task<Recipe> GetRecipeById(Guid RecipeId)
        {
            return await _dbContext.Recipes.FindAsync(RecipeId);
        }

        public async Task<Recipe> GetRecipeByTitle(string Title)
        {
            return await _dbContext.Recipes
                .Include(t => t.RecipeTags)
                .Where(r => r.Title == Title)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Recipe>> GetRecipes()
        {
            return await _dbContext.Recipes.ToListAsync();
        }

        public async Task<ILookup<Guid, Recipe>> GetRecipesByUserId(IReadOnlyList<Guid> guids)
        {
            List<Recipe> recipes = await _dbContext.Recipes
                .Where(r => guids.Contains(r.UserId))
                .ToListAsync();

            return recipes.ToLookup(r => r.UserId);
        }

        public async Task InsertRecipe(Recipe Recipe)
        {
            await _dbContext.Recipes.AddAsync(Recipe);
            await Save();
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRecipe(Recipe Recipe)
        {
            _dbContext.Entry(Recipe).State = EntityState.Modified;
            await Save();
        }
    }
}
