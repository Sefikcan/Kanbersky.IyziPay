using Kanbersky.IyziPay.Core.Results.ApiResponses.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kanbersky.IyziPay.Core.Results.ApiResponses.Concrete
{
    public class IyzicoOkResult : StatusCodeResult, IIyzicoActionResult
    {
        public IyzicoOkResult() : base(StatusCodes.Status200OK)
        {
        }
    }
}
