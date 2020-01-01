using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Bogus;
using FoodApp.Model;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json;

namespace FoodApp.Data
{
    public static class DataGenerator
    {
        public static List<User> Users { get; private set; } = new List<User>();
        public static string[] UserExcludedProperties = { "Recipes" };

        public static List<Recipe> Recipes { get; private set; } = new List<Recipe>();
        public static string[] RecipeExcludedProperties = { "User" };

        public static Random rnd = new Random();

        public static void GenerateData(MigrationBuilder migrationBuilder)
        {
            const int usersCount = 10;
            const int recipesCount = 30;

            migrationBuilder.InsertData(
            table: "Users",
            columns: new[] { "Id", "Name", "Email", "Password" },
            values: GenerateUsers(usersCount));

            migrationBuilder.InsertData(
            table: "Recipes",
            columns: new[] { "Id", "UserId", "Title", "Image", "PrepTime", "Kcal", "Carbs", "Fat", "Protein" },
            values: GenerateRecipes(recipesCount));
        }

        public static object[,] GenerateUsers(int userCount)
        {
            const int userPropertiesCount = 4;
            object[,] users = new object[userCount, userPropertiesCount];

            for (int i = 0; i < userCount; i++)
            {
                var testUser = new Faker<User>()

                .RuleFor(u => u.Id, f => Guid.NewGuid())

                .RuleFor(u => u.Name, f => f.Name.FullName())

                .RuleFor(u => u.Email, f => f.Internet.Email())

                .RuleFor(u => u.Password, f => HashPassword("test"));

                var user = testUser.Generate();

                Users.Add(user);

                var userGeneric = new List<object>();

                foreach (var p in user.GetType().GetProperties().Where(p => p != typeof(IEnumerable)))
                {
                    Console.WriteLine(JsonConvert.SerializeObject(p.Name, Formatting.Indented));

                    if (!UserExcludedProperties.Contains(p.Name))
                    {
                        userGeneric.Add(p.GetValue(user, null));
                    }
                }

                for (int j = 0; j < userGeneric.Count; j++ )
                {
                    users[i, j] = userGeneric.ElementAt(j);
                }
            }

            return users;
        }

        public static object[,] GenerateRecipes(int recipesCount)
        {
            const int recipePropertiesCount = 9;
            object[,] recipes = new object[recipesCount, recipePropertiesCount];

            for (int i = 0; i < recipesCount; i++)
            {
                var randomUser = Users[rnd.Next(0, Users.Count)];

                var testRecipe = new Faker<Recipe>()

                .RuleFor(r => r.Id, f => Guid.NewGuid())

                .RuleFor(r => r.UserId, f => randomUser.Id)

                .RuleFor(r => r.Title, f => f.Lorem.Word())

                .RuleFor(r => r.Image, f => f.Image.LoremPixelUrl())

                .RuleFor(r => r.PrepTime, f => f.Random.Number(5, 15))

                .RuleFor(r => r.Kcal, f => f.Random.Number(5, 15))

                .RuleFor(r => r.Carbs, f => f.Random.Number(50, 250))

                .RuleFor(r => r.Fat, f => f.Random.Number(5, 50))

                .RuleFor(r => r.Protein, f => f.Random.Number(10, 50));

                var recipe = testRecipe.Generate();

                var recipeGeneric = new List<object>();

                foreach (var p in recipe.GetType().GetProperties())
                {
                    if (!RecipeExcludedProperties.Contains(p.Name))
                    {
                        recipeGeneric.Add(p.GetValue(recipe, null));
                    }
                }

                for (int j = 0; j < recipeGeneric.Count; j++)
                {
                    recipes[i, j] = recipeGeneric.ElementAt(j);
                }
                
            }

            return recipes;
        }

        private static string HashPassword(string password)
        {
            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
        }
    }
}
