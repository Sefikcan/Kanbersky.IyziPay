using Kanbersky.IyziPay.Business.Abstract;
using Kanbersky.IyziPay.Business.DTO.Request;
using Kanbersky.IyziPay.Business.DTO.Response;
using Kanbersky.IyziPay.Core.Results.ApiResponses.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kanbersky.IyziPay.Api.Controllers
{
    /// <summary>
    /// Payments Operations
    /// </summary>
    [Route("api/payments")]
    [ApiController]
    public class PaymentsController : IyzicoControllerBase
    {
        private readonly IIyziPayService _iyziPayService;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="iyziPayService"></param>
        public PaymentsController(IIyziPayService iyziPayService)
        {
            _iyziPayService = iyziPayService;
        }

        /// <summary>
        /// Returns credit card information according to the bin number entered
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("check-bin")]
        [ProducesResponseType(typeof(InstallmentResponseModel), StatusCodes.Status200OK)]
        public IActionResult CheckBin([FromQuery] InstallmentRequestModel installmentRequest)
        {
            var response = _iyziPayService.CheckBinNumber(installmentRequest);
            return ApiOk(response);
        }

        /// <summary>
        /// Save Card Information
        /// </summary>
        /// <param name="saveCardRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("save-card")]
        [ProducesResponseType(typeof(SaveCardResponseModel), StatusCodes.Status201Created)]
        public IActionResult SaveCard([FromBody] SaveCardRequestModel saveCardRequest)
        {
            var response = _iyziPayService.SaveCard(saveCardRequest);
            return ApiCreated(response);
        }

        /// <summary>
        /// Cancel Process Operation
        /// </summary>
        /// <param name="cancelProcessRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("cancel-process")]
        [ProducesResponseType(typeof(CancelProcessResponseModel), StatusCodes.Status201Created)]
        public IActionResult CancelProcess([FromBody] CancelProcessRequestModel cancelProcessRequest)
        {
            var response = _iyziPayService.CancelProcess(cancelProcessRequest);
            return ApiCreated(response);
        }

        /// <summary>
        /// Refund Process Operation
        /// </summary>
        /// <param name="refundProcessRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("refund-process")]
        [ProducesResponseType(typeof(RefundProcessResponseModel), StatusCodes.Status201Created)]
        public IActionResult RefundProcess([FromBody] RefundProcessRequestModel refundProcessRequest)
        {
            var response = _iyziPayService.RefundProcess(refundProcessRequest);
            return ApiCreated(response);
        }

        /// <summary>
        /// Check Payment Status
        /// </summary>
        /// <param name="checkPaymentStatusRequest"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("check-payment-status")]
        [ProducesResponseType(typeof(CheckPaymentStatusResponseModel), StatusCodes.Status200OK)]
        public IActionResult CheckPaymentStatus([FromQuery] CheckPaymentStatusRequestModel checkPaymentStatusRequest)
        {
            var response = _iyziPayService.CheckPaymentStatus(checkPaymentStatusRequest);
            return ApiOk(response);
        }

        /// <summary>
        /// Non-3d Payment Operations
        /// </summary>
        /// <param name="basicPayRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("basic-pay")]
        [ProducesResponseType(typeof(BasicPayResponseModel), StatusCodes.Status201Created)]
        public IActionResult BasicPay([FromBody] BasicPayRequestModel basicPayRequest)
        {
            var response = _iyziPayService.BasicPay(basicPayRequest);
            return ApiCreated(response);
        }

        /// <summary>
        /// Start 3d Payment Operation
        /// </summary>
        /// <param name="securePayRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("secure-pay")]
        [ProducesResponseType(typeof(SecurePayResponseModel), StatusCodes.Status201Created)]
        public IActionResult SecurePay([FromBody] SecurePayRequestModel securePayRequest)
        {
            var response = _iyziPayService.SecurePay(securePayRequest);
            return ApiCreated(response);
        }

        /// <summary>
        /// End 3d Payment Operation
        /// </summary>
        /// <param name="callBackRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("callback")]
        [ProducesResponseType(typeof(CallBackResponseModel), StatusCodes.Status201Created)]
        public IActionResult CallBack([FromBody] CallBackRequestModel callBackRequest) //UI ile sağlıklı test edilebilir
        {
            var response = _iyziPayService.CallBack(callBackRequest);
            return ApiCreated(response);
        }
    }
}
