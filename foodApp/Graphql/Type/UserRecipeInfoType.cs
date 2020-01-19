using System;
using FoodApp.Model;
using HotChocolate.Types;

namespace FoodApp.Graphql.Type
{
    public class UserRecipeInfoType : ObjectType<UserRecipeInfo>
    {
        protected override void Configure(IObjectTypeDescriptor<UserRecipeInfo> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(u => u.UserId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(u => u.RecipeId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(u => u.UserName)
                .Type<NonNullType<StringType>>();

            descriptor.Field(u => u.RecipeCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
