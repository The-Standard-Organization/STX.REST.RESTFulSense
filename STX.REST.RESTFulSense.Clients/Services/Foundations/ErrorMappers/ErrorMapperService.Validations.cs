// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using STX.REST.RESTFulSense.Clients.Models.ErrorMappers.Exceptions;

namespace STX.REST.RESTFulSense.Clients.Services.Foundations.ErrorMappers
{
    internal partial class ErrorMapperService
    {
        private static void ValidateStatusCode(int statusCode)
        {
            if (statusCode == default(int))
            {
                throw new InvalidErrorMapperException();
            }
        }
    }
}