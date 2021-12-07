using AutoMapper;
using Discount.CRPC.Protos;
using Discount.GRPC.Entities;

namespace Discount.GRPC.Mapper
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<Coupon, CouponModel>().ReverseMap();
        }
    }
}