namespace Kanbersky.IyziPay.Business.DTO.Response
{
    public class BaseIyziPayResponseModel
    {
        public string Status { get; set; }

        public string ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        public string ErrorGroup { get; set; }

        public string Locale { get; set; }

        public long SystemTime { get; set; }

        public string ConversationId { get; set; }
    }
}
