using System;
using System.Collections.Generic;
using FoodApp.Graphql.Resolvers;
using FoodApp.Model;
using FoodApp.Repository;
using FoodApp.Repository.Interfaces;
using GreenDonut;
using HotChocolate.Resolvers;
using HotChocolate.Types;

namespace FoodApp.Graphql.Type
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(u => u.Id)
                .Type<NonNullType<IdType>>();

            // Ignored
            descriptor.Field(u => u.Password)
                .Ignore();

            // Properties
            descriptor.Field(u => u.Name)
                .Type<NonNullType<StringType>>();

            descriptor.Field(u => u.Email)
                .Type<NonNullType<StringType>>();

            // Resolvers
            descriptor
                .Field("recipes")
                .Type<NonNullType<ListType<RecipeType>>>()
                .Resolver(ctx =>
                {
                    var repository = ctx.Service<IRecipeRepository>();

                    IDataLoader<Guid, Recipe[]> recipeDataLoader =
                        ctx.GroupDataLoader<Guid, Recipe>(
                            "recipesByUserId",
                            repository.GetRecipesByUserId);

                    return recipeDataLoader.LoadAsync(ctx.Parent<User>().Id);
                });
        }
    }
}
