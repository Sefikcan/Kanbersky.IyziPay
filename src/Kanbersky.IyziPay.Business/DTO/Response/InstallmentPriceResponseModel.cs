﻿using Newtonsoft.Json;

namespace Kanbersky.IyziPay.Business.DTO.Response
{
    public class InstallmentPriceResponseModel
    {
        [JsonProperty(PropertyName = "InstallmentPrice")]
        public string Price { get; set; }

        public string TotalPrice { get; set; }

        public int? InstallmentNumber { get; set; }
    }
}
