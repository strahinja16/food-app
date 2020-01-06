using System;
namespace FoodApp.Graphql.Input.User
{
    public class InsertUserInput
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
