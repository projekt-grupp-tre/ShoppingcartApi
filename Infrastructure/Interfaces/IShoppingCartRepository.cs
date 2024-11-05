using Infrastructure.Entities;

namespace Infrastructure.Interfaces
{
    public interface IShoppingCartRepository
    {				
		Task<ShoppingCartEntity> CreateShoppingCartAsync(ShoppingCartEntity entity);
		Task<ShoppingCartEntity> GetShoppingCartAsync(ShoppingCartEntity entity);
		Task<ShoppingCartEntity> UpdateShoppingCartAsync(ShoppingCartEntity entity);
		Task<ShoppingCartEntity> DeleteShoppingCartAsync(ShoppingCartEntity entity);
	}
}