using AutoMapper;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Kanbersky.IyziPay.Business.Abstract;
using Kanbersky.IyziPay.Business.DTO.Request;
using Kanbersky.IyziPay.Business.DTO.Response;
using Kanbersky.IyziPay.Core.Results.Exceptions.Concrete;
using Kanbersky.IyziPay.Core.Settings.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Kanbersky.IyziPay.Business.Concrete
{
    public class IyziPayService : IIyziPayService
    {
        #region fields

        private IyziPaySettings _iyziPaySettings;
        private Options _options;
        private readonly IMapper _mapper;

        #endregion

        #region ctor

        public IyziPayService(IyziPaySettings iyziPaySettings,
            IMapper mapper)
        {
            _iyziPaySettings = iyziPaySettings;
            _mapper = mapper;
            if (_iyziPaySettings == null)
            {
                throw BaseException.BadRequestException("Payment Error!");
            }
            _options = new Options 
            {
                ApiKey = _iyziPaySettings.ApiKey,
                BaseUrl = _iyziPaySettings.BaseUrl,
                SecretKey = _iyziPaySettings.SecretKey
            };
        }

        #endregion

        #region methods

        public InstallmentResponseModel CheckBinNumber(InstallmentRequestModel installmentRequest)
        {
            RetrieveInstallmentInfoRequest request = new RetrieveInstallmentInfoRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = installmentRequest.ConversationId,
                BinNumber = installmentRequest.BinNumber.Substring(0,6),
                Price = installmentRequest.Price
            };

            InstallmentInfo installmentInfo = InstallmentInfo.Retrieve(request, _options);
            if (installmentInfo == null || (installmentInfo.InstallmentDetails == null || !installmentInfo.InstallmentDetails.Any()))
            {
                throw BaseException.BadRequestException("Payment Error!");
            }

            if (!string.IsNullOrEmpty(installmentInfo.ErrorCode))
            {
                throw BaseException.BadRequestException($"Payment Error Info: Error Code:{installmentInfo.ErrorCode}, Error Message:{installmentInfo.ErrorMessage}");
            }

            return _mapper.Map<InstallmentResponseModel>(installmentInfo);
        }

        public SaveCardResponseModel SaveCard(SaveCardRequestModel saveCardRequest)
        {
            CreateCardRequest request = new CreateCardRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = saveCardRequest.ConversationId,
                Email = saveCardRequest.Email,
                ExternalId = saveCardRequest.ExternalId
            };

            CardInformation cardInformation = new CardInformation
            {
                CardAlias = saveCardRequest.CardAlias,
                CardHolderName = saveCardRequest.CardHolderName,
                CardNumber = saveCardRequest.CardNumber,
                ExpireMonth = saveCardRequest.ExpireMonth,
                ExpireYear = saveCardRequest.ExpireYear
            };
            request.Card = cardInformation;

            Card card = Card.Create(request, _options);
            if (card == null)
            {
                throw BaseException.BadRequestException("Payment Error!");
            }

            if (!string.IsNullOrEmpty(card.ErrorCode))
            {
                throw BaseException.BadRequestException($"Payment Error Info: Error Code:{card.ErrorCode}, Error Message:{card.ErrorMessage}");
            }

            return _mapper.Map<SaveCardResponseModel>(card);
        }

        public CancelProcessResponseModel CancelProcess(CancelProcessRequestModel cancelProcessRequest)
        {
            CreateCancelRequest request = new CreateCancelRequest
            {
                ConversationId = cancelProcessRequest.ConversationId,
                Locale = Locale.TR.ToString(),
                PaymentId = "1",
                Ip = cancelProcessRequest.Ip // Burası Sunucu IP alacak şekilde güncellenecek!
            };

            Cancel cancel = Cancel.Create(request, _options);
            if (cancel == null)
            {
                throw BaseException.BadRequestException("Payment Error!");
            }

            if (!string.IsNullOrEmpty(cancel.ErrorCode))
            {
                throw BaseException.BadRequestException($"Payment Error Info: Error Code:{cancel.ErrorCode}, Error Message:{cancel.ErrorMessage}");
            }

            return _mapper.Map<CancelProcessResponseModel>(cancel);
        }

        public RefundProcessResponseModel RefundProcess(RefundProcessRequestModel refundProcessRequest)
        {
            CreateRefundRequest request = new CreateRefundRequest
            {
                ConversationId = refundProcessRequest.ConversationId,
                Locale = Locale.TR.ToString(),
                PaymentTransactionId = refundProcessRequest.PaymentTransactionId,
                Price = refundProcessRequest.Price,
                Ip = refundProcessRequest.Ip, // Burası Sunucu IP alacak şekilde güncellenecek!
                Currency = Currency.TRY.ToString()
            };

            Refund refund = Refund.Create(request, _options);
            if (refund == null)
            {
                throw BaseException.BadRequestException("Payment Error!");
            }

            if (!string.IsNullOrEmpty(refund.ErrorCode))
            {
                throw BaseException.BadRequestException($"Payment Error Info: Error Code:{refund.ErrorCode}, Error Message:{refund.ErrorMessage}");
            }

            return _mapper.Map<RefundProcessResponseModel>(refund);
        }

        public CheckPaymentStatusResponseModel CheckPaymentStatus(CheckPaymentStatusRequestModel checkPaymentStatusRequest)
        {
            RetrievePaymentRequest request = new RetrievePaymentRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = checkPaymentStatusRequest.ConversationId,
                PaymentId = checkPaymentStatusRequest.PaymentId
            };

            Payment payment = Payment.Retrieve(request, _options);
            if (payment == null)
            {
                throw BaseException.BadRequestException("Payment Error!");
            }

            if (!string.IsNullOrEmpty(payment.ErrorCode))
            {
                throw BaseException.BadRequestException($"Payment Error Info: Error Code:{payment.ErrorCode}, Error Message:{payment.ErrorMessage}");
            }

            return _mapper.Map<CheckPaymentStatusResponseModel>(payment);
        }

        public BasicPayResponseModel BasicPay(BasicPayRequestModel basicPayRequest)
        {
            CreatePaymentRequest request = new CreatePaymentRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = basicPayRequest.ConversationId,
                Price = basicPayRequest.Price.ToString(),
                PaidPrice = basicPayRequest.PaidPrice.ToString(),
                Currency = Currency.TRY.ToString(),
                Installment = basicPayRequest.Installment,
                PaymentChannel = PaymentChannel.WEB.ToString(),
                PaymentGroup = PaymentGroup.PRODUCT.ToString()
            };

            PaymentCard paymentCard = new PaymentCard
            {
                CardHolderName = basicPayRequest.CardHolderName,
                CardNumber = basicPayRequest.CardNumber,
                ExpireMonth = basicPayRequest.ExpireMonth,
                ExpireYear = basicPayRequest.ExpireYear,
                Cvc = basicPayRequest.Cvc,
                RegisterCard = basicPayRequest.RegisterCard
            };
            request.PaymentCard = paymentCard;

            Buyer buyer = new Buyer
            {
                Id = basicPayRequest.BuyerInfo.Id,
                Name = basicPayRequest.BuyerInfo.Name,
                Surname = basicPayRequest.BuyerInfo.SurName,
                Email = basicPayRequest.BuyerInfo.Email,
                IdentityNumber = basicPayRequest.BuyerInfo.IdentityNumber,
                RegistrationAddress = basicPayRequest.BuyerInfo.RegistrationAddress,
                Ip = basicPayRequest.BuyerInfo.Ip,
                City = basicPayRequest.BuyerInfo.City,
                Country = basicPayRequest.BuyerInfo.Country
            };
            request.Buyer = buyer;

            Address shippingAddress = new Address
            {
                ContactName = basicPayRequest.ShippingInfo.ContactName,
                City = basicPayRequest.ShippingInfo.City,
                Country = basicPayRequest.ShippingInfo.Country,
                Description = basicPayRequest.ShippingInfo.Address
            };
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address
            {
                ContactName = basicPayRequest.BillingInfo.ContactName,
                City = basicPayRequest.BillingInfo.City,
                Country = basicPayRequest.BillingInfo.Country,
                Description = basicPayRequest.BillingInfo.Address
            };
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            foreach (var basket in basicPayRequest.BasketItems)
            {
                BasketItem basketItem = new BasketItem
                {
                    Id = basket.Id,
                    Name = basket.Name,
                    Price = basket.Price,
                    Category1 = "-",
                    ItemType = BasketItemType.PHYSICAL.ToString()
                };
                basketItems.Add(basketItem);
            }
            request.BasketItems = basketItems;

            Payment payment = Payment.Create(request, _options);
            if (payment == null)
            {
                throw BaseException.BadRequestException("Payment Error!");
            }

            if (!string.IsNullOrEmpty(payment.ErrorCode))
            {
                throw BaseException.BadRequestException($"Payment Error Info: Error Code:{payment.ErrorCode}, Error Message:{payment.ErrorMessage}");
            }

            return _mapper.Map<BasicPayResponseModel>(payment);
        }

        public SecurePayResponseModel SecurePay(SecurePayRequestModel securePayRequest)
        {
            CreatePaymentRequest request = new CreatePaymentRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = securePayRequest.ConversationId,
                Price = securePayRequest.Price.ToString(),
                PaidPrice = securePayRequest.PaidPrice.ToString(),
                Currency = Currency.TRY.ToString(),
                Installment = securePayRequest.Installment,
                CallbackUrl = "http://localhost:60177/api/payments/callback"
            };

            PaymentCard paymentCard = new PaymentCard
            {
                CardHolderName = securePayRequest.CardHolderName,
                CardNumber = securePayRequest.CardNumber,
                ExpireMonth = securePayRequest.ExpireMonth,
                ExpireYear = securePayRequest.ExpireYear,
                Cvc = securePayRequest.Cvc,
                RegisterCard = securePayRequest.RegisterCard
            };
            request.PaymentCard = paymentCard;

            Buyer buyer = new Buyer
            {
                Id = securePayRequest.BuyerInfo.Id,
                Name = securePayRequest.BuyerInfo.Name,
                Surname = securePayRequest.BuyerInfo.SurName,
                Email = securePayRequest.BuyerInfo.Email,
                IdentityNumber = securePayRequest.BuyerInfo.IdentityNumber,
                RegistrationAddress = securePayRequest.BuyerInfo.RegistrationAddress,
                Ip = securePayRequest.BuyerInfo.Ip,
                City = securePayRequest.BuyerInfo.City,
                Country = securePayRequest.BuyerInfo.Country
            };
            request.Buyer = buyer;

            Address shippingAddress = new Address
            {
                ContactName = securePayRequest.ShippingInfo.ContactName,
                City = securePayRequest.ShippingInfo.City,
                Country = securePayRequest.ShippingInfo.Country,
                Description = securePayRequest.ShippingInfo.Address
            };
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address
            {
                ContactName = securePayRequest.BillingInfo.ContactName,
                City = securePayRequest.BillingInfo.City,
                Country = securePayRequest.BillingInfo.Country,
                Description = securePayRequest.BillingInfo.Address
            };
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            foreach (var basket in securePayRequest.BasketItems)
            {
                BasketItem basketItem = new BasketItem
                {
                    Id = basket.Id,
                    Name = basket.Name,
                    Price = basket.Price,
                    Category1 = "-",
                    ItemType = BasketItemType.PHYSICAL.ToString()
                };
                basketItems.Add(basketItem);
            }
            request.BasketItems = basketItems;

            ThreedsInitialize threedsInitialize = ThreedsInitialize.Create(request, _options);
            if (threedsInitialize == null)
            {
                throw BaseException.BadRequestException("Payment Error!");
            }

            if (!string.IsNullOrEmpty(threedsInitialize.ErrorCode))
            {
                throw BaseException.BadRequestException($"Payment Error Info: Error Code:{threedsInitialize.ErrorCode}, Error Message:{threedsInitialize.ErrorMessage}");
            }

            return _mapper.Map<SecurePayResponseModel>(threedsInitialize);
        }

        public CallBackResponseModel CallBack(CallBackRequestModel callBackRequest)
        {
            CreateThreedsPaymentRequest request = new CreateThreedsPaymentRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = callBackRequest.ConversationId.ToString(),
                PaymentId = callBackRequest.PaymentId,
                ConversationData = callBackRequest.ConversationData
            };

            ThreedsPayment threedsPayment = ThreedsPayment.Create(request, _options);
            if (threedsPayment == null)
            {
                throw BaseException.BadRequestException("Payment Error!");
            }

            if (!string.IsNullOrEmpty(threedsPayment.ErrorCode))
            {
                throw BaseException.BadRequestException($"Payment Error Info: Error Code:{threedsPayment.ErrorCode}, Error Message:{threedsPayment.ErrorMessage}");
            }

            return _mapper.Map<CallBackResponseModel>(threedsPayment);
        }

        #endregion
    }
}
