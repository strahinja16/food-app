using System;
using System.Collections.Generic;

namespace FoodApp.Model
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public List<Recipe> Recipes { get; set; }
    }
}
