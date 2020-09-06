using Kanbersky.IyziPay.Business.DTO.Request;
using Kanbersky.IyziPay.Business.DTO.Response;

namespace Kanbersky.IyziPay.Business.Abstract
{
    public interface IIyziPayService
    {
        InstallmentResponseModel CheckBinNumber(InstallmentRequestModel installmentRequest);

        SaveCardResponseModel SaveCard(SaveCardRequestModel saveCardRequest);

        CancelProcessResponseModel CancelProcess(CancelProcessRequestModel cancelProcessRequest);

        RefundProcessResponseModel RefundProcess(RefundProcessRequestModel refundProcessRequest);

        CheckPaymentStatusResponseModel CheckPaymentStatus(CheckPaymentStatusRequestModel checkPaymentStatusRequest);

        BasicPayResponseModel BasicPay(BasicPayRequestModel basicPayRequest);

        SecurePayResponseModel SecurePay(SecurePayRequestModel securePayRequest);

        CallBackResponseModel CallBack(CallBackRequestModel callBackRequest);
    }
}
