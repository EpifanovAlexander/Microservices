using Basket.API.Entities;
using MediatR;

namespace Basket.API.MediatR.Commands
{
    public class GetBasketCommand : IRequest<ShoppingCart>
    {
        public string UserName { get; set; }

        public GetBasketCommand(string userName)
        {
            UserName = userName;
        }
    }
}
