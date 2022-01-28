using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Basket.API.Entities;
using MediatR;
using Basket.API.MediatR.Commands;
using Basket.API.Repositories.Interfaces;
using System.Threading;

namespace Basket.API.MediatR.Handlers
{
    public class GetBasketCommandHandler : IRequestHandler<GetBasketCommand, ShoppingCart>
    {
        private readonly IBasketRepository _repository;

        public GetBasketCommandHandler(IBasketRepository repository)
        {
            _repository = repository;
        }

        public async Task<ShoppingCart> Handle(GetBasketCommand request, CancellationToken cancellationToken)
        {
            return await _repository.GetBasket(request.UserName);
        }
    }
}
