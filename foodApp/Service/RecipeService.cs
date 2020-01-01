using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodApp.Model;
using FoodApp.Repository.Interfaces;
using FoodApp.Service.Interfaces;

namespace FoodApp.Service
{
    public class RecipeService: IRecipeService
    {
        private readonly IRecipeRepository RecipeRepository;

        public RecipeService(IRecipeRepository RecipeRepository)
        {
            this.RecipeRepository = RecipeRepository;
        }

        public async Task DeleteRecipe(Guid RecipeId)
        {
            await RecipeRepository.DeleteRecipe(RecipeId);
        }

        public async Task<Recipe> GetRecipeById(Guid RecipeId)
        {
            return await RecipeRepository.GetRecipeById(RecipeId);
        }

        public async Task<IEnumerable<Recipe>> GetRecipes()
        {
            return await RecipeRepository.GetRecipes();
        }

        public async Task InsertRecipe(Recipe Recipe)
        {
            await RecipeRepository.InsertRecipe(Recipe);
        }

        public async Task UpdateRecipe(Recipe Recipe)
        {
            await RecipeRepository.UpdateRecipe(Recipe);
        }
    }
}
