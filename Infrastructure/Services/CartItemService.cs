using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Interfaces;

namespace Infrastructure.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly ICartItemRepository _cartItemRepository;

        public CartItemService(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<bool> AddCartItemToShoppingCartAsync(IProductDto product, ShoppingCartEntity shoppingCart)
        {
            if (product != null && shoppingCart != null)
            {
                var newCartItem = IProductToCartItemFactory.ConvertFromProductToEntity(product);
                newCartItem.ShoppingCartId = shoppingCart.Id;
                newCartItem.ShoppingCartEntity = shoppingCart;

                var result = await _cartItemRepository.CreateCartItemAsync(newCartItem);

                if (result != null)
                    return true;
            }
            return false;
        }
    }
}
