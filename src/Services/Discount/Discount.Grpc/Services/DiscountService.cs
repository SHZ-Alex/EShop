using Discount.Grpc.Data;
using Discount.Grpc.Models;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Services
{
    public class DiscountService(DiscountContext db) : DiscountProtoService.DiscountProtoServiceBase
    {
        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = await db.Coupons.FirstOrDefaultAsync(x => x.ProductName == request.ProductName, context.CancellationToken);

            if (coupon is null)
                throw new RpcException(new Status(StatusCode.NotFound, "Not Found"));
            
            return new CouponModel{ Id = coupon.Id, ProductName = coupon.ProductName, Amount = coupon.Amount, Description = coupon.Description};
        }

        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            if (request.Coupon is null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid Argument"));
            
            var coupon = new Coupon
            {
                ProductName = request.Coupon.ProductName,
                Description = request.Coupon.Description,
                Amount = request.Coupon.Amount
            };
            
            db.Coupons.Add(coupon);
            await db.SaveChangesAsync(context.CancellationToken);

            return new CouponModel
            {
                Id = coupon.Id,
                ProductName = coupon.ProductName,
                Description = coupon.Description,
                Amount = coupon.Amount,
            };
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            if (string.IsNullOrWhiteSpace(request.ProductName))
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid Argument"));
            
            var result = await db.Coupons
                .Where(x => x.ProductName == request.ProductName)
                .ExecuteDeleteAsync(context.CancellationToken) >= 1;
            
            if (!result)
                throw new RpcException(new Status(StatusCode.NotFound, "Not Found"));

            return new DeleteDiscountResponse()
            {
                Success = result
            };
        }

        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            if (request.Coupon is null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid Argument"));
            
            var coupon = new Coupon
            {
                Id = request.Coupon.Id,
                ProductName = request.Coupon.ProductName,
                Description = request.Coupon.Description,
                Amount = request.Coupon.Amount
            };
            
            db.Coupons.Update(coupon);
            await db.SaveChangesAsync(context.CancellationToken);

            return new CouponModel
            {
                Id = coupon.Id,
                ProductName = coupon.ProductName,
                Description = coupon.Description,
                Amount = coupon.Amount,
            };
        }
    }
}
