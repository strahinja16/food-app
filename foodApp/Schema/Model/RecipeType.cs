using System;
using FoodApp.Model;
using HotChocolate.Types;

namespace FoodApp.Schema.Model
{
    public class RecipeType : ObjectType<Recipe>
    {
        protected override void Configure(IObjectTypeDescriptor<Recipe> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(r => r.Id)
                .Type<NonNullType<IdType>>();

            descriptor.Field(r => r.UserId)
               .Ignore();

            descriptor.Field(r => r.User)
                .Ignore();

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
        }
    }
}
