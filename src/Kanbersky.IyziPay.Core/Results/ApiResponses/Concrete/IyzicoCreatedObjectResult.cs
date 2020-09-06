using Kanbersky.IyziPay.Core.Results.ApiResponses.Abstract;
using Kanbersky.IyziPay.Core.Results.ApiResponses.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kanbersky.IyziPay.Core.Results.ApiResponses.Concrete
{
    public class IyzicoCreatedObjectResult<T> : ObjectResult, IIyzicoActionResult
    {
        public IyzicoCreatedObjectResult(T result) : base(new IyzicoBaseObjectResultModel<T>(result))
        {
            StatusCode = StatusCodes.Status201Created;
        }
    }
}
