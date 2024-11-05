using Infrastructure.Entities;

namespace Infrastructure.Interfaces;

public interface ICartItemRepository
{
	Task<CartItemEntity> CreateCartItemAsync(CartItemEntity entity); 
}
