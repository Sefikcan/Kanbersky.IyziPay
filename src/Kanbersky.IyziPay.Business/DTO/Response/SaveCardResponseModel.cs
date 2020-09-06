namespace Kanbersky.IyziPay.Business.DTO.Response
{
    public class SaveCardResponseModel : BaseIyziPayResponseModel
    {
        public string ExternalId { get; set; }

        public string Email { get; set; }

        public string CardUserKey { get; set; }

        public string CardToken { get; set; }

        public string CardAlias { get; set; }

        public string BinNumber { get; set; }

        public string CardType { get; set; }

        public string CardAssociation { get; set; }

        public string CardFamily { get; set; }

        public long? CardBankCode { get; set; }

        public string CardBankName { get; set; }
    }
}
