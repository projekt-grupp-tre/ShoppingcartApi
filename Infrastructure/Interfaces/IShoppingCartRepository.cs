using Infrastructure.Entities;

namespace Infrastructure.Interfaces
{
    public interface IShoppingCartRepository
    {				
		Task<ShoppingCartEntity> CreateShoppingCartAsync(ShoppingCartEntity entity);
		Task<ShoppingCartEntity> GetShoppingCartFromDbAsync(string userEmail);
		Task<ShoppingCartEntity> GetFullShoppingCart(string userEmail);
		Task<ShoppingCartEntity> UpdateShoppingCartAsync(ShoppingCartEntity entity);
		Task<bool> DeleteShoppingCartAsync(ShoppingCartEntity shoppingCart);

	}
}