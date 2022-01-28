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
    public class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommand>
    {
        private readonly IBasketRepository _repository;

        public DeleteBasketCommandHandler(IBasketRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteBasket(request.UserName);
            return Unit.Value;
        }
    }
}
