using Kanbersky.IyziPay.Core.Results.ApiResponses.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kanbersky.IyziPay.Core.Results.ApiResponses.Concrete
{
    public class IyzicoNoContentResult : StatusCodeResult, IIyzicoActionResult
    {
        public IyzicoNoContentResult() : base(StatusCodes.Status204NoContent)
        {
        }
    }
}
