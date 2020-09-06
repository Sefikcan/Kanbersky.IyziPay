using Microsoft.AspNetCore.Mvc;

namespace Kanbersky.IyziPay.Core.Results.ApiResponses.Concrete
{
    public class IyzicoControllerBase : ControllerBase
    {
        [NonAction]
        public IyzicoCreatedObjectResult<TResult> ApiCreated<TResult>(TResult result) where TResult : class
        {
            return new IyzicoCreatedObjectResult<TResult>(result);
        }

        [NonAction]
        public IyzicoOkResult ApiOk()
        {
            return new IyzicoOkResult();
        }

        [NonAction]
        public IyzicoOkObjectResult<TResult> ApiOk<TResult>(TResult result) where TResult : class
        {
            return new IyzicoOkObjectResult<TResult>(result);
        }

        [NonAction]
        public IyzicoNoContentResult ApiNoContent()
        {
            return new IyzicoNoContentResult();
        }

        [NonAction]
        public IyzicoUpdatedObjectResult<TResult> ApiUpdated<TResult>(TResult result) where TResult : class
        {
            return new IyzicoUpdatedObjectResult<TResult>(result);
        }
    }
}
