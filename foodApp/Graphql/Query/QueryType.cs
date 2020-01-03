using System;
using FoodApp.Graphql.Type;
using HotChocolate.Types;

namespace FoodApp.Graphql.Query
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(q => q.GetUsers(default))
                .Type<NonNullType<ListType<NonNullType<UserType>>>>();

            descriptor.Field(q => q.GetRecipes(default))
                .Type<NonNullType<ListType<NonNullType<RecipeType>>>>();
        }
    }
}
