using Kanbersky.IyziPay.Core.Settings.Abstract;

namespace Kanbersky.IyziPay.Core.Settings.Concrete
{
    public class IyziPaySettings : ISettings
    {
        public string ApiKey { get; set; }

        public string BaseUrl { get; set; }

        public string SecretKey { get; set; }
    }
}
