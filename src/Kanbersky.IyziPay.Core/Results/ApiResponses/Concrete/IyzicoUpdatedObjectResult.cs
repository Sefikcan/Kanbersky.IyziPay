using Kanbersky.IyziPay.Core.Results.ApiResponses.Abstract;
using Kanbersky.IyziPay.Core.Results.ApiResponses.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kanbersky.IyziPay.Core.Results.ApiResponses.Concrete
{
    public class IyzicoUpdatedObjectResult<T> : ObjectResult, IIyzicoActionResult
    {
        public IyzicoUpdatedObjectResult(T result) : base(new IyzicoBaseObjectResultModel<T>(result))
        {
            StatusCode = StatusCodes.Status200OK;
        }
    }
}
