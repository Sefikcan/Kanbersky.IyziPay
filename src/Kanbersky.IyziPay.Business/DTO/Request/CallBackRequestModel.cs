namespace Kanbersky.IyziPay.Business.DTO.Request
{
    public class CallBackRequestModel
    {
        /// <summary>
        /// Yapılan isteğin sonucunu bildirir. İşlem başarılı ise success, hatalı ise failure döner.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// İşlem success yani başarılı ise, iyzico tarafından o ödemeye verilen değerdir. 3D bitirme sorgusunda kullanılacaktır.
        /// </summary>
        public string PaymentId { get; set; }

        /// <summary>
        /// İşlem success yani başarılı ise, iyzico tarafından o ödemeye verilen değerdir. Bütün durumlarda dolu gelmeyebilir. Eğer dolu gelirse bu parametrenin de 3D bitirme sorgusunda gönderilmesi gerekir.
        /// </summary>
        public string ConversationData { get; set; }

        /// <summary>
        /// Başlatma sorgusunda gönderilen conversationId değeridir.
        /// </summary>
        public long ConversationId { get; set; }

        /// <summary>
        /// Bilgilendirme amaçlı dönen mdStatus değeridir. Başarılı durumlar için 1 başarısız durumlar için ise 0,2,3,4,5,6,7,8 olarak dönebilir.
        /// </summary>
        public string MdStatus { get; set; }
    }
}
