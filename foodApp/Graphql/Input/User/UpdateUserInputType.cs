using System;
using HotChocolate.Types;

namespace FoodApp.Graphql.Input.User
{
    public class UpdateUserInputType : InputObjectType<UpdateUserInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<UpdateUserInput> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(i => i.Id)
                .Type<NonNullType<IdType>>();

            descriptor.Field(i => i.Name)
                .Type<StringType>();

            descriptor.Field(i => i.Email)
                .Type<StringType>();

            descriptor.Field(i => i.Password)
                .Type<StringType>();
        }
    }
}
