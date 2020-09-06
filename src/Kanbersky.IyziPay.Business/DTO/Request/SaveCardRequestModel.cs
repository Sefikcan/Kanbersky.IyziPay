namespace Kanbersky.IyziPay.Business.DTO.Request
{
    public class SaveCardRequestModel
    {
        /// <summary>
        /// Saklı karta verilen isim.
        /// </summary>
        public string CardAlias { get; set; }

        /// <summary>
        /// Kartın üzerindeki isim.
        /// </summary>
        public string CardHolderName { get; set; }

        /// <summary>
        /// Kartın numarası.
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// Kartın üzerindeki ay.
        /// </summary>
        public string ExpireMonth { get; set; }

        /// <summary>
        /// Kartın üzerindeki yıl.
        /// </summary>
        public string ExpireYear { get; set; }

        /// <summary>
        /// Saklı kart sahibinin email adresi.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Saklanmak istenen karta üye iş yeri tarafından verilen id.
        /// </summary>
        public string ExternalId { get; set; }

        /// <summary>
        /// iyzico istek sonucunda dönen metinlerin dilini ayarlamak için kullanılır. Varsayılan değeri tr’dir.
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        /// İstek esnasında gönderip, sonuçta alabileceğiniz bir değer, request/response eşleşmesi yapmak için kullanılabilir.(Örnek orderno)
        /// </summary>
        public string ConversationId { get; set; }
    }
}
