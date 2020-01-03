using System;
using FoodApp.Model;
using HotChocolate.Types;

namespace FoodApp.Graphql.Type
{
    public class TagType : ObjectType<Tag>
    {
        protected override void Configure(IObjectTypeDescriptor<Tag> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(t => t.Id)
                .Type<NonNullType<IdType>>();

            // Ignored
            descriptor.Field(t => t.RecipeTags)
                .Ignore();

            // Properties
            descriptor.Field(t => t.Name)
                .Type<NonNullType<StringType>>();
        }
    }
}
