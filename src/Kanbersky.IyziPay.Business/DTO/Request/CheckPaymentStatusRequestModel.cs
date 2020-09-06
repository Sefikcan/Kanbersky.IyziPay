namespace Kanbersky.IyziPay.Business.DTO.Request
{
    public class CheckPaymentStatusRequestModel
    {
        /// <summary>
        /// iyzico tarafından işleme verilen benzersiz ödeme numarası.
        /// </summary>
        public string PaymentId { get; set; }

        /// <summary>
        /// İstek esnasında gönderip, sonuçta alabileceğiniz bir değer, request/response eşleşmesi yapmak için kullanılabilir.
        /// </summary>
        public string ConversationId { get; set; }
    }
}
