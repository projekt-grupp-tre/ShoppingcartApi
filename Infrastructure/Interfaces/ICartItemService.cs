using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Interfaces
{
    public interface ICartItemService
    {
        Task<bool> AddCartItemToShoppingCartAsync(IProductDto product, ShoppingCartEntity shoppingCart);
        Task<List<CartItemEntity>> GetAllCartItemsAsync(IProductDto product, int shoppingCartId);
        Task<CartItemEntity> CheckExistingCartForItems(List<CartItemEntity> list, ProductDto product);
        Task<bool> DeleteCartItemFromShoppingCart(List<CartItemEntity> list, ProductDto product);

	}
}