using System;
using HotChocolate;

namespace FoodApp.Graphql.ErrorFIlter
{
    public class ExceptionErrorFilter : IErrorFilter
    {
        public IError   OnError(IError error)
        {
            var message = error.Exception.Message;
            var exception = error.Exception.InnerException;

            while (exception != null)
            {
                message = $"{message} {exception.Message}";
                exception = exception.InnerException;
            }

            return error.AddExtension("exceptionMessage", message);
        }
    }
}
