namespace Kanbersky.IyziPay.Business.DTO.Response
{
    public class CancelProcessResponseModel : BaseIyziPayResponseModel
    {
        public string PaymentId { get; set; }

        public string Price { get; set; }

        public string Currency { get; set; }

        public string ConnectorName { get; set; }

        public string AuthCode { get; set; }

        public string HostReference { get; set; }
    }
}
