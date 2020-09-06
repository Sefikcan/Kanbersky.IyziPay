namespace Kanbersky.IyziPay.Core.Results.ApiResponses.Models
{
    public class IyzicoBaseObjectResultModel<T>
    {
        public T Result { get; set; }

        public IyzicoBaseObjectResultModel(T result)
        {
            Result = result;
        }
    }
}
