using System.Threading.Tasks;
using Discount.CRPC.Protos;

namespace Basket.API.DiscountGrpcServices
{
    public class DiscountGrpcService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _discountProtoServiceClient;

        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountProtoServiceClient)
        {
            _discountProtoServiceClient = discountProtoServiceClient;
        }

        public async Task<CouponModel> GetDiscount(string productName)
        {
            var discountRequest = new GetDiscountRequest {ProductName = productName};

            return _discountProtoServiceClient.GetDiscount(discountRequest);
        }
    }
}