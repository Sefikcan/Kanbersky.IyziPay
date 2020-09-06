using Kanbersky.IyziPay.Core.Extensions;
using Kanbersky.IyziPay.Core.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Serilog;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanbersky.IyziPay.Core.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private static readonly ILogger Logger = Log.ForContext<ExceptionMiddleware>();

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await InternalServerError(context, ex);
            }
        }

        private static async Task InternalServerError(HttpContext context, Exception ex, string contentType = "text/plain")
        {
            await Task.Run(() =>
            {
                var request = context.Request;
                var encodedPathAndQuery = request.GetEncodedPathAndQuery();

                var logModel = new LoggerModel()
                {
                    RequestHost = request.Host.Host,
                    RequestProtocol = request.Protocol,
                    RequestMethod = request.Method,
                    RequestPath = request.Path,
                    RequestPathAndQuery = encodedPathAndQuery,
                    RequestHeaders = request.Headers.ToDictionary(x => x.Key, x => (object)x.Value.ToString()),
                    RequestBody = string.Empty,
                    Exception = ex,
                    InnerException = ex.Message
                };

                Logger.GetLogger(logModel).Error(LoggerTemplates.Error);
            });

            context.Response.Clear();
            context.Response.ContentType = contentType;
            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsync(ex.Message, Encoding.UTF8);
        }
    }
}
