using MediatR;
using ShoppingCart.Application.Dtos;
using ShoppingCart.Domain.Contracts;

namespace ShoppingCart.Application.Features.Department.Commands
{
    public class DeleteShoppingCartCommandHandler : IRequestHandler<DeleteShoppingCartDto, Unit>
    {
        private readonly IShoppingCartRepository ShoppingCartRepository;

        public DeleteShoppingCartCommandHandler(IShoppingCartRepository shoppingCartRepository)
        {
            ShoppingCartRepository = shoppingCartRepository ?? throw new ArgumentNullException(nameof(shoppingCartRepository));
        }

        public virtual async Task<Unit> Handle(DeleteShoppingCartDto request, CancellationToken cancellationToken)
        {
            try
            {
                await ShoppingCartRepository.DeleteShoppingCartAsync(request.Id);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
