using MediatR;

namespace Basket.API.MediatR.Commands
{
    public class DeleteBasketCommand : IRequest
    {
        public string UserName { get; set; }

        public DeleteBasketCommand(string userName)
        {
            UserName = userName;
        }
    }
}
