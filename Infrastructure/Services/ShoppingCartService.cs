using Infrastructure.Entities;
using Infrastructure.Repositories;

namespace Infrastructure.Services
{
	public class ShoppingCartService
	{

		private readonly ShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartService(ShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<ShoppingCartEntity> GetShoppingcart(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                var shoppingcart = await _shoppingCartRepository.GetShoppingCartFromDbAsync(userId);
                return shoppingcart;
            }
            return null!;
        }


        public async Task<ShoppingCartEntity> CreateShoppingCart(string userId)
        {

        }







    }
}
