using System.Collections.Generic;

namespace Kanbersky.IyziPay.Business.DTO.Response
{
    public class InstallmentResponseModel : BaseIyziPayResponseModel
    {
        public List<InstallmentDetailResponseModel> InstallmentDetails { get; set; }
    }
}
