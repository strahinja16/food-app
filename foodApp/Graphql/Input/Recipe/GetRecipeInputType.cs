using System;
using HotChocolate.Types;

namespace FoodApp.Graphql.Input.Recipe
{
    public class GetRecipeInputType : InputObjectType<GetRecipeInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<GetRecipeInput> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(r => r.RecipeId)
                .Type<NonNullType<IdType>>();
        }
    }
}
