using Kanbersky.IyziPay.Core.Results.Exceptions.Abstract;
using Microsoft.AspNetCore.Http;
using System;

namespace Kanbersky.IyziPay.Core.Results.Exceptions.Concrete
{
    public class NotFoundException : Exception, IBaseException
    {
        public int BaseStatusCode { get; set; }

        public NotFoundException()
        {
            BaseStatusCode = StatusCodes.Status404NotFound;
        }

        public NotFoundException(string message) : base(message)
        {
            BaseStatusCode = StatusCodes.Status404NotFound;
        }

        public NotFoundException(string message, Exception exception) : base(message, exception)
        {
            BaseStatusCode = StatusCodes.Status404NotFound;
        }
    }
}
