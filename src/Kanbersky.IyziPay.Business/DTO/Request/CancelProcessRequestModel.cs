namespace Kanbersky.IyziPay.Business.DTO.Request
{
    public class CancelProcessRequestModel
    {
        /// <summary>
        /// İşlemin gönderildiği ip adresi.
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// iyzico tarafından işleme verilen benzersiz ödeme numarası.
        /// </summary>
        public string PaymentId { get; set; }

        /// <summary>
        /// iyzico istek sonucunda dönen metinlerin dilini ayarlamak için kullanılır. Varsayılan değeri tr’dir.
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        /// İstek esnasında gönderip, sonuçta alabileceğiniz bir değer, request/response eşleşmesi yapmak için kullanılabilir.
        /// </summary>
        public string ConversationId { get; set; }
    }
}
