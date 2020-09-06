using Kanbersky.IyziPay.Core.Settings.Abstract;

namespace Kanbersky.IyziPay.Core.Settings.Concrete
{
    public class ElasticSearchSettings : ISettings
    {
        public string ServerUrl { get; set; }
    }
}
