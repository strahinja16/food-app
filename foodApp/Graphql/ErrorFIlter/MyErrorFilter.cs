using System;
using HotChocolate;

namespace FoodApp.Graphql.ErrorFIlter
{
    public class MyErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            return error.AddExtension("exceptionMessage", error.Exception.Message);
        }
    }
}
