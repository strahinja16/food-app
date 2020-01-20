using System;
using System.Linq;
using System.Threading.Tasks;
using FoodApp.Graphql.Input.Recipe;
using FoodApp.Graphql.Input.User;
using FoodApp.Graphql.Message;
using FoodApp.Model;
using FoodApp.Repository.Interfaces;
using FoodApp.Services.Interfaces;
using HotChocolate.Subscriptions;

namespace FoodApp.Services
{
    public class MutationService : IMutationService
    {
        private readonly IUserRepository userRepository;
        private readonly IRecipeRepository recipeRepository;
        private readonly ITagRepository tagRepository;

        public MutationService(
            IUserRepository userRepository,
            IRecipeRepository recipeRepository,
            ITagRepository tagRepository)
        {
            this.userRepository = userRepository;
            this.recipeRepository = recipeRepository;
            this.tagRepository = tagRepository;
        }

        public async Task<Recipe> InsertRecipe(InsertRecipeInput recipeInput, IEventSender eventSender)
        {
            var user = await userRepository.GetUserByIdWithRecipes(recipeInput.UserId);

            if (user == null)
            {
                return null;
            }

            var recipe = new Recipe()
            {
                UserId = user.Id,
                Title = recipeInput.Title,
                PrepTime = recipeInput.PrepTime,
                Image = recipeInput.Image,
                Kcal = recipeInput.Kcal,
                Protein = recipeInput.Protein,
                Fat = recipeInput.Fat,
                Carbs = recipeInput.Carbs
            };

            await recipeRepository.InsertRecipe(recipe);

            var savedRecipe = await recipeRepository.GetRecipeByTitle(recipe.Title);

            var foundTags = await tagRepository.GetTagsByNames(recipeInput.Tags.Select(t => t.Name).ToList());

            foreach(var inputTag in recipeInput.Tags)
            {
                if (foundTags.Any() && foundTags.Select(t => t.Name).Contains(inputTag.Name))
                {
                    var existingTag = foundTags.First(t => t.Name == inputTag.Name);

                    var recipeTag = new RecipeTag()
                    {
                        Recipe = savedRecipe,
                        RecipeId = savedRecipe.Id,
                        Tag = existingTag,
                        TagId = existingTag.Id,
                    };

                    recipe.RecipeTags.Add(recipeTag);
                    existingTag.RecipeTags.Add(recipeTag);
                }
                else
                {
                    var tag = new Tag() { Name = inputTag.Name };

                    await tagRepository.InsertTag(tag);

                    var savedTag = await tagRepository.GetTagByName(inputTag.Name);

                    var recipeTag = new RecipeTag()
                    {
                        Recipe = savedRecipe,
                        RecipeId = savedRecipe.Id,
                        Tag = savedTag,
                        TagId = savedTag.Id,
                    };

                    recipe.RecipeTags.Add(recipeTag);
                    savedTag.RecipeTags.Add(recipeTag);
                }
            }

            await recipeRepository.Save();

            var userRecipeInfo = new UserRecipeInfo()
            {
                UserId = user.Id,
                UserName = user.Name,
                RecipeId = savedRecipe.Id,
                RecipeCount = user.Recipes.Count
            };

            await eventSender.SendAsync(new OnInsertRecipeMessage(user.Id, userRecipeInfo));

            return savedRecipe;
        }

        public async Task<User> InsertUser(InsertUserInput userInput)
        {
            var user = new User()
            {
                Name = userInput.Name,
                Email = userInput.Email,
                Password = PasswordManager.HashPassword(userInput.Password)
            };

            await userRepository.InsertUser(user);

            return user;
        }

        public async Task<User> UpdateUser(UpdateUserInput updateUserInput)
        {
            var user = await userRepository.GetUserById(updateUserInput.Id);

            if (updateUserInput.Name != null) user.Name = updateUserInput.Name;
            if (updateUserInput.Email != null) user.Email = updateUserInput.Email;
            if (updateUserInput.Password != null)
                user.Password = PasswordManager.HashPassword(updateUserInput.Password);

            await userRepository.UpdateUser(user);
            return user;
        }
    }
}
