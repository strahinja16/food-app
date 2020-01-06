using System;
using HotChocolate.Types;

namespace FoodApp.Graphql.Input.User
{
    public class DeleteUserInputType : InputObjectType<DeleteUserInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<DeleteUserInput> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(i => i.UserId)
                .Type<NonNullType<StringType>>();
        }
    }
}
