using Basket.API.Entities;
using MediatR;

namespace Basket.API.MediatR.Commands
{
    public class UpdateBasketCommand : IRequest<ShoppingCart>
    {
        public ShoppingCart Basket { get; set; }

        public UpdateBasketCommand(ShoppingCart basket)
        {
            Basket = basket;
        }
    }
}
