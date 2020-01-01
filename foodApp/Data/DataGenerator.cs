using System;
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
        public static void GenerateData(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "Users",
            columns: new[] { "Id", "Name", "Email", "Password" },
            values: GenerateUsers(10));
        }

        public static object[,] GenerateUsers(int userCount)
        {
            var userPropertiesCount = 4;
            object[,] users = new object[userCount, userPropertiesCount];

            for (int i = 0; i < userCount; i++)
            {
                var testUser = new Faker<User>()

                .RuleFor(u => u.Id, f => Guid.NewGuid())

                .RuleFor(u => u.Name, f => f.Name.FullName())

                .RuleFor(u => u.Email, f => f.Internet.Email())

                .RuleFor(u => u.Password, f => HashPassword("test"));

                var user = testUser.Generate();

                var userGeneric = new List<object>();

                foreach (var p in user.GetType().GetProperties())
                {
                    Console.Write($" {JsonConvert.SerializeObject(p.GetValue(user, null), Formatting.Indented)} ");
                    userGeneric.Add(p.GetValue(user, null));
                }

                for (int j = 0; j < userGeneric.Count; j++ )
                {
                    users[i, j] = userGeneric.ElementAt(j);
                }
            }

            return users;
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
