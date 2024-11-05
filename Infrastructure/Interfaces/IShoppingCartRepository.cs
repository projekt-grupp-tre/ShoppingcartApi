using Infrastructure.Entities;

namespace Infrastructure.Interfaces
{
    public interface IShoppingCartRepository
    {				
		Task<ShoppingCartEntity> CreateShoppingCartAsync(ShoppingCartEntity entity);
		Task<ShoppingCartEntity> GetShoppingCartFromDbAsync(string userId);
		Task<ShoppingCartEntity> UpdateShoppingCartAsync(ShoppingCartEntity entity);
		Task<ShoppingCartEntity> DeleteShoppingCartAsync(ShoppingCartEntity entity);
	}
}