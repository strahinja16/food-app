using System;
using FoodApp.Model;
using HotChocolate.Types;

namespace FoodApp.Schema.Model
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(u => u.Id)
                .Type<IdType>();

            descriptor.Field(u => u.Name)
                .Type<NonNullType<StringType>>();
        }
    }

}
