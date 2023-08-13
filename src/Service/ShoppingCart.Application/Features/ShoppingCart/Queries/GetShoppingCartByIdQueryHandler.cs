using AutoMapper;
using MediatR;
using ShoppingCart.Application.Dtos;
using ShoppingCart.Domain.Contracts;

namespace ShoppingCart.Application.Features.ShoppingCart.Queries
{
    public class GetShoppingCartByIdQueryHandler : IRequestHandler<GetShoppingCartByIdQuery, ShoppingCartDto>
    {
        private readonly IMapper Mapper;
        private readonly IShoppingCartRepository ShoppingCartRepository;

        public GetShoppingCartByIdQueryHandler(IShoppingCartRepository shoppingCartRepository, IMapper mapper)
        {
            ShoppingCartRepository = shoppingCartRepository ?? throw new ArgumentNullException(nameof(shoppingCartRepository));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ShoppingCartDto> Handle(GetShoppingCartByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var shoppingCart = await ShoppingCartRepository.GetShoppingCartByIdAsync(request.Id);

                return Mapper.Map<ShoppingCartDto>(shoppingCart);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
