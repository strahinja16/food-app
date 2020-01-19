using System;
using FoodApp.Graphql.Type;
using HotChocolate.Types;

namespace FoodApp.Graphql.Subscription
{
    public class SubscriptionType
        : ObjectType<Subscription>
    {
        protected override void Configure(IObjectTypeDescriptor<Subscription> descriptor)
        {
            descriptor.Field(t => t.OnInsertRecipe(default, default))
                .Type<NonNullType<UserRecipeInfoType>>()
                .Argument("userId", arg => arg.Type<NonNullType<IdType>>());
        }   
    }
}
