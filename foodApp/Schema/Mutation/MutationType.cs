using System;
using FoodApp.Schema.Input.User;
using FoodApp.Schema.Model;
using HotChocolate.Types;

namespace FoodApp.Schema.Mutation
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
