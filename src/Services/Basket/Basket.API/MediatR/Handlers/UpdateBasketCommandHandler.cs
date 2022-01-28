using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Basket.API.Entities;
using MediatR;
using Basket.API.MediatR.Commands;
using Basket.API.Repositories.Interfaces;
using System.Threading;
using Basket.API.GrpcServices;

namespace Basket.API.MediatR.Handlers
{
    public class UpdateBasketCommandHandler : IRequestHandler<UpdateBasketCommand, ShoppingCart>
    {
        private readonly IBasketRepository _repository;
        private readonly DiscountGrpcService _discountGrpcService;

        public UpdateBasketCommandHandler(IBasketRepository repository, DiscountGrpcService discountGrpcService)
        {
            _repository = repository;
            _discountGrpcService = discountGrpcService;
        }

        public async Task<ShoppingCart> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
        {
            var basket = request.Basket;
            foreach (var item in basket.Items)
            {
                var coupon = await _discountGrpcService.GetDiscount(item.ProductName);
                item.Price -= coupon.Amount;
            }
            return await _repository.UpdateBasket(basket);
        }
    }
}
