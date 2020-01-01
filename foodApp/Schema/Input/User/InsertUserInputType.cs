using System;
using HotChocolate.Types;

namespace FoodApp.Schema.Input.User
{
    public class InsertUserInputType : InputObjectType<InsertUserInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<InsertUserInput> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(i => i.Name)
                .Type<NonNullType<StringType>>();
        }
    }
}
