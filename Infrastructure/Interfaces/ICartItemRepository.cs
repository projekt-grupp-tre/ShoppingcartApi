using Infrastructure.Entities;

namespace Infrastructure.Interfaces;

public interface ICartItemRepository
{
	Task<CartItemEntity> CreateCartItemAsync(CartItemEntity entity);

	Task<List<CartItemEntity>> GetCartItemsAsync(int shoppingCartId);

	Task<CartItemEntity> UpdateCartItemAsync(CartItemEntity oldEntity, CartItemEntity newEntity);
	Task<bool> DeleteCartItemAsync(CartItemEntity entity);
}
