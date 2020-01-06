using System;
using HotChocolate.Types;

namespace FoodApp.Graphql.Input.User
{
    public class InsertUserInputType : InputObjectType<InsertUserInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<InsertUserInput> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(i => i.Name)
                .Type<NonNullType<StringType>>();

            descriptor.Field(i => i.Email)
                .Type<NonNullType<StringType>>();

            descriptor.Field(i => i.Password)
                .Type<NonNullType<StringType>>();
        }
    }
}
