using System;
using FoodApp.Schema.Model;
using HotChocolate.Types;

namespace FoodApp.Schema.Query
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(q => q.GetUsers(default))
                .Type<NonNullType<ListType<NonNullType<UserType>>>>();
        }
    }
}
