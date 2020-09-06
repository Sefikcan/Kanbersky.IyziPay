using Kanbersky.IyziPay.Core.Results.ApiResponses.Abstract;
using Kanbersky.IyziPay.Core.Results.ApiResponses.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kanbersky.IyziPay.Core.Results.ApiResponses.Concrete
{
    public class IyzicoOkObjectResult<T> : ObjectResult, IIyzicoActionResult
    {
        public IyzicoOkObjectResult(T result) : base(new IyzicoBaseObjectResultModel<T>(result))
        {
            StatusCode = StatusCodes.Status200OK;
        }
    }
}
