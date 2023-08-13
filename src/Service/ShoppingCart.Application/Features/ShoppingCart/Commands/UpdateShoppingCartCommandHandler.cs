using AutoMapper;
using MediatR;
using ShoppingCart.Application.Dtos;
using ShoppingCart.Domain.Contracts;

namespace ShoppingCart.Application.Features.Department.Commands
{
    public class UpdateShoppingCartCommandHandler : IRequestHandler<UpdateShoppingCartDto, ShoppingCartDto>
    {
        private readonly IMapper Mapper;
        private readonly IShoppingCartRepository ShoppingCartRepository;

        public UpdateShoppingCartCommandHandler(IShoppingCartRepository shoppingCartRepository, IMapper mapper)
        {
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            ShoppingCartRepository = shoppingCartRepository ?? throw new ArgumentNullException(nameof(shoppingCartRepository));
        }

        public virtual async Task<ShoppingCartDto> Handle(UpdateShoppingCartDto request, CancellationToken cancellationToken)
        {
            try
            {
                var shoppingCart = Mapper.Map<Domain.Entities.ShoppingCart>(request);
                var updatedShoppingCart = await ShoppingCartRepository.UpdateShoppingCartAsync(shoppingCart);

                return Mapper.Map<ShoppingCartDto>(updatedShoppingCart);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
