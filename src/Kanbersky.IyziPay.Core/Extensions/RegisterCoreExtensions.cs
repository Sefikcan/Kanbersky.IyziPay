using Kanbersky.IyziPay.Core.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Kanbersky.IyziPay.Core.Extensions
{
    public static class RegisterCoreExtensions
    {
        public static void UseExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
