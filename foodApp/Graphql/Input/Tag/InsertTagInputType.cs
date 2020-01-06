using System;
using HotChocolate.Types;

namespace FoodApp.Graphql.Input.Tag
{
    public class InsertTagInputType : InputObjectType<InsertTagInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<InsertTagInput> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(r => r.Name)
                .Type<NonNullType<StringType>>();
        }
    }
}
