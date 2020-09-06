using System.Collections.Generic;

namespace Kanbersky.IyziPay.Business.DTO.Request
{
    public class BasicPayRequestModel
    {
        public BasicPayRequestModel()
        {
            BasketItems = new List<BasketItemRequestModel>();
        }

        public string ConversationId { get; set; }

        public decimal Price { get; set; }

        public decimal PaidPrice { get; set; }

        public string Currency { get; set; }

        public int Installment { get; set; }

        public string CardNumber { get; set; }

        public string ExpireYear { get; set; }

        public string ExpireMonth { get; set; }

        public string Cvc { get; set; }

        public string CardHolderName { get; set; }

        public int RegisterCard { get; set; }

        public List<BasketItemRequestModel> BasketItems { get; set; }

        public BuyerRequestModel BuyerInfo { get; set; }

        public BillingRequestModel BillingInfo { get; set; }

        public ShippingRequestModel ShippingInfo { get; set; }
    }
}
