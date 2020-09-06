namespace Kanbersky.IyziPay.Business.DTO.Request
{
    public class RefundProcessRequestModel
    {
        /// <summary>
        /// İşlemin gönderildiği ip adresi.
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// İade edilmek istenen tutar.
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// iyzico tarafından işleme verilen benzersiz ödeme kırılım numarası.
        /// </summary>
        public string PaymentTransactionId { get; set; }

        /// <summary>
        /// İstek esnasında gönderip, sonuçta alabileceğiniz bir değer, request/response eşleşmesi yapmak için kullanılabilir.
        /// </summary>
        public string ConversationId { get; set; }
    }
}
