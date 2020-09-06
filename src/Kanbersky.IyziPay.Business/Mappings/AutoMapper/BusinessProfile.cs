using AutoMapper;
using Iyzipay.Model;
using Kanbersky.IyziPay.Business.DTO.Response;

namespace Kanbersky.IyziPay.Business.Mappings.AutoMapper
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            //Check Bin and Installment
            CreateMap<InstallmentResponseModel, InstallmentInfo>().ReverseMap();
            CreateMap<InstallmentDetailResponseModel, InstallmentDetail>().ReverseMap();
            CreateMap<InstallmentPriceResponseModel, InstallmentPrice>().ReverseMap();

            //Save Card
            CreateMap<SaveCardResponseModel, Card>().ReverseMap();

            //Cancel Process
            CreateMap<CancelProcessResponseModel, Cancel>().ReverseMap();

            //Refund Process
            CreateMap<RefundProcessResponseModel, Refund>().ReverseMap();

            //Check Payment Status
            CreateMap<CheckPaymentStatusResponseModel, Payment>().ReverseMap();
            CreateMap<PaymentItemResponseModel, PaymentItem>().ReverseMap();
            CreateMap<ConvertedPayoutResponseModel, ConvertedPayout>().ReverseMap();

            //Non 3D Payment
            CreateMap<BasicPayResponseModel, Payment>().ReverseMap();

            //3D Payment
            CreateMap<SecurePayResponseModel, ThreedsInitialize>().ReverseMap();

            //CallBack
            CreateMap<CallBackResponseModel, ThreedsPayment>().ReverseMap();
        }
    }
}
