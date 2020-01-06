using System;
using FoodApp.Graphql.Input.Recipe;
using FoodApp.Graphql.Input.User;
using FoodApp.Graphql.Type;
using HotChocolate.Types;

namespace FoodApp.Graphql.Mutation
{
    public class MutationType : ObjectType<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(m => m.InsertUser(default, default))
                .Type<NonNullType<UserType>>()
                .Argument("userInput", a => a.Type<NonNullType<InsertUserInputType>>());

            descriptor.Field(m => m.InsertRecipe(default, default))
                .Type<NonNullType<RecipeType>>()
                .Argument("recipeInput", a => a.Type<NonNullType<InsertRecipeInputType>>());

            descriptor.Field(m => m.DeleteUser(default, default))
                .Type<BooleanType>()
                .Argument("deleteUserInput", a => a.Type<NonNullType<DeleteUserInputType>>());

            descriptor.Field(m => m.UpdateUser(default, default))
                .Type<UserType>()
                .Argument("updateUserInput", a => a.Type<NonNullType<UpdateUserInputType>>());
        }
    }
}
