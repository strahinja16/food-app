using System;
using FoodApp.Graphql.Resolvers;
using FoodApp.Model;
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
            descriptor.Field<UserResolver>(t => t.GetRecipes(default, default))
                 .Type<NonNullType<ListType<TagType>>>();
        }
    }
}
