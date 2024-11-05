using Infrastructure.Entities;

namespace Infrastructure.Interfaces
{
    public interface IShoppingCartService
    {
        Task<ShoppingCartEntity> CreateShoppingCartAsync(string userId);
        Task<ShoppingCartEntity> GetShoppingcartAsync(string userId);
    }
}