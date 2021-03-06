﻿using System;
using FoodApp.Model;
using FoodApp.Repository.Interfaces;
using GreenDonut;
using HotChocolate.Resolvers;
using HotChocolate.Types;

namespace FoodApp.Graphql.Type
{
    public class RecipeType : ObjectType<Recipe>
    {
        protected override void Configure(IObjectTypeDescriptor<Recipe> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(r => r.Id)
                .Type<NonNullType<IdType>>();

            // Ignored
            descriptor.Field(r => r.UserId)
               .Ignore();

            descriptor.Field(r => r.User)
                .Ignore();

            descriptor.Field(r => r.RecipeTags)
                .Ignore();

            // Properties
            descriptor.Field(r => r.Title)
                .Type<NonNullType<StringType>>();

            descriptor.Field(r => r.Image)
                .Type<NonNullType<StringType>>();

            descriptor.Field(r => r.PrepTime)
                .Type<NonNullType<IntType>>();

            descriptor.Field(r => r.Kcal)
                .Type<NonNullType<IntType>>();

            descriptor.Field(r => r.Protein)
                .Type<NonNullType<IntType>>();

            descriptor.Field(r => r.Carbs)
                .Type<NonNullType<IntType>>();

            descriptor.Field(r => r.Fat)
                .Type<NonNullType<IntType>>();

            // Resolvers
            descriptor
               .Field("tags")
               .Type<NonNullType<ListType<TagType>>>()
               .Resolver(ctx =>
               {
                   var repository = ctx.Service<ITagRepository>();

                   IDataLoader<Guid, Tag[]> recipeDataLoader =
                       ctx.GroupDataLoader<Guid, Tag>(
                           "tagsByRecipeId",
                           repository.GetTagsByRecipeId);

                   return recipeDataLoader.LoadAsync(ctx.Parent<Recipe>().Id);
               });
        }
    }
}
