using System;
using FoodApp.Model;
using HotChocolate.Language;
using HotChocolate.Subscriptions;

namespace FoodApp.Graphql.Message
{
    public class OnInsertRecipeMessage
    : EventMessage
    {
        public OnInsertRecipeMessage(Guid userId, UserRecipeInfo userRecipeInfo)
            : base(CreateEventDescription(userId), userRecipeInfo)
        {
        }

        private static EventDescription CreateEventDescription(Guid userId)
        {
            return new EventDescription("onInsertRecipe",
                new ArgumentNode("userId", userId.ToString()));
        }
    }
}
