using System;
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
        }
    }
}
