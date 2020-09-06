using Kanbersky.IyziPay.Core.Settings.Concrete;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;
using System;

namespace Kanbersky.IyziPay.Core.Helpers.Logging
{
    public class LoggerHelper
    {
        private readonly ElasticSearchSettings _elasticSearchSettings;

        public LoggerHelper(ElasticSearchSettings elasticSearchSettings)
        {
            _elasticSearchSettings = elasticSearchSettings;
        }

        public ILogger GetLogger(string applicationName, LogEventLevel logEventLevel)
        {
            var logConf = new LoggerConfiguration();
            logConf.MinimumLevel.Override("Microsoft", logEventLevel);
            logConf.MinimumLevel.Override("System", logEventLevel);
            logConf.MinimumLevel.Verbose();
            logConf.Enrich.FromLogContext();
            logConf.Enrich.WithProperty("Application", applicationName);
            logConf.WriteTo.Console();

            if (_elasticSearchSettings != null && !string.IsNullOrEmpty(_elasticSearchSettings.ServerUrl))
            {
                logConf.WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(_elasticSearchSettings.ServerUrl)));
            }

            return logConf.CreateLogger();
        }
    }
}
