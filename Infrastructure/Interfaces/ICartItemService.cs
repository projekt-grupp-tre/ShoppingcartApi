using Infrastructure.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Interfaces
{
    public interface ICartItemService
    {
        Task<bool> AddCartItemToShoppingCartAsync(IProductDto product, ShoppingCartEntity shoppingCart);
    }
}