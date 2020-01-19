using System;
using FoodApp.Model;
using HotChocolate.Subscriptions;

namespace FoodApp.Graphql.Subscription
{
    public class Subscription
    {
        public UserRecipeInfo OnInsertRecipe(Guid userId, IEventMessage message)
        {
            return (UserRecipeInfo)message.Payload;
        }
    }
}
