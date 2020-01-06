using System;
using FoodApp.Graphql.Input.Tag;
using HotChocolate.Types;

namespace FoodApp.Graphql.Input.Recipe
{
    public class InsertRecipeInputType : InputObjectType<InsertRecipeInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<InsertRecipeInput> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(r => r.UserId)
                .Type<NonNullType<StringType>>();

            descriptor.Field(r => r.Tags)
                .Type<NonNullType<ListType<InsertTagInputType>>>();

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
