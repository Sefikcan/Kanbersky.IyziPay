using Kanbersky.IyziPay.Core.Logging;
using Serilog;
using System.Linq;

namespace Kanbersky.IyziPay.Core.Extensions
{
    public static class LoggerExtensions
    {
        //reference: https://www.humankode.com/asp-net-core/logging-with-elasticsearch-kibana-asp-net-core-and-docker
        public static ILogger GetLogger(this ILogger logger, LoggerModel model)
        {
            if (logger == null)
                return logger;

            logger = logger
                .ForContext(nameof(model.RequestHost), model.RequestHost)
                .ForContext(nameof(model.RequestProtocol), model.RequestProtocol)
                .ForContext(nameof(model.RequestMethod), model.RequestMethod)
                .ForContext(nameof(model.ResponseStatusCode), model.ResponseStatusCode)
                .ForContext(nameof(model.RequestPath), model.RequestPath)
                .ForContext(nameof(model.RequestPathAndQuery), model.RequestPathAndQuery);

            if (model.RequestHeaders != null && model.RequestHeaders.Any())
                logger = logger.ForContext(nameof(model.RequestHeaders), model.RequestHeaders, true);

            if (model.ElapsedMilliseconds != null)
                logger = logger.ForContext(nameof(model.ElapsedMilliseconds), model.ElapsedMilliseconds);

            if (!string.IsNullOrEmpty(model.RequestBody))
                logger = logger.ForContext(nameof(model.RequestBody), model.RequestBody);

            if (model.Exception != null)
                logger = logger.ForContext(nameof(model.Exception), model.Exception, true);

            if (!string.IsNullOrEmpty(model.InnerException))
                logger = logger.ForContext(nameof(model.InnerException), model.InnerException);

            return logger;
        }
    }
}
