namespace Kanbersky.IyziPay.Business.DTO.Request
{
    public class InstallmentRequestModel
    {
        public string BinNumber { get; set; }

        public string Locale { get; set; }

        public string ConversationId { get; set; }

        public string Price { get; set; }
    }
}
